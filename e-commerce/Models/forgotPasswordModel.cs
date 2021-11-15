using System;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class forgotPasswordModel
    {
        [Required(ErrorMessage = "email is required")]
        public string email { get; set; }
    }
}
