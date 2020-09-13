using Whoisvisiting.Domain.Entities;

namespace Whoisvisiting.Infrastructure.Requests
{
    public class EnrichmentRequest
    {
        public Contact Contact { get; set; }
        public string RequestUrl { get; set; }
        public string APIKey { get; set; }
    }
}
