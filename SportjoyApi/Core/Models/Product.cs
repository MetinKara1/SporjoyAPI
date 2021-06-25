using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Core.Models
{
    public class Product
    {
        public Product()
        {
            Category = new Category();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public bool ProductAvailable { get; set; }
        public string PictureUrl { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
