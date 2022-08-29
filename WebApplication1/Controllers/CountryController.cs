using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.BusinessLayer;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        // Dependency Injection for the   for the business layers

        private ICountry _countryManager;
        public CountryController(ICountry countryManager)
        {
            _countryManager = countryManager;
        }

        // Get List of All countries

        [HttpGet]
        [Route("GetListofCountries")]
        public IActionResult Get()
        {
            try
            {
                var countryinfoList = _countryManager.GetAllCountriesInfo();
                return Ok(countryinfoList);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        // Get Info  of a country by Id
        [HttpGet]
        [Route("GetCountryInfo")]
        public IActionResult Get(int countryId)
        {
            try
            {
                var countryinfo = _countryManager.GetCountryInfoById(countryId);
                return Ok(countryinfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
