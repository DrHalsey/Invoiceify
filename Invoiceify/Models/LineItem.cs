using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoiceify.Models
{
    public class LineItem
    {
        public string Description { get; set; } = "Consulting services";
        public int Quantity { get; set; } = 10;
        public double UnitAmount { get; set; } = 100.00;
        public int AccountCode { get; set; } = 200;
        public int DiscountRate { get; set; } = 20;
    }
}