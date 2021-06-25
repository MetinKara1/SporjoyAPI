using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Core.Models
{
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
