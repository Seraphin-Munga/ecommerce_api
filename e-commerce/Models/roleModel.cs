using System;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class roleModel
    {
        [Key]
        [Required(ErrorMessage = "role is required")]
        public string name { get; set; }
    }
}
