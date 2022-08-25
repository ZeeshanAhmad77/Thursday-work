using System.Collections.Generic;
using WebApplication1.DataLayer;
using WebApplication1.Models;

namespace WebApplication1.BusinessLayer
{
    public class Country : ICountry
    {
        ICountryData _countryData;
        public Country(ICountryData countryData)
        {
            _countryData = countryData;
        }
        public List<CountryInfo> GetAllCountriesInfo()
        {
            return _countryData.GetAllCountriesInfo();
        }

        public CountryInfo GetCountryInfoById(int countryId)
        {
            return _countryData.GetCountryInfoById(countryId);
        }
    }
}
