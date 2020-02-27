using Microsoft.EntityFrameworkCore;
using PRSTLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSTLibrary.Controllers {
    class RequestController {
        private AppDbContext context = new AppDbContext();

        private void CatchException() {
            try {
                context.SaveChanges();
            } catch (Exception ex) {
                throw;
            }
        }
        public IEnumerable<Request> GetAll() {
            return context.Requests.ToList();
        }
        public Request GetByPk(int id) {
            if (id < 1) throw new Exception("Id must be greater than 0");
            return context.Requests.Find(id);
        }
        public Request Insert(Request request) {
            if (request == null) throw new Exception("Request cannot be null");
            context.Requests.Add(request);
            CatchException();
            return (request);
        }
        public bool Update(int id, Request request) {
            if (request == null) throw new Exception("Reuqest cannot be null");
            if (id != request.Id) throw new Exception("New Id and Request Id must match");
            context.Entry(request).State = EntityState.Modified;
            CatchException();
            return true;
        }
        public bool Delete(int id) {
            if (id < 1) throw new Exception("Id must be greater than 0");
            var request = context.Requests.Find(id);
            if (request == null) throw new Exception("Id cannot be found");
            return Delete(request);
        }
        public bool Delete(Request request) {
            context.Remove(request);
            CatchException();
            return true;
        }

    }
}
