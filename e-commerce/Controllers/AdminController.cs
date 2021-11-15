using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_commerce.DB;
using e_commerce.Models;
using e_commerce.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_commerce.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly myDbContext _context;

        public AdminController(myDbContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public Task<IEnumerable<adminRetrieval>> Get()
        {
            return adminServices.List(_context);
        }

        // GET api/values/5
        [HttpGet("{adminID}")]
        public async Task<adminRetrieval> Get(Guid adminID)
        {
            var results = await adminServices.Detail(adminID, _context);
            return results.FirstOrDefault();
        }

        // POST api/values
        [AllowAnonymous]
        [HttpPost]
        public bool Post([FromBody]userModel model)
        {
            model.password = _Utility_Function.EncryptPassword(model.password);
            model.userID = Guid.NewGuid();
            model.createdBy = model.userID;  /// need to fix later

            var employee = adminServices.Create(model, _context);

            if (employee > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
