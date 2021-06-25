using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Core.Models
{
    public class Shipper
    {
        public Shipper()
        {
            Orders = new Collection<Order>();
        }
        public int Id { get; set; }
        public string ShipperCompanyName { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
