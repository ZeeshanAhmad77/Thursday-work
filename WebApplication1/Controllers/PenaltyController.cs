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
        //Defining the properties for acessing the classes of business layers

        private ICountry _countryManager;
        private IPenaltyCalculator _penaltyCalculator;
        
        //Dependancy injections for the business layers

        public PenaltyController(ICountry countryManager, IPenaltyCalculator penaltyCalculator)
        {
            _countryManager = countryManager;
            _penaltyCalculator = penaltyCalculator;
        }

        // This function calculate the penaulty amount 
        // this function paremeters from angular start date, end date and country id which is provided by user
        // this function call the to get country information and then passs this to another function which is define in the class
        [HttpGet]
        [Route("Calculate")]
        public IActionResult Post([FromQuery] int countryId,[FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {   //get country information by Id

                var countryinfo = _countryManager.GetCountryInfoById(countryId);

                //Passing start date, end date and country info to calculate penalty amount

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
