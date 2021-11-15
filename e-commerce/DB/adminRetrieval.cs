using System;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.DB
{
    public class adminRetrieval
    {
        [Key]
        public Guid _user_userID { get; set; }
        public int _user_roleID { get; set; }
        public string _role_name { get; set; }
        public string _user_firstName { get; set; }
        public string _user_lastName { get; set; }
        public string _user_telephone { get; set; }
        public string _user_gender { get; set; }
        public string _user_email { get; set; }

    }
}
