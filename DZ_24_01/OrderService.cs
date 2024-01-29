using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_24_01
{
    internal class OrderService
    {
        public void EnsurePopulated()
        {
            using (ApplicationContext db = new ApplicationContext()) 
            {
                if(!db.Products.Any())
                {
                    db.Products.AddRange
                        (
                        new Product
                        {
                            Name="IPhone 12 Pro",
                            CreatedAt = new DateTime(2014,10,20),
                            Price=700
                        },
                         new Product
                        {
                            Name="IPhone 15 Pro",
                            CreatedAt = new DateTime(2024,12,15),
                            Price=1000
                        }
                        );
                }
                db.SaveChanges();
            }
        }
        public Product? GetProduct(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Products.FirstOrDefault(e => e.Id == id);
            }
        }
        public void AddOrder(Order order) 
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }
        public Order? GetOrder(int id) 
        {
            using(ApplicationContext db = new ApplicationContext()) 
            {
                return db.Orders.Include(e=>e.OrderLines).ThenInclude(e=>e.Product).FirstOrDefault(e => e.Id == id);
            }
        }
    }
}
