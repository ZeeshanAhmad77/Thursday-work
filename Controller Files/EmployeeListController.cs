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
using GetStudentData.Models;

namespace GetStudentData.Controllers
{
    public class EmployeeListController : ApiController
    {

        public List<Employee> Get()
        {
            Employee student = new Employee();
            List<Employee> studenttList = student.GetEmployees();
            return studenttList;


            //ObjectCache cache = MemoryCache.Default;
            //if (cache["ListOfEmployee"] == null)
            //{
            //    CacheItemPolicy policy = new CacheItemPolicy();
            //    policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10);
            //    Employee student = new Employee();
            //    List<Employee> studenttList = student.GetEmployees();
            //    var cacheItem = new CacheItem("ListOfEmployee", studenttList);
            //    cache.Add(cacheItem, policy);

            //}

            //return (List<Employee>)cache.Get("ListOfEmployee");
        }
        //[Route("~/api/GetSpecificEmployee")]
        [HttpGet]
        public Employee Get(int id)
        {
            Employee employee = new Employee();
            return employee.GetEmployeeWithId(id);

        }
        [HttpPost]
        //POST:api/EmployeeList
        public void Post([FromBody] Employee employee)
        {
            if (ModelState.IsValid == true)
            {
                Employee emp = new Employee();
                emp.AddEmployee(employee);
            }
            else
            {
                // return Ok(employee);
            }

        }
        [HttpPost]
        [Route("UpdateEmployee/{id}")]
        public void UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (ModelState.IsValid == true)
            {
                Employee emp = new Employee();
                emp.EditEmployee(id, employee);


            }

        }
        [HttpPost]
        [Route("DeleteEmployee/{id}")]
        public void DeleteEmployee(int id)
        {
            if (ModelState.IsValid == true)
            {
                Employee employee = new Employee();
                employee.DeleteEmployee(id);

            }

        }



        //public List<string> Get()
        //{
        //    Employee employee = new Employee();
        //    List<string> employeeList = employee.GetEmployeeList();

        //    return employeeList;
        //}



        //public Employee Get(int id)
        //{
        //    Employee student = new Employee();
        //    List<Student> studenttList = student.GetEmployeeList();

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
