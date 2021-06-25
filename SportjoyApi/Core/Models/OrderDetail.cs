using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int OrderNumber { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime BillDate { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
