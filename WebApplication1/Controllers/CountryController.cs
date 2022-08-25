using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.BusinessLayer;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountry _countryManager;
        public CountryController(ICountry countryManager)
        {
            _countryManager = countryManager;
        }

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
