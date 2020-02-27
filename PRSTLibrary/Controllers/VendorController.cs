using Microsoft.EntityFrameworkCore;
using PRSTLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSTLibrary.Controllers {
    public class VendorController {

        private AppDbContext context = new AppDbContext();

        private void CatchException() {
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("Username must be unique", ex);
            } catch (Exception ex) {
                throw;
            }
        }

        public IEnumerable<Vendor> GetAll() {
            return context.Vendors.ToList();
            }
        public Vendor GetbyPk(int id) {
            if (id < 1) throw new Exception("Id has to be greater than 0");
            return context.Vendors.Find(id);
        }
        public Vendor Insert(Vendor vendor) {
            if (vendor == null) throw new Exception("Vendor cannot be null");
            context.Vendors.Add(vendor);
            CatchException();
            return vendor;

        }
        public bool Update(int id, Vendor vendor) {
            if (vendor == null) throw new Exception("Vendor cannot be null");
            if (id != vendor.Id) throw new Exception("New Id and Vendor Id must match");
            context.Entry(vendor).State = EntityState.Modified;
            CatchException();
            return true;
        }
        public bool Delete(int id) {
            if (id < 1) throw new Exception("Id must be greater than 0");
            var vendor = context.Vendors.Find(id);
            if (vendor == null) throw new Exception("Id not found");
            return Delete(vendor);
        }
        public bool Delete(Vendor vendor) {
            context.Vendors.Remove(vendor);
            CatchException();
            return true;
        }
    
    
    }
}
