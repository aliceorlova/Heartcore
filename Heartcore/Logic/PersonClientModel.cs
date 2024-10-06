using System.Text.Json.Serialization;

namespace Heartcore.Logic
{
	public class PersonClientModel
	{
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("birthday")]
        public DateTime Birthday { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("shows")]
        public List<string> Shows { get; set; }
    }
}

