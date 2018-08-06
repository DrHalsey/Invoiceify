using Invoiceify.Models;
using System.Data.Entity;

namespace Invoiceify.Context
{
    public class InvoiceContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
    }
}