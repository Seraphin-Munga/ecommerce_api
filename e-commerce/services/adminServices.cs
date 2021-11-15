using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce.DB;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.services
{
    public class adminServices
    {
        public static int Create(userModel model, myDbContext _context)
        {
            var result = _context.Database.ExecuteSqlRaw(
              "db_user_creation {0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                model.userID, model.roleID, model.firstName, model.lastName, model.telephone,
                model.gender, model.email, model.password, model.hasAccess, model.createdBy
              );

            return result;
        }


        public static async Task<IEnumerable<adminRetrieval>> List(myDbContext _context)
        {
            var result = _context.admins.FromSqlRaw("EXEC db_user_list").ToListAsync();

            return await result; ;
        }


        public static async Task<IEnumerable<adminRetrieval>> Detail(Guid adminID, myDbContext _context)
        {
            var result = _context.admins.FromSqlRaw("EXEC db_user_detail {0}", adminID).ToListAsync();

            return await result;
        }
    }
}
