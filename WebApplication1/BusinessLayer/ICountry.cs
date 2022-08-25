using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.BusinessLayer
{
    public interface ICountry
    {
        List<CountryInfo> GetAllCountriesInfo();
        CountryInfo GetCountryInfoById(int countryId);
    }
}
