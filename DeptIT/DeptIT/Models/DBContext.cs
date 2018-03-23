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
        public DbSet<Ordert> Orders { get; set; }
    }

    class RequestInitializer : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext db)
        {
            db.Products.Add(new Product { Id = 1, Name = "Колье", Cost = 2500, Type = "Украшение" });
            db.Products.Add(new Product { Id = 2, Name = "Телевизор", Cost = 25000, Type = "Электроника" });
            db.Products.Add(new Product { Id = 3, Name = "Брош", Cost = 500, Type = "Украшение" });
            db.Products.Add(new Product { Id = 4, Name = "Брошка 1", Cost = 500, Type = "Украшение" });
            db.Products.Add(new Product { Id = 5, Name = "Брошка 12", Cost = 500, Type = "Украшение" });
            db.Products.Add(new Product { Id = 6, Name = "Брошка 13", Cost = 500, Type = "Украшение" });
            db.Products.Add(new Product { Id = 7, Name = "Брошка 111", Cost = 500, Type = "Украшение" });
            db.Products.Add(new Product { Id = 8, Name = "Брошка 1768", Cost = 500, Type = "Украшение" });

            db.Orders.Add(new Ordert { OrdertId = 1, Client = "Ivanov", ProductId = 1, Count = 2 });

            base.Seed(db);
        }
    }
}