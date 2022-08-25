using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIDemo.Controllers
{
    public class ValuesController : ApiController
    {
        public static List<string> studentName= new List<string>() { "Zeehan","Nadeem","Aysha"};
        
       
        // GET api/values
        public IEnumerable<string> Get()
        {
            return studentName;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return studentName[id];
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            studentName.Add(value);

        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            studentName[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            studentName.RemoveAt(id);
        }
    }
}
