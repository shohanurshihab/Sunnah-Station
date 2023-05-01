namespace DAL.Migrations
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.SunnahContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.SunnahContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            for (int i = 1; i <= 10; i++)
            {
                byte[] imageData = null;

                context.Admins.AddOrUpdate(new Admin
                {
                    Id = i,
                    Name = "Admin " + i,
                    Email = "admin" + i + "@example.com",
                    Address = "123 Main St.",
                    Phone = "555-555-1234",
                    Dob = new DateTime(1980, 1, 1),
                    Password = "password" + i,
                    Pic = imageData
                });
            }

            context.SaveChanges();

        }
    }
}
