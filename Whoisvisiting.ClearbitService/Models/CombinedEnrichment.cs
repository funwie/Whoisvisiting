using System.Collections.Generic;

namespace Whoisvisiting.ClearbitService.Models
{
    public class CombinedEnrichment
    {
        public Person person { get; set; }
        public Company company { get; set; }
    }

    public class Site
    {
        public List<string> phoneNumbers { get; set; }
        public List<string> emailAddresses { get; set; }
    }

    public class Geo
    {
        public string streetNumber { get; set; }
        public string streetName { get; set; }
        public string subPremise { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string state { get; set; }
        public string stateCode { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Facebook
    {
        public string handle { get; set; }
        public string likes { get; set; }
    }

    public class Linkedin
    {
        public string handle { get; set; }
    }

    public class Twitter
    {
        public string handle { get; set; }
        public string id { get; set; }
        public string bio { get; set; }
        public string followers { get; set; }
        public string following { get; set; }
        public string location { get; set; }
        public string site { get; set; }
        public string avatar { get; set; }
    }

    public class Crunchbase
    {
        public string handle { get; set; }
    }

    public class Identifiers
    {
        public string usEIN { get; set; }
    }

    public class Metrics
    {
        public object alexaUsRank { get; set; }
        public int alexaGlobalRank { get; set; }
        public string employees { get; set; }
        public string employeesRange { get; set; }
        public string marketCap { get; set; }
        public string raised { get; set; }
        public string annualRevenue { get; set; }
        public string estimatedAnnualRevenue { get; set; }
        public string fiscalYearEnd { get; set; }
    }

    public class Parent
    {
        public string domain { get; set; }
    }

    public class UltimateParent
    {
        public string domain { get; set; }
    }
}
