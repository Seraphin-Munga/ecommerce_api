using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using e_commerce.DB;
using e_commerce.Models;
using e_commerce.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_commerce.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IWebHostEnvironment _environment;
        private readonly myDbContext _context;

        public ProductController(IWebHostEnvironment environment, myDbContext context)
        {

            _environment = environment;
            _context = context;
        }

        // GET: api/values
        [AllowAnonymous]
        [HttpGet]
        public Task<IEnumerable<productsRetreival>> Get()
        {
            return productServices.List(_context);
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{productID}")]
        public async Task<productsRetreival> Get(Guid productID)
        {
            var product = await productServices.Detail(productID, _context);

            return product.FirstOrDefault();
        }

        // POST api/values

        [HttpPost]
        public IActionResult Post([FromBody] productsModel model)
        {

            try
            {
                model.productID = Guid.NewGuid();
                string ImageName = model.productID + ".jpg";
                model.imageLink = ImageName;

                string serverFolder = Path.Combine(_environment.WebRootPath, ImageName);
                byte[] imageBytes = Convert.FromBase64String(model.base64String);
                System.IO.File.WriteAllBytes(serverFolder, imageBytes);
                var product = productServices.Create(model, _context);


                if (product > 0)
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
