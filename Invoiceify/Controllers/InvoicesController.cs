using System.Collections.Generic;
using System.Web.Http;
using Xero.Api.Core.Model;
using Invoiceify.Services;

namespace Invoiceify.Controllers
{
    public class InvoicesController : ApiController
    {
        private readonly InvoiceService _invoiceService;

        public InvoicesController()
        {
            _invoiceService = new InvoiceService();
        }

        public IEnumerable<Invoice> GetAllInvoices()
        {
            return _invoiceService.GetAllInvoices();
        }

        public Invoice Create()
        {
            return _invoiceService.CreateInvoice();
        }
    }
}
