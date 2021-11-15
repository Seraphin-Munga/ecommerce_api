using System;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class userModel
    {  
      
        public Guid userID { get; set; }
        [Required(ErrorMessage = "roleID is required")]
        public byte roleID { get; set; }
        [Required(ErrorMessage = "first name is required")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "last name is required")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "last name is required")]
        public char gender { get; set; }
        [Required(ErrorMessage = "password is required")]
        public string password { get; set; }
        [Required(ErrorMessage = "email is required")]
        public string email { get; set; }
        [Required(ErrorMessage = "telephone is required")]
        public bool hasAccess { get; set; }
        public string telephone { get; set; }
        public Guid createdBy { get; set; }
        public Guid editedBy { get; set; }

        public userModel()
        {
            this.userID = Guid.NewGuid();
            this.hasAccess = true;
        }
    }
}
