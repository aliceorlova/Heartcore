using System.Text.Json.Serialization;

namespace Heartcore.Logic.ContentManagementModels
{
    public class Show
    {
        [JsonPropertyName("name")]
        public Invariant Name { get; set; }

        [JsonPropertyName("showName")]
        public Invariant ShowName { get; set; }

        [JsonPropertyName("contentTypeAlias")]
        public string ContentTypeAlias { get; set; }

        [JsonPropertyName("parentId")]
        public string ParentId { get; set; }
    }
}

