using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sklep.Models;
using Sklep.Services.CountryService;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sklep.Controllers
{
    [ApiController]
    [Route("api/country/")]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        //private readonly IRoleService _roleService;
        private readonly ICountryService _countryService;


        public CountryController(ILogger<CountryController> logger, ICountryService countryServie)
        {
            _logger = logger;
            _countryService = countryServie;
        }

        [HttpGet("GetCountryById/{id}")]
        public async Task<ActionResult<string>> GetCountryById(int id)
        {
            var response = await _countryService.GetCountryById(id);

            return Ok(JsonSerializer.Serialize(response));
        }

        [Authorize]
        [HttpGet("GetAllCountryes")]
        public async Task<ActionResult<string>> GetAllCountryes()
        {
            var result = await _countryService.GetAllCountryes();
            return Ok(JsonSerializer.Serialize(result));
        }


    }
}

