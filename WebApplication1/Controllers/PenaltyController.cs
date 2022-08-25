using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.BusinessLayer;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenaltyController : ControllerBase
    {
        private ICountry _countryManager;
        private IPenaltyCalculator _penaltyCalculator;
        public PenaltyController(ICountry countryManager, IPenaltyCalculator penaltyCalculator)
        {
            _countryManager = countryManager;
            _penaltyCalculator = penaltyCalculator;
        }

        [HttpGet]
        [Route("Calculate")]
        public IActionResult Post([FromQuery] int countryId,[FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var countryinfo = _countryManager.GetCountryInfoById(countryId);
                var penaltyInfo = _penaltyCalculator.Calculate(startDate, endDate, countryinfo);

                return Ok(penaltyInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
