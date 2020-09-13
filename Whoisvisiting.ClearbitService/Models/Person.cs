using System.Text.Json.Serialization;

namespace Whoisvisiting.ClearbitService.Models
{
    public class Person
    {
        [JsonPropertyName("bio")]
        public string Bio { get; set; }

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        [JsonPropertyName("employment")]
        public Employment Employment { get; set; }
    }

    public class Employment
    {
        [JsonPropertyName("tittle")]
        public string Tittle { get; set; }
    }
}
