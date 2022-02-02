using Sklep.Entities;
using Sklep.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sklep.Services.CountryService
{
    public interface ICountryService
    {
        public Task<CountryResponseDto> GetCountryById(int id);
        public Task<List<Country>> GetAllCountryes();
    }
}
