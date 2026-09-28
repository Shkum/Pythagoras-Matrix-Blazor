using System.Text.Json;
using PythagorasMatrix.Blazor.Models;

namespace PythagorasMatrix.Blazor.Services;

public sealed class JsonContentService : ContentServiceBase
{
    private readonly IWebHostEnvironment _environment;

    public JsonContentService(IWebHostEnvironment environment) => _environment = environment;

    public override async Task EnsureLoadedAsync()
    {
        if (Content is not null) return;
        var path = Path.Combine(_environment.WebRootPath, "data", "content.json");
        await using var stream = File.OpenRead(path);
        Content = await JsonSerializer.DeserializeAsync<ContentRoot>(stream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? new ContentRoot();
    }
}
