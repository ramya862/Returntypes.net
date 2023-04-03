using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using employee.models;
using System.Collections.Generic;
using System.Linq;
//
namespace Company.Function
{
    public static class HttpTrigger1
    {
        [FunctionName("HttpTrigger1")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "{empbyid/{Id}}")] HttpRequest req,
            int Id,ILogger log)
        {
                 var listEmployees = new List<Employee>()
                    {
                        new Employee(){ Id = 1001, Name = "Anurag", Age = 28, Gender = "Male"},
                        new Employee(){ Id = 1002, Name = "Pranaya", Age = 28, Gender = "Male"},
                        new Employee(){ Id = 1003, Name = "Priyanka", Age = 27, Gender = "Female"},
                    };
                  var employee = listEmployees.FirstOrDefault(emp => emp.Id == Id);
            if (employee != null)
            {
                return new OkObjectResult(employee);
            }
            else
            {
                return new NotFoundResult();
            }
        }

    }
}
