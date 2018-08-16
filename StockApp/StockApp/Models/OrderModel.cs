using System;
using System.Collections.Generic;
using System.Text;

namespace StockApp.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ConfirmDate { get; set; }
        public bool ConfirmStatus { get; set; }
    }
}
