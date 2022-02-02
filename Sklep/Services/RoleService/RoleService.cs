using Sklep.Entities;
using System.Threading.Tasks;
using System.Linq;
using Sklep.Exceptions;
using Sklep.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sklep.Services.RoleService
{
    public class RoleService : IRoleService
    {

        private readonly Shop _shopContext;

        public RoleService(Shop shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task CreateRole(string roleName)
        {
            if(string.IsNullOrEmpty(roleName))
                throw new NullOrEmptyException();


            var role = new Role
            {
                RoleName = roleName,
            };

            var roleExist = _shopContext.Role.Where(x => x.RoleName == role.RoleName).Any();

            if (roleExist)
                throw new AlreadyExistsException(roleName);

            _shopContext.Role.Add(role);
            await _shopContext.SaveChangesAsync();
        }

        public async Task<RoleResponseDto> GetRoleById(int id)
        {
            var roleID = new Role
            {
                RoleId = id,
            };

            var role = await _shopContext.Role.Where(x => x.RoleId == roleID.RoleId).FirstOrDefaultAsync();
            if (role == null)
                throw new NotFoundException("Not Found role");

            var response = new RoleResponseDto
            {
                RoleName = role.RoleName
            };

            return response;
        }
        public async Task<List<Role>> GetAllRoles()
        {
            var roles = await _shopContext.Role.Select(x => x).ToListAsync(); 
            return roles;
        }
    }
}
