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
        public string[] phoneNumbers { get; set; }
        public string[] emailAddresses { get; set; }
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
        //public double lat { get; set; } = 0.0;
        //public double lng { get; set; } = 0.0;
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
        //public int followers { get; set; } = 0;
        //public int following { get; set; } = 0;
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
        //public long alexaUsRank { get; set; } = 0;
        //public long alexaGlobalRank { get; set; } = 0;
        //public int employees { get; set; } = 0;
        public string employeesRange { get; set; }
        //public long marketCap { get; set; } = 0;
        //public long raised { get; set; } = 0;
        //public long annualRevenue { get; set; } = 0;
        public string estimatedAnnualRevenue { get; set; }
        //public int fiscalYearEnd { get; set; } = 0;
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
