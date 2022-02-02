using System;

namespace Sklep.Entities
{

    public class User
    {
        public Guid UserId { get; set; }
        public string Mail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Password { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }


    }
}
