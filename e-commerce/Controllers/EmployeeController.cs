using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using e_commerce.DB;
using e_commerce.Models;
using e_commerce.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_commerce.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly myDbContext _context;

        public EmployeeController(myDbContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public Task<IEnumerable<employeeRetrieval>> Get()
        {

            return employeeServices.List(_context);
        }

        // GET api/values/5
        [HttpGet("{employeeID}")]
        public async Task<employeeRetrieval> Get(Guid employeeID)
        {
            var results = await employeeServices.Detail(employeeID, _context);
            return results.FirstOrDefault();
        }

        // POST api/value
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] employeeModel model)
        {
            try
            {
                model.password = _Utility_Function.EncryptPassword(model.password);
                model.employeeID = Guid.NewGuid();
                var employee = employeeServices.Create(model, _context);
                if (employee > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(new { message = "Something went wrong" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
