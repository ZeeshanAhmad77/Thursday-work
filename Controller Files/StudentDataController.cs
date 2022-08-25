using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Caching;
using System.Runtime.Caching;

namespace StudentDataAPI.Controllers
{
    public class StudentDataController : ApiController
    {

        public List<Student> Get()
        {
            ObjectCache cache = MemoryCache.Default;
            if (cache["ListOfStudents"] == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10);
                Student student = new Student();
                List<Student> studenttList = student.GetStudentList();
                var cacheItem = new CacheItem("ListOfStudents", studenttList);
                cache.Add(cacheItem, policy);

            }

            return (List<Student>)cache.Get("ListOfStudents");
        }

        //public Student Get(int id)
        //{
        //    Student student = new Student();
        //    List<Student> studenttList = student.GetStudentList();

        //    return studenttList[id - 1];

        //}
        //// POST api/values
        //[Route("addStudent")]
        //public void Post([FromBody] string name,  string email, string adress)
        //{

        //    Student student = new Student();
        //    student.AddStudent(name, email, adress);


        //}

    }
}
