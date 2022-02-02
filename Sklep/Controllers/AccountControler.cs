using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sklep.Models;
using Sklep.Services;
using System.Threading.Tasks;

namespace Sklep.Controllers
{
    [ApiController]
    [Route("api/account/")] 
    public class AccountControler : ControllerBase
    {
        private readonly ILogger<AccountControler> _logger;
        private readonly IAccountService _registrationService;

        public AccountControler(ILogger<AccountControler> logger, IAccountService registrationService)
        {
            _logger = logger;
            _registrationService = registrationService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserDto dto)
        {
            await _registrationService.RegisterUser(dto);
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginUser([FromBody] LoginUserDto dto)
        {
            var result = await _registrationService.LoginUser(dto);
            return Ok(result);
        }
    }
}
