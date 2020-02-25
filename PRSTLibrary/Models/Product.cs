using System;
using System.Collections.Generic;
using System.Text;

namespace PRSTLibrary.Models {
    public class Product {

        public int Id { get; set; }
        public string PartNbr { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } //remember m
        public string Unit { get; set; }
        public string PhotoPath { get; set; }
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

        public Product() {}

    }
}

