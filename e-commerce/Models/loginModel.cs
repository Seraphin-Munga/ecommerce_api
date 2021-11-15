using System;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class loginModel
    {
        [Required(ErrorMessage = "password is required")]
        public string password { get; set; }
        [Required(ErrorMessage = "email is required")]
        public string email { get; set; }

    }
}
