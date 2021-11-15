using System;
namespace e_commerce.Models
{
    public class orderModel
    {
        public Guid orderID { get; set; }
        public Guid orderItemID { get; set; }
        public Guid productID { get; set; }
        public Guid customerID { get; set; }
        public int  quantity { get; set; }
        public decimal totalPrice { get; set; }
        public string  orederNumber { get; set; }
        public string  orderItemString { get; set; }
        public string customerEmail { get; set; }
    }
}
