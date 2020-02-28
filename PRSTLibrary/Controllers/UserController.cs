using Microsoft.EntityFrameworkCore;
using PRSTLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSTLibrary.Controllers {
    public class UserController {

        private AppDbContext context = new AppDbContext();

        public IEnumerable<User> GetAll() {
            return context.Users.ToList();
        }
        //IEnumerable read through the collection and any application calling the method would not change
        //IEnumerable provides a list of things and read them like a foreach
        //If you used List instead you could not use the a return type other than list
        //Users can never be null and you will get an empty list if there is nothing

        public User GetByPK(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero");
            return context.Users.Find(id);
        }
        public User Insert(User user) {
            if (user == null) throw new Exception("User cannot be null");
            //edit checking should go here before you add
            context.Users.Add(user);
            CatchException();
            return user;
        }
        //If data can be null the first thing you have to check is if it is null or not

        public bool Update(int id, User user) {
            if (user == null) throw new Exception("User cannot be null");
            if (id != user.Id) throw new Exception("New Id and User Id must match");
            context.Entry(user).State = EntityState.Modified;
            //state tells status of the data in the context I am putting an entry in and I want you to modify it instead of add
            CatchException();
            return true;
        }
        public bool Delete(int id) {
            if (id < 1) throw new Exception("Id must be greater than 0");
            var user = context.Users.Find(id);
            if (user == null) throw new Exception("Id not found");
            return Delete(user);
        }
        public bool Delete(User user) {
            context.Users.Remove(user);
            CatchException();
            return true;
        }

        //for the try catch exceptions refactor the methods
        private void CatchException() {
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("Username must be unique", ex);
            } catch (Exception) {
                throw;
            }
        }

        public User Login(string username, string password) {
            try {
                return context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
            } catch (ArgumentNullException ex) {
                throw new Exception("Cannot be null", ex);
            } catch(InvalidOperationException ex) {
                throw new Exception("Invalid username or password", ex);
            } catch (Exception) {
                throw;
            }
        }
    }
}
