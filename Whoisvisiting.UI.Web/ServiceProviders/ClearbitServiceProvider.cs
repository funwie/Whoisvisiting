using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Whoisvisiting.ClearbitService;
using Whoisvisiting.Domain.Entities;
using Whoisvisiting.Infrastructure.Interfaces.CoreServices;
using Whoisvisiting.Infrastructure.Requests;

namespace Whoisvisiting.UI.Web.ServiceProviders
{
    public class ClearbitServiceProvider
    {
        private readonly IConfiguration _configuration;
        private readonly IContactService _contactService;
        private readonly ClearbitAPIService _clearbitAPIService;

        public ClearbitServiceProvider(IConfiguration configuration,
            IContactService contactService,
            ClearbitAPIService clearbitAPIService)
        {
            _configuration = configuration;
            _contactService = contactService;
            _clearbitAPIService = clearbitAPIService;
        }

        public async Task EnrichmentContact(Contact contact)
        {
            var enpointUrl = _configuration.GetValue<string>("ClearbitCombinedAPIEnpoint");
            var apiKey = _configuration.GetValue<string>("ClearbitAPIKey");

            var parameter = $"email=:{contact.Email}";

            var requestUrl = $"{enpointUrl}?{parameter}";

            var enrichmentRequest = new EnrichmentRequest
            {
                Contact = contact,
                RequestUrl = requestUrl,
                APIKey = apiKey
            };

            var enrichedContact = await _clearbitAPIService.EnrichmentContact(enrichmentRequest);

            await _contactService.UpdateAsync(enrichedContact);
        }

    }
}
