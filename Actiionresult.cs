using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ReturnTypeAndStatusCodes.Models;
using System.Linq;
namespace Company.Function
{
    public static class HttpTrigger1
    {
        [FunctionName("HttpTrigger1")]
        public static ActionResult<Employee> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "{Id:int}")] HttpRequest req,
           int Id, ILogger log)
        {
            if (Id == 0)
            {
                return new NoContentResult();
            }
            else
            {
                return new Employee() { Id = 1005, Name = "Anurag", Age = 28, City = "Mumbai", Gender = "Male", Department = "IT" };
            }
        }
    }
}