using System.Text.Json.Serialization;

namespace PythagorasMatrix.Blazor.Models;

public sealed class ContentRow
{
    public string? Name { get; set; }
    [JsonPropertyName("info_ru")] public string? InfoRu { get; set; }
    [JsonPropertyName("info_en")] public string? InfoEn { get; set; }
    [JsonPropertyName("info_de")] public string? InfoDe { get; set; }
    [JsonPropertyName("info_ua")] public string? InfoUa { get; set; }
}
