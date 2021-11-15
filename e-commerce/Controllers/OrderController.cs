using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using e_commerce.DB;
using e_commerce.Models;
using e_commerce.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_commerce.Controllers
{
  
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly myDbContext _context;

        public OrderController(myDbContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] orderModel model)
        {
            Random rnd = new Random(10);
            model.orderID = Guid.NewGuid();
            StringBuilder builder = new StringBuilder();
            model.orederNumber = rnd.Next().ToString();

            var orderItems = JsonConvert.DeserializeObject<IEnumerable<productsRetreival>>(model.orderItemString);
            builder.Append("<p style='color: #000000; background-color: #ffffff'>Hi YOUR ODER NUMBER IS " + model.orederNumber + ",</p>");


            try
            {
                var order = orderServices.Create(model, _context);

                if (order > 0)
                {
                    foreach (var item in orderItems)
                    {
                        var mymodel = new orderModel();
                        mymodel.orderItemID = Guid.NewGuid();

                        mymodel.orderID = model.orderID;
                        mymodel.productID = item._product_productID;

                        orderServices.CreateProductItem(mymodel, _context);


                        builder.Append("<p style='color: #000000; background-color: #ffffff'>Your below documents has been Approved by the C3Card KYC System. <br> </ p>");
                        builder.Append("<table border=1 ><tr>");
                        builder.Append("<th style='font-family: Arial; font-size: 10pt;'>" + "Product Name" + "</th>");
                        builder.Append("<th style='font-family: Arial; font-size: 10pt;'>" + "Product Price" + "</th>");
                        builder.Append("<th style='font-family: Arial; font-size: 10pt;'>" + "Product Quatity" + "</th>");
                        builder.Append("</tr>");
                        builder.Append("<tr>");
                        builder.Append("<td>" + item._product_productName + "</td>");
                        builder.Append("<td>" + item._product_price + "</td>");
                        builder.Append("<td>" + item._product_quantity + "</td>");
                        builder.Append("</tr></table>");
                    }

                    _SendEmail.sendEmailAsync(model.customerEmail, builder.ToString(), "Order", true);

                    return Ok();
                }
                else
                {
                    return BadRequest(new { message = "Something went wrong" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
