using System.Text.Json.Serialization;

namespace Whoisvisiting.ClearbitService.Models
{
    public class Category
    {
        public string sector { get; set; }
        public string industryGroup { get; set; }
        public string industry { get; set; }
        public string subIndustry { get; set; }
        public string sicCode { get; set; }
        public string naicsCode { get; set; }
    }
}
