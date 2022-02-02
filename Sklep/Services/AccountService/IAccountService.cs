using Sklep.Models;
using System.Threading.Tasks;

namespace Sklep.Services
{
    public interface IAccountService
    {
        public Task RegisterUser(RegisterUserDto dto);
        public Task<string> LoginUser(LoginUserDto dto);
    }
}
