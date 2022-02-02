using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sklep.Authentication;
using Sklep.Entities;
using Sklep.Exceptions;
using Sklep.Models;
using Sklep.Services.CountryService;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Services
{
    class AccountService : IAccountService
    {
        private readonly Shop _context;
        private readonly ICountryService _countryService;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(Shop context, ICountryService countryService, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _context = context;
            _countryService = countryService;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }


        async public Task RegisterUser(RegisterUserDto dto)
        {
            var countryId = _countryService.GetCountryById(dto.CountryId);

            var user = new User
            {
                Mail = dto.Mail,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Password = dto.Password,
                CountryId = dto.CountryId,
                DateOfBirth = dto.DateOfBirth,
                RoleId = dto.RoleId,
            };

            var hashedPassword = _passwordHasher.HashPassword(user, user.Password);

            user.Password = hashedPassword;

            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        async public Task<string> LoginUser(LoginUserDto dto)
        {
            var user = await _context.User
                .Include(u => u.Role)
                .Include(z => z.Country)
                .FirstOrDefaultAsync(x => x.Mail == dto.Mail);
        
            if (user == null)
                throw new BadRequestException("Email or password is incorect");

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password);

            if(result == PasswordVerificationResult.Failed)
                throw new BadRequestException("Email or password is incorect");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, user.Role.RoleName.ToString()),
                new Claim("DateOfBirth", user.DateOfBirth.ToString("yyyy-MM-dd")),
                new Claim("Country", user.Country.CountryName.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwkKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwkExpireDays);

            var token = new JwtSecurityToken(
                _authenticationSettings.JwkIssuer, 
                _authenticationSettings.JwkIssuer, 
                claims, 
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
