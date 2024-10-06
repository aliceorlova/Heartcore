using System.Text.Json.Serialization;

namespace Heartcore.Logic.GraphQLModels
{
    public class AllPerson
    {
        [JsonPropertyName("edges")]
        public List<Edge> Edges { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("allPerson")]
        public AllPerson AllPerson { get; set; }
    }

    public class Edge
    {
        [JsonPropertyName("node")]
        public Node Node { get; set; }
    }

    public class Node
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("birthday")]
        public DateTime Birthday { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("shows")]
        public List<Show>? Shows { get; set; }
    }

    public class Person
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public class Show
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}