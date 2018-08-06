using System.Configuration;
using System.IO;
using System.Web.Hosting;
using Xero.Api.Core;
using Xero.Api.Example.Applications.Private;
using Xero.Api.Infrastructure.OAuth;
using Xero.Api.Infrastructure.RateLimiter;
using Xero.Api.Serialization;

namespace Invoiceify.Private
{
    public class Core : XeroCoreApi
    {
        private static readonly DefaultMapper Mapper = new DefaultMapper();
        private static readonly Settings ApplicationSettings = new Settings();

        public Core(bool includeRateLimiter = false) :
            base(ApplicationSettings.Uri,
                new PrivateAuthenticator(HostingEnvironment.MapPath(ApplicationSettings.SigningCertificatePath), ApplicationSettings.SigningCertificatePassword),
                new Consumer(ApplicationSettings.Key, ApplicationSettings.Secret),
                null,
                Mapper,
                Mapper,
                includeRateLimiter ? new RateLimiter() : null)
        {
        }
    }
}