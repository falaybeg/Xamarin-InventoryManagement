using System;
using System.Collections.Generic;
using System.Text;

namespace StockApp.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal PurchasingPrice { get; set; }
        public int StockAmount { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}
