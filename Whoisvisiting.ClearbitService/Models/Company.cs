using System;
using System.Collections.Generic;

namespace Whoisvisiting.ClearbitService.Models
{
    public class Company
    {
        public string id { get; set; }
        public string name { get; set; }
        public string legalName { get; set; }
        public string domain { get; set; }
        public List<object> domainAliases { get; set; }
        public Site site { get; set; }
        public Category category { get; set; }
        public List<string> tags { get; set; }
        public string description { get; set; }
        public string foundedYear { get; set; }
        public string location { get; set; }
        public string timeZone { get; set; }
        public int utcOffset { get; set; }
        public Geo geo { get; set; }
        public string logo { get; set; }
        public Facebook facebook { get; set; }
        public Linkedin linkedin { get; set; }
        public Twitter twitter { get; set; }
        public Crunchbase crunchbase { get; set; }
        public bool emailProvider { get; set; }
        public string type { get; set; }
        public string ticker { get; set; }
        public Identifiers identifiers { get; set; }
        public string phone { get; set; }
        public Metrics metrics { get; set; }
        public DateTime indexedAt { get; set; }
        public List<string> tech { get; set; }
        public List<string> techCategories { get; set; }
        public Parent parent { get; set; }
        public UltimateParent ultimateParent { get; set; }
    }
}
