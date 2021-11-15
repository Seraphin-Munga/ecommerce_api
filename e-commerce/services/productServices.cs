using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce.DB;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.services
{
    public class productServices
    {
        public static int Create(productsModel model, myDbContext _context)
        {
            var result = _context.Database.ExecuteSqlRaw(
              "db_product_creation {0},{1},{2},{3},{4},{5},{6},{7}",
               model.productID, model.employeeID, model.productName,model.price,
               model.quantity,model.imageLink,model.description,model.createdBy
              );

            return result;
        }

        public static async Task<IEnumerable<productsRetreival>> List(myDbContext _context)
        {
            var result = _context.products.FromSqlRaw("EXEC db_product_list").ToListAsync();

            return await result; ;
        }

        public static async Task<IEnumerable<productsRetreival>> Detail(Guid productID, myDbContext _context)
        {
            var result = _context.products.FromSqlRaw("EXEC db_product_detail {0}", productID).ToListAsync();

            return await result;
        }

    }
}
