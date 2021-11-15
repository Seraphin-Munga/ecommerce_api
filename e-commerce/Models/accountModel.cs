using System;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class accountModel
    {
        [Required(ErrorMessage = "email is required")]
        public string email { get; set; }
        [Required(ErrorMessage = "password is required")]
        public string password { get; set; }
        public bool isAdmin { get; set; }
    }
}
