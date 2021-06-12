using System;
using System.Collections.Generic;

#nullable disable

namespace Lab_LINQ.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public int? UnitsInStock { get; set; }

        public virtual Category Category { get; set; }
    }
}
