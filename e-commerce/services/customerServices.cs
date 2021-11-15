using System;
using e_commerce.DB;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.services
{
    public class customerServices
    {
        public static int Create(customerModel model, myDbContext _context)
        {
            var result = _context.Database.ExecuteSqlRaw(
                   "db_customer_creation {0},{1},{2},{3},{4},{5},{6}",
                      model.customerID, model.firstName,model.lastName,
                      model.telephone, model.gender,model.email,model.password
                   );

            return result;
        }
    }
}
