using PRSTLibrary;
using PRSTLibrary.Models;
using System;
using System.Linq;

namespace CapstonePRSTest {
    class Program {
        static void Main(string[] args) {
            var context = new AppDbContext();

            GetAllUsers(context);

        }
        static void AddUser(AppDbContext context) {
            var user = new User { Id = 0, Username = "khudson", Password = "K.Hudson21", Firstname = "Kelly", Lastname = "Hudson", Phone = "555-123-4532", Email = "khudson@mail.com", IsAdmin = true, IsReviewer = true, };
            var user2 = new User { Id = 0, Username = "jclarkson", Password = "ClarkSon_Columbus98", Firstname = "Jon", Lastname = "Clarkson", Phone = "513-155-4545", Email = "jclarkson@mail.com", IsAdmin = false, IsReviewer = true, };
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

    }
}
