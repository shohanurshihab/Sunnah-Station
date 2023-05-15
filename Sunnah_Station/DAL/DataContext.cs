using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CustomerService> CustomerServices { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
    }
}
