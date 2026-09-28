namespace PythagorasMatrix.Blazor.Data;

public sealed class ContentEntry
{
    public int Id { get; set; }
    public string Category { get; set; } = "";
    public int SortOrder { get; set; }
    public string? Name { get; set; }
    public string? InfoRu { get; set; }
    public string? InfoEn { get; set; }
    public string? InfoDe { get; set; }
    public string? InfoUa { get; set; }
}
