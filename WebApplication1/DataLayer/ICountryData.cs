using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.DataLayer
{
    public interface ICountryData
    {
        CountryInfo GetCountryInfoById(int countryId);
        List<CountryInfo> GetAllCountriesInfo();
    }
}
