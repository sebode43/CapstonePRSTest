using Microsoft.EntityFrameworkCore;
using PRSTLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSTLibrary.Controllers {
    public class RequestLineController {
        private AppDbContext context = new AppDbContext();

        private void CatchException() {
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("Quantity length is too long", ex);
            } catch (Exception ex) {
                throw;
            }
        }
        public IEnumerable<RequestLine> GetAll() {
            return context.RequestLines.ToList();
        }
        public RequestLine GetByPk(int id) {
            if (id < 1) throw new Exception("Id must be greater than 0");
            return context.RequestLines.Find(id);
        }
        public RequestLine Insert(RequestLine requestLine) {
            if (requestLine == null) throw new Exception("Request cannot be null");
            context.RequestLines.Add(requestLine);
            CatchException();
            return requestLine;
        }
        public bool Update(int id, RequestLine requestLine) {
            if (requestLine == null) throw new Exception("Request cannot be null");
            if (id != requestLine.Id) throw new Exception("New Id and Request Id must match");
            context.Entry(requestLine).State = EntityState.Modified;
            CatchException();
            return true;
        }
        public bool Delete(int id) {
            if (id < 1) throw new Exception("Id must be greater than 0");
            var requestLine = context.RequestLines.Find(id);
            if (requestLine == null) throw new Exception("Id cannot be found");
            return Delete(requestLine);
        }
        public bool Delete(RequestLine requestLine) {
            context.RequestLines.Remove(requestLine);
            CatchException();
            return true;
        }
    }
}
