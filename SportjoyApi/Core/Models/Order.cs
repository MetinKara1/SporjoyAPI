using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Core.Models
{
    public class Order
    {
        public Order()
        {
            Customer = new Customer();
            Payment = new Payment();
            Shipper = new Shipper();
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrderNumber { get; set; }
        public int PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public int ShipperId { get; set; }
        public int SalesTax { get; set; }
        public string TransactStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Shipper Shipper { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
