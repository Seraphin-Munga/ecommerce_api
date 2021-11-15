using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Models
{
    
    public class employeeModel : userModel
    {
     
        public Guid employeeID { get; set; }
        [Required(ErrorMessage = "salary is required")]
        public decimal salary { get; set; }
        [Required(ErrorMessage = "address is required")]
        public string address { get; set; }

        public employeeModel()
        {
            this.employeeID = this.userID;
        }
    }
}
