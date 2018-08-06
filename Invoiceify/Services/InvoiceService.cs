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
            var invoices = xeroApi.Invoices.OrderByDescending("UpdatedDateUtc").Find();
            return invoices;
        }

        public Invoice CreateInvoice()
        {
            var xeroApi = _xeroApiClient.ConnectToXero();

            var randomCost = new Random().Next(100, 1000);
            var createdInvoice = xeroApi.Create(new Invoice
            {
                Contact = new Contact { Name = "David's Invoice Inc" },
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
                        Description = "The greatest invoice ever",
                        LineAmount = randomCost,
                        Quantity = 1,
                        UnitAmount = randomCost
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
                //Could not get EF working, here is where the audit would happen
                //db.Invoices.Add(invoice);
                //db.SaveChanges();
            }
        }
    }
}