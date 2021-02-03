using ErrorHandalingAndLog.LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProcFinal.DAL;
using System.Threading.Tasks;
using ErrorHandalingAndLog.Exceptions;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.IO;

namespace ErrorHandalingAndLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ILogger log;
        private readonly ILoggerManager logger;

        //private readonly ILogger log;

        public EmployeesController(IEmployeeRepository employeeRepository, ILogger<EmployeesController> log, ILoggerManager logger)
        {
            this.employeeRepository = employeeRepository;
            this.log = log;
            this.logger = logger;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            log.LogInformation("this is log info Get action of employee controller");
            var emp = await employeeRepository.GetEmployees();
            return Ok(emp);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                throw new NullReferenceException("Object not initialized");
            }
            catch (Exception)
            {
                throw new NullReferenceException("Object not initialized");
                //throw new Exception("Something goes wrong???");
              
            }
            //var strmRdr = new StreamReader(@"C:\Exception Handling\sample.txt");
            //strmRdr.ReadToEnd();
            return Ok();
            //throw new ArgumentOutOfRangeException();
            //try
            //{
            //    throw new ArgumentOutOfRangeException();
            //    //throw new ArgumentException($"ArgumentException error occured");
            //    //throw new NullReferenceException("null reference exception ...");
            //}
            //catch (Exception ex)
            //{
            //    throw new HttpResponseException(ex);
            //    //throw Request.ThrowHttpException(ex);
            //}

            //throw new ArgumentException($"ArgumentException error occured");
            //throw new ArgumentException($"ArgumentException error occured");
            //throw new Exception("exception occured ...");

            //IDictionary<string, object> sqlParams = new Dictionary<string, object>();
            //sqlParams.Add("Id", id);
            //string spName = "procedure_name_";
            //var emp = employeeRepository.GetEmployeeFromSP(spName, sqlParams);
            //log.LogInformation("this is log info Get action of employee controller");
            //throw new Exception("Exception while fetching all the students from the storage.");
            // throw new SmtpException((SmtpStatusCode)400, "Deo jai tai deo");
            //return Ok();

        }
    }
}
