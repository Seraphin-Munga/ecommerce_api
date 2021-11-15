using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using e_commerce.DB;
using e_commerce.Models;
using e_commerce.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_commerce.Controllers
{

    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly myDbContext _context;
        public IEnumerable<accountRetrieval> users;

        public AccountController(myDbContext context)
        {
            _context = context;
        }

        // POST api/values
        [HttpPost("authenticate")]
        public async Task<IActionResult> Post([FromBody] accountModel model)
        {

            model.password = _Utility_Function.EncryptPassword(model.password);
            if (model.isAdmin == true)
            {
                users = await accountServices.login(model, _context);
            }
            else
            {
                users = await accountServices.customerLogin(model, _context);
            }

            var userDetail = users.FirstOrDefault();
            if (userDetail == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("Shiv@12323443435546Shiv@434353535353");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
           {
                    new Claim(ClaimTypes.Name, userDetail._user_userID.ToString())
           }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                userID = userDetail._user_userID,
                firstName = userDetail._user_firstName,
                lastName = userDetail._user_lastName,
                roleId = userDetail._user_roleID,
                gender = userDetail._user_gender,
                telephone = userDetail._user_telephone,
                email = userDetail._user_email,
                token = tokenString
            });

        }

    }
}
