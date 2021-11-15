using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace e_commerce.Models
{
    public class productsModel
    {
        [Required(ErrorMessage = "productID is required")]
        public Guid productID { get; set; }
        [Required(ErrorMessage = "employeeID is required")]
        public Guid employeeID { get; set; }
        [Required(ErrorMessage = "productName is required")]
        public string productName { get; set; }
        [Required(ErrorMessage = "quantity is required")]
        public int quantity { get; set; }
        [Required(ErrorMessage = "price is required")]
        public decimal price { get; set; }
        public string imageLink { get; set; }
        public string base64String { get; set; }
        public string description { get; set; }
        public Guid createdBy { get; set; }

    }
}
