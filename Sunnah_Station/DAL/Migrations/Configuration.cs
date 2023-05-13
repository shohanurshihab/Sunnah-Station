namespace DAL.Migrations
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

       /* protected override void Seed(DAL.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            //shihab
            //shihab
            for (int i = 1; i <= 10; i++)
            {
               
                Random rnd = new Random();
                int randomNumber = rnd.Next(100000000, 999999999);
                int randomNumber0 = rnd.Next(1000000, 4999999);
                string randomString = "";
                for (int j = 0; j < 6; j++)
                {
                    char randomChar = (char)rnd.Next('a', 'z' + 1);
                    randomString += randomChar;
                }
                context.Users.AddOrUpdate(new User
                {
                    Id = i,
                    Name = "Admin " + randomString + i,
                    Email = "admin" + i + "@example.com",
                    Address = "123 Main St.",
                    Phone = "+0" + randomNumber.ToString(),
                    Dob = new DateTime(1980, 1, 1),
                    Password = "password" + randomNumber0,
                    Type = (Models.Type)5,
                    Image = "",
                }) ;
            }
            string[] categoryNames = { "Abayas", "Hijabs", "Jilbabs", "Thobes", "Kufis", "Kaftans", "Burkinis", "Niqabs" };

            for (int j = 0; j < 7; j++)
            {
                context.Categories.AddOrUpdate(new Category
                {
                    Id = j,
                    Name = categoryNames[j],
                });
            }
            for (int i = 1; i <= 10; i++)
            {
                Random rnd = new Random();

                string randomString = "";
                for (int j = 0; j < 6; j++)
                {
                    char randomChar = (char)rnd.Next('a', 'z' + 1);
                    randomString += randomChar;
                }
                context.Products.Add(new Product
                {
                    Id = i,
                    Name = "Product " + randomString,
                    Price = (decimal)rnd.NextDouble() * 1000,
                    Quantity = rnd.Next(1, 100),
                    CategoryId = rnd.Next(0, 7),
                    Image = null
                });
            }
            for (int i = 1; i <= 10; i++)
            {
                Random rnd = new Random();
                int cusId = rnd.Next(1, 10);
                int pid = rnd.Next(1, 10);
                string[] statuses = { "New", "Processing", "Shipped", "Delivered" };
                string status = statuses[rnd.Next(statuses.Length)];
                context.Orders.AddOrUpdate(new Order
                {
                    Id = i,
                    CustomerId = cusId,
                    ProductId = pid,
                    Status = status,
                   
                });
            }

            //azraf

            //muntasir

            //riti
        }*/
    }
}
