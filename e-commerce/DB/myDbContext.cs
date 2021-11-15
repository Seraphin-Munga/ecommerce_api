using System;
using System.ComponentModel.DataAnnotations;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;
namespace e_commerce.DB
{
    
    public class myDbContext: DbContext
    {
        
        public myDbContext(DbContextOptions<myDbContext> options) : base (options){ }
        public DbSet<employeeRetrieval> employees { get; set; }
        public DbSet<adminRetrieval> admins { get; set; }
        public DbSet<accountRetrieval> accounts { get; set; }
        public DbSet<productsRetreival> products { get; set; }
    }

}
