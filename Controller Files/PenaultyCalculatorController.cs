using GetStudentData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GetStudentData.Controllers
{
    public class PenaultyCalculatorController : ApiController
    {
        [HttpGet]
        public Country Get(int id)
        {
            Country country = new Country();
            return country.GetCountryWithId(id);

        }


    }
}
