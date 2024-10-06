using System.Text.Json.Serialization;

namespace Heartcore.Logic.Models;

public class Person
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("country")]
    public Country Country { get; set; }

    [JsonPropertyName("birthday")]
    public string Birthday { get; set; }

    [JsonPropertyName("deathday")]
    public string? Deathday { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("image")]
    public Image Image { get; set; }

    [JsonPropertyName("updated")]
    public int Updated { get; set; }

    [JsonPropertyName("_embedded")]
    public Embedded Embedded { get; set; }
}

public class Country
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("timezone")]
    public string Timezone { get; set; }
}

public class Image
{
    [JsonPropertyName("medium")]
    public string Medium { get; set; }

    [JsonPropertyName("original")]
    public string Original { get; set; }
}

public class Embedded
{
    [JsonPropertyName("castcredits")]
    public List<CastCredit> CastCredits { get; set; }
}

public class CastCredit
{
    [JsonPropertyName("_links")]
    public Links Links { get; set; }
}

public class Links
{
    [JsonPropertyName("show")]
    public Show Show { get; set; }
}

public class Show
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}
