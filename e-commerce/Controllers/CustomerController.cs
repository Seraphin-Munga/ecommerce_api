using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_commerce.DB;
using e_commerce.Models;
using e_commerce.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_commerce.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly myDbContext _context;

        public CustomerController(myDbContext context)
        {
            _context = context;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] customerModel model)
        {
            try
            {
                model.password = _Utility_Function.EncryptPassword(model.password);
                model.customerID = Guid.NewGuid();

                var customer = customerServices.Create(model, _context);

                if (customer > 0)
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
                return BadRequest(new { message = ex.Message}); ;
            }

        }


    }
}
