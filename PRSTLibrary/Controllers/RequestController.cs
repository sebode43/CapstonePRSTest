using Microsoft.EntityFrameworkCore;
using PRSTLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSTLibrary.Controllers {
    public class RequestController {
        private AppDbContext context = new AppDbContext();

        private void CatchException() {
            try {
                context.SaveChanges();
            } catch (Exception) {
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
            if (request == null) throw new Exception("Request cannot be null");
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
            context.Requests.Remove(request);
            CatchException();
            return true;
        }

        public const string StatusNew = "NEW";
        public const string StatusEdit = "EDIT";
        public const string StatusReview = "REVIEW";
        public const string StatusApproved = "APPROVED";
        public const string StatusRejected = "REJECTED";

        public bool Review(Request request) {
            if (request.Total <= 50) {
                request.Status = StatusApproved;
            } else {
                request.Status = StatusReview;
            }
            return Update(request.Id, request); //use the update that is already been written, do not rewrite code!
        }
        public bool Approve(Request request) {
            request.Status = StatusApproved;
            return Update(request.Id, request);
    }
        public bool Reject(Request request) {
            //needs a RejectionReason
            request.Status = StatusRejected;
            return Update(request.Id, request);
        }
        public IEnumerable<Request> GetReviewsNotOwn(int userId) {
            return context.Requests.Where(x => x.UserId != userId && x.Status == StatusReview).ToList();
        }

    }
}
