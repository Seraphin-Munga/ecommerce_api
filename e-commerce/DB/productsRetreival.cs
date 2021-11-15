using System;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.DB
{
    public class productsRetreival
    {
        [Key]
        public Guid _product_productID { get; set; }
        public string _product_productName { get; set; }
        public decimal _product_price { get; set; }
        public int _product_quantity { get; set; }
        public string _product_imageLink { get; set; }
        public DateTime _product_createdDate { get; set; }
    }
}
