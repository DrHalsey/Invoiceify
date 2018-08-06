using System;

namespace Invoiceify.Models
{
    public class Invoice
    {
        public Guid InvoiceId { get; set; }
        public Guid ContactId { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Total { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? SubTotal { get; set; }
        public string ValidationStatus { get; set; }

        //Not sure what the best object structure is for just recording audit data to DB
        //public string Type { get; set; } ;
        //public LineItem[] LineItems { get; set; }
        //public List<LineItem> LineItems { get; set; }
        //public List<LineItem> Items { get; set; }
        //public string Reference { get; set; }
        //public string Url { get; set; }
        //public Guid? BrandingThemeId { get; set; }
        //public bool? HasAttachments { get; set; }
        //public decimal? AmountCredited { get; set; }
        //public decimal? AmountPaid { get; set; }
        //public decimal? AmountDue { get; set; }
        //public DateTime? FullyPaidOnDate { get; set; }
        //public decimal? CurrencyRate { get; set; }
        //public string CurrencyCode { get; set; }
        //public decimal? TotalDiscount { get; set; }
        //public DateTime? PlannedPaymentDate { get; set; }        
        //public DateTime? ExpectedPaymentDate { get; set; }
        //public string Number { get; set; }
    }
}