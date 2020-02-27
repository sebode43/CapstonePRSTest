using Microsoft.EntityFrameworkCore;
using PRSTLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSTLibrary.Controllers {
    public class ProductController {
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
        public IEnumerable<Product> GetAll() {
            return context.Products.ToList();
        }
        public Product GetbyPk(int id) {
            if (id < 1) throw new Exception("Id must be greater than 0");
            return context.Products.Find(id);
        }
        public Product Insert(Product product) {
            if (product == null) throw new Exception("Product cannot be null");
            context.Products.Add(product);
            CatchException();
            return product;
        }
        public bool Update(int id, Product product) {
            if (product == null) throw new Exception("Product cannot be null");
            if (id != product.Id) throw new Exception("New Id and Product Id must match");
            context.Entry(product).State = EntityState.Modified;
            CatchException();
            return true;
        }
        public bool Delete(int id) {
            if (id < 1) throw new Exception("Id must be greater than 0");
            var product = context.Products.Find(id);
            if (product == null) throw new Exception("Id not found");
            return Delete(product);
        }
        public bool Delete(Product product) {
            context.Products.Remove(product);
            CatchException();
            return true;
        }
    }
}
