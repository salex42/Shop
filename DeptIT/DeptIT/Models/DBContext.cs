using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeptIT.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }

    class RequestInitializer : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext db)
        {
            db.Products.Add(new Product { Id = 1, Name = "Колье", Cost = 2500, Type = "Украшение" });
            db.Products.Add(new Product { Id = 2, Name = "Телевизор", Cost = 25000, Type = "Электроника" });
            db.Products.Add(new Product { Id = 3, Name = "Брош", Cost = 500, Type = "Украшение" });

            base.Seed(db);
        }
    }
}