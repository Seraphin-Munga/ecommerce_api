using System;
namespace e_commerce.Models
{
    public class customerModel
    {
        public Guid customerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string telephone { get; set; }
        public char gender { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
