using System.Text.Json.Serialization;

namespace PythagorasMatrix.Blazor.Models;

public sealed class ContentRoot
{
    [JsonPropertyName("full_info")] public List<ContentRow> FullInfo { get; set; } = [];
    [JsonPropertyName("different_info")] public List<ContentRow> DifferentInfo { get; set; } = [];
    [JsonPropertyName("lines_info")] public List<ContentRow> LinesInfo { get; set; } = [];
    [JsonPropertyName("about_info")] public List<ContentRow> AboutInfo { get; set; } = [];
    [JsonPropertyName("general_info")] public List<ContentRow> GeneralInfo { get; set; } = [];
}
