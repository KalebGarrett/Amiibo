using System.Text.Json.Serialization;

namespace Amiibo.Models;

public class NintendoAmiibo
{
    [JsonPropertyName("amiiboSeries")] public string AmiiboSeries { get; set; }

    [JsonPropertyName("character")] public string Character { get; set; }

    [JsonPropertyName("gameSeries")] public string GameSeries { get; set; }

    [JsonPropertyName("head")] public string Head { get; set; }

    [JsonPropertyName("image")] public string Image { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("release")] public Release Release { get; set; }

    [JsonPropertyName("tail")] public string Tail { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; }
}

public class Release
{
    [JsonPropertyName("au")] public string Au { get; set; }

    [JsonPropertyName("eu")] public string Eu { get; set; }

    [JsonPropertyName("jp")] public string Jp { get; set; }

    [JsonPropertyName("na")] public string Na { get; set; }
}

public class Root
{
    [JsonPropertyName("amiibo")] public static List<NintendoAmiibo> NintendoAmiibos { get; set; }
}