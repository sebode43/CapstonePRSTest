using PRSTLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSTLibrary.Controllers {
    public class UserController {

        private AppDbContext context = new AppDbContext();

        public List<User> GetAllUsers() {
            var users = context.Users.ToList();
            users.ForEach(user => Console.WriteLine($"{user.Id}. {user.Firstname} {user.Lastname}"));
            if (users == null) throw new Exception("No users found");
            return users;
        }

        public bool UpdateUser(User user) {
            var updateduser = context.Users.Find(user.Id);
            if (updateduser == null) throw new Exception("No users found to update");
            updateduser.Username = user.Username;
            updateduser.Password = user.Password;
            updateduser.Firstname = user.Firstname;
            updateduser.Lastname = user.Lastname;
            updateduser.Phone = user.Phone;
            updateduser.Email = user.Email;
            updateduser.IsReviewer = user.IsReviewer;
            updateduser.IsAdmin = user.IsAdmin;
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 1) throw new Exception("Cannot update users");
            Console.WriteLine("User updated");
            return true;
        }
    }
  



}
