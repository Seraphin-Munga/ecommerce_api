using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce.DB;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.services
{
    public class accountServices
    {
        public static async Task<IEnumerable<accountRetrieval>> login(accountModel model, myDbContext _context)
        {
            var result = _context.accounts.FromSqlRaw("EXEC db_user_login {0},{1}", model.email, model.password).ToListAsync();

            return await result;
        }

        public static async Task<IEnumerable<accountRetrieval>> customerLogin(accountModel model, myDbContext _context)
        {
            var result = _context.accounts.FromSqlRaw("EXEC db_customer_login {0},{1}", model.email, model.password).ToListAsync();

            return await result;
        }
    }
}
