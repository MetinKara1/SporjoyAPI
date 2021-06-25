using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Core.Models
{
    public class Payment
    {
        public Payment()
        {
            Orders = new Collection<Order>();
        }
        public int Id { get; set; }
        public string PaymentType { get; set; }
        public bool Allowed { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
