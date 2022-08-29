using System.Collections.Generic;
using WebApplication1.DataLayer;
using WebApplication1.Models;

namespace WebApplication1.BusinessLayer
{
    public class Country : ICountry
    {
        ICountryData _countryData;


        //Dependency Injection by Interface

        public Country(ICountryData countryData)
        {
            _countryData = countryData;
        }

        // get list of Country Info from Data Layers as a list of CountryInfo

        public List<CountryInfo> GetAllCountriesInfo()
        {
            return _countryData.GetAllCountriesInfo();
        }

        //Grt the info of a country based on the Id of the country
        public CountryInfo GetCountryInfoById(int countryId)
        {
            return _countryData.GetCountryInfoById(countryId);
        }
    }
}
