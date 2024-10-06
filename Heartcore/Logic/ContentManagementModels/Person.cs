using System.Text.Json.Serialization;

namespace Heartcore.Logic.ContentManagementModels
{
    public class Person
    {
        [JsonPropertyName("name")]
        public Invariant Name { get; set; }

        [JsonPropertyName("personName")]
        public Invariant PersonName { get; set; }

        [JsonPropertyName("birthday")]
        public Invariant Birthday { get; set; }

        [JsonPropertyName("country")]
        public Invariant Country { get; set; }

        [JsonPropertyName("image")]
        public Invariant Image { get; set; }

        [JsonPropertyName("shows")]
        public Shows Shows { get; set; }

        [JsonPropertyName("contentTypeAlias")]
        public string ContentTypeAlias { get; set; }

        [JsonPropertyName("parentId")]
        public string ParentId { get; set; }
    }

    public class Shows
    {
        [JsonPropertyName("$invariant")]
        public List<string> Invariant { get; set; } = new List<string>();
    }


}

