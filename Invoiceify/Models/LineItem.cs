namespace Invoiceify.Models
{
    public class LineItem
    {
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double UnitAmount { get; set; }
        public int AccountCode { get; set; }
        public int DiscountRate { get; set; }
    }
}