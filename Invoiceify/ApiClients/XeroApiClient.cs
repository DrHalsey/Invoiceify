using Xero.Api.Core;

namespace Invoiceify.ApiClients
{
    public class XeroApiClient
    {
        public XeroCoreApi ConnectToXero()
        {
            return new Private.Core
            {
                UserAgent = "Xero Api"
            };
        }
    }
}