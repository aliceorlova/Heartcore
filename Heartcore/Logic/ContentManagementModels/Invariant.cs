using System.Text.Json.Serialization;

namespace Heartcore.Logic.ContentManagementModels
{
    public class Invariant
    {
        [JsonPropertyName("$invariant")]
        public string Value { get; set; }
    }
}

