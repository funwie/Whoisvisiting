using System;
using System.Text.Json;
using System.Threading.Tasks;
using Whoisvisiting.ClearbitService.Models;
using Whoisvisiting.Domain.Entities;
using Whoisvisiting.Infrastructure.Requests;

namespace Whoisvisiting.ClearbitService
{
    public class ClearbitAPIService
    {
        public async Task<Contact> EnrichmentContact(EnrichmentRequest enrichmentRequest)
        {
            try
            {
                var jsonResponse = await WebClient.GetAsync(enrichmentRequest.RequestUrl, enrichmentRequest.APIKey);
                var combinedEnrichment = DeserializeCombinedEnrichment(jsonResponse);
                return MapContact(combinedEnrichment, enrichmentRequest.Contact);


            } catch(Exception ex)
            {
                // log fail and hangle
                return enrichmentRequest.Contact;
            }
            
        }

        private Contact MapContact(CombinedEnrichment combinedEnrichment, Contact contact)
        {
            if (combinedEnrichment == null)
            {
                return contact;
            }

            if (combinedEnrichment.person != null)
            {
                contact.Avatar = combinedEnrichment.person.Avatar;
                contact.Bio = combinedEnrichment.person.Bio;

                if (combinedEnrichment.person.Employment != null)
                {
                    contact.Title = combinedEnrichment.person.Employment.Tittle;
                }
               
            }
           
            
            if (combinedEnrichment.company != null)
            {
                contact.Description = combinedEnrichment.company.description;
                contact.Tags = string.Join(",", combinedEnrichment.company.tags);
                contact.Logo = combinedEnrichment.company.logo;

                if (combinedEnrichment.company.category != null)
                {
                    contact.Industry = combinedEnrichment.company.category.industry;
                }
            }
            return contact;
        }

        private CombinedEnrichment DeserializeCombinedEnrichment(string enrichmentJson)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    WriteIndented = true
                };
                return JsonSerializer.Deserialize<CombinedEnrichment>(enrichmentJson, options);
                
            } 
            catch (JsonException ex)
            {
                // log fail and handle
                return null;
            }
            catch (ArgumentNullException ex)
            {
                // log fail and handle
                return null;
            }

        }


    }
}
