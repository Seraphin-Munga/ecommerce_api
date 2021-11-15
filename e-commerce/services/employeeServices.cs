using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce.DB;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.services
{

    public class employeeServices
    {

        public static int Create(employeeModel model, myDbContext _context)
        {
            var result = _context.Database.ExecuteSqlRaw(
                   "db_employee_creation {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                     model.userID, model.roleID, model.firstName, model.lastName, model.telephone,
                     model.gender, model.email, model.password, model.hasAccess, model.createdBy, model.salary, model.address
                   );

            return result;
        }


        public static async Task<IEnumerable<employeeRetrieval>> List(myDbContext _context)
        {
            var result = _context.employees.FromSqlRaw("EXEC db_employee_list").ToListAsync();

            return await result; ;
        }

        public static async Task<IEnumerable<employeeRetrieval>> Detail(Guid employeeID, myDbContext _context)
        {
            var result = _context.employees.FromSqlRaw("EXEC db_employee_Detail {0}", employeeID).ToListAsync();

            return await result;
        }
    }
}
