using System;
using e_commerce.DB;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.services
{
    public class orderServices
    {

        public static int Create(orderModel model, myDbContext _context)
        {
            var result = _context.Database.ExecuteSqlRaw(
              "db_order_creation {0},{1},{2},{3},{4}",
                model.orderID, model.customerID, model.quantity, model.totalPrice, model.orederNumber
              );

            return result;
        }


        public static int CreateProductItem(orderModel model, myDbContext _context)
        {
            var result = _context.Database.ExecuteSqlRaw(
              "db_orderitem_creation {0},{1},{2}",
                model.orderItemID, model.orderID, model.productID
              );

            return result;
        }

    }
}
