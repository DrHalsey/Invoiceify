using Invoiceify.ApiClients;
using Invoiceify.Context;
using System;
using System.Collections.Generic;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;

namespace Invoiceify.Services
{
    public class InvoiceService
    {
        private readonly XeroApiClient _xeroApiClient;

        public InvoiceService()
        {
            _xeroApiClient = new XeroApiClient();
        }

        public IEnumerable<Invoice> GetAllInvoices()
        {
            var xeroApi = _xeroApiClient.ConnectToXero();
            var invoices = xeroApi.Invoices.OrderByDescending("Date").Find();
            return invoices;
        }

        public Invoice CreateInvoice()
        {
            var xeroApi = _xeroApiClient.ConnectToXero();

            var createdInvoice = xeroApi.Create(new Invoice
            {
                Contact = new Contact { Name = "ZYX Bank" },
                Type = InvoiceType.AccountsPayable,
                Date = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(10),
                LineAmountTypes = LineAmountType.Exclusive,
                Status = InvoiceStatus.Draft,
                Number = null,
                LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        AccountCode = "200",
                        Description = "Pony",
                        LineAmount = 10m,
                        Quantity = 4,
                        UnitAmount = 395
                    }
                }
            });

            if (createdInvoice.ValidationStatus == 0)
            {
                CreateAuditRecord(createdInvoice);
                return createdInvoice;
            }

            return new Invoice();
        }

        public void CreateAuditRecord(Invoice createdInvoice)
        {
            var invoice = new Models.Invoice
            {
                InvoiceId = createdInvoice.Id,
                ContactId = createdInvoice.Contact.Id,
                Total = createdInvoice.Total,
                TotalTax = createdInvoice.TotalTax,
                SubTotal = createdInvoice.SubTotal,
                DueDate = createdInvoice.DueDate,
                Date = createdInvoice.Date,
                ValidationStatus = createdInvoice.ValidationStatus.ToString()
            };

            using (var db = new InvoiceContext())
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
            }
        }
    }
}