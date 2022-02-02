using System;
using System.ComponentModel.DataAnnotations;

namespace Sklep.Models
{
    public class RegisterUserDto
    {
        public string Mail { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CountryId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int RoleId { get; set; } = 1;

    }
}
