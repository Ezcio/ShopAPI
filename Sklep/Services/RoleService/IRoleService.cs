using Sklep.Entities;
using Sklep.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sklep.Services.RoleService
{
    public interface IRoleService
    {
        public Task CreateRole(string roleName);
        public Task<RoleResponseDto> GetRoleById(int id);
        public Task<List<Role>> GetAllRoles();
    }
}
