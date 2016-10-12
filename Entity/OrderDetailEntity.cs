using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class OrderDetailEntity
    {
        public string OrderId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string OutSysId { get; set; }
        public string ProductProperty { get; set; }
        public string PackagesInfo { get; set; }
        public string Note { get; set; }
        public string OrderStatus { get; set; }
        public string ProductRef { get; set; }
    }
}
