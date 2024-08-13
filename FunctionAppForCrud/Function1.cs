using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CRUDRepository.Interface;
using System.Security.AccessControl;
using System.Collections.Generic;
using CRUDModels;
using System.Linq;
using CRUDRepository;

namespace FunctionAppForCrud
{
    public class Function1
    {
        private readonly ICrudReposetory _crudReposetory;
        public Function1(ICrudReposetory crudReposetory)
        {
            _crudReposetory = crudReposetory;
        }


        [FunctionName("GetAllDetails")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get",  Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            List<CreateViewModel> createViewModels = new List<CreateViewModel>();
            createViewModels= _crudReposetory.GetAllStudent().ToList();

            return new OkObjectResult(createViewModels);
        }


        [FunctionName("UpdateDetails")]
        public async Task<IActionResult> UpdateDetails(
           [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
           ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var student = JsonConvert.DeserializeObject<CreateViewModel>(requestBody);
                _crudReposetory.UpdateStudent(student);
                return new OkObjectResult(student);
            }
            catch (Exception)
            {

                throw;
            }

           

           
        }



        [FunctionName("CreateDetails")]
          public async Task<IActionResult> CreateDetails(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
             ILogger log)
            {
            log.LogInformation("C# HTTP trigger function processed a request.");

            
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            CreateViewModel student = JsonConvert.DeserializeObject<CreateViewModel>(requestBody);
            _crudReposetory.AddStudent(student);

            return new OkObjectResult(student);
          }



        [FunctionName("DeactivateDetails")]
        public async Task<IActionResult> DeactivateDetails(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
             ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                int id = JsonConvert.DeserializeObject<int>(requestBody);
                _crudReposetory.DeleteStudent(id);
                return new OkObjectResult(id);
            }
            catch (Exception)
            {

                throw;
            }


            
        }



        [FunctionName("GetDataBasedOnId")]
        public async Task<IActionResult> GetDataBasedOnId(
           [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            int studentId = JsonConvert.DeserializeObject<int>(requestBody);
            var result = _crudReposetory.GetStudentData(studentId);
            return new OkObjectResult(result);
        }

    }
}
