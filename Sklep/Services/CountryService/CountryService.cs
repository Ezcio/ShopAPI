using Microsoft.EntityFrameworkCore;
using Sklep.Entities;
using Sklep.Exceptions;
using Sklep.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep.Services.CountryService
{
    public class CountryService : ICountryService
    {
        private readonly Shop _shopContext;

        public CountryService(Shop shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task<CountryResponseDto> GetCountryById(int id)
        {

            var countryID = new Country
            {
                CountryId = id,
            };

            var country = await _shopContext.Country.Where(x => x.CountryId == countryID.CountryId).FirstOrDefaultAsync();
            if (country == null)
                throw new NotFoundException("Not Found Country");

            var response = new CountryResponseDto
            {
                CountryName = country.CountryName
            };

            return response;


        }
        public async Task<List<Country>> GetAllCountryes()
        {
            var countres = await _shopContext.Country.Select(x => x).ToListAsync();
            return countres;   
        }
    }
}
