using PRSTLibrary;
using PRSTLibrary.Models;
using System;
using System.Linq;

namespace CapstonePRSTest {
    class Program {
        static void Main(string[] args) {
            var context = new AppDbContext();

            AddProduct(context);
            GetAllProducts(context);

        }
        static void AddUser(AppDbContext context) {
            var user = new User { Id = 0, Username = "khudson", Password = "K.Hudson21", Firstname = "Kelly", Lastname = "Hudson", 
                Phone = "555-123-4532", Email = "khudson@mail.com", IsAdmin = true, IsReviewer = true, };
            var user2 = new User { Id = 0, Username = "jclarkson", Password = "ClarkSon_Columbus98", Firstname = "Jon", 
                Lastname = "Clarkson", Phone = "513-155-4545", Email = "jclarkson@mail.com", IsAdmin = false, IsReviewer = true, };
            var user3 = new User { Id = 0, Username = "jshelton", Password = "Jenn-S.123", Firstname = "Jennifer", Lastname = "Shelton", Phone = "555-451-8976", Email = "jshelton@mail.com", IsAdmin = true, IsReviewer = false };
            context.AddRange(user, user2, user3);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 3) throw new Exception("Add user failed");
            return;
        }
        static void GetAllUsers(AppDbContext context) {
            var users = context.Users.ToList();
            users.ForEach(user => Console.WriteLine($"{user.Id}. {user.Firstname} {user.Lastname}"));

        }

        static void AddVendor(AppDbContext context) {
            var vendor = new Vendor { Id = 0, Code = "Amzn", Name = "Amazon", Address = "410 Terry Ave. North", City = "Seattle", State = "WA", Zip = "98109", Phone = "206-266-1000", Email = "headquarters@amazon.com" };
            var vendor2 = new Vendor { Id = 0, Code = "Krgr", Name = "Kroger", Address = "1014 Vine St", City = "Cincinnati", State = "OH", Zip = "45202", Phone = "800-576-4377", Email = "headquarters@kroger.com" };
            var vendor3 = new Vendor { Id = 0, Code = "Wlmrt", Name = "Walmart", Address = "702 SW 8th St", City = "Bentonville", State = "AR", Zip = "72712", Phone = "800-925-6278", Email = "headquarters@walmart.com" };
            context.AddRange(vendor, vendor2, vendor3);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 3) throw new Exception("Add vendor failed");
            return;
        }
        static void GetAllVendors(AppDbContext context) {
            var vendors = context.Vendors.ToList();
            vendors.ForEach(v => Console.WriteLine($"{v.Id}. {v.Name}"));

        }

        static void AddProduct(AppDbContext context) {
            var product = new Product { Id = 0, PartNbr = "1AED", Name = "Echo Dot", Price = 64.99m, Unit = "40", 
                PhotoPath = "EchoDot.jpg", VendorId = 1 };
            var product2 = new Product { Id = 0, PartNbr = "1ORKT12P", Name = "Rice Krispie Treats", Price = 3.99m, 
                Unit = "80", VendorId = 2 };
            var product3 = new Product { Id = 0, PartNbr = "1PCB3P", Name = "Perdue Chicken Breasts", Price = 9.99m, Unit = "30", PhotoPath = "P.Chicken.jpg", VendorId = 3 };
            context.AddRange(product, product2, product3);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 3) throw new Exception("Add Product failed");
            return;
        }
        static void GetAllProducts(AppDbContext context) {
            var products = context.Products.ToList();
            products.ForEach(p => Console.WriteLine($"{p.Id}. {p.Name}"));
        }
    }
}