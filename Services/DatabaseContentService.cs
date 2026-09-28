using Microsoft.EntityFrameworkCore;
using PythagorasMatrix.Blazor.Data;
using PythagorasMatrix.Blazor.Models;

namespace PythagorasMatrix.Blazor.Services;

public sealed class DatabaseContentService(IDbContextFactory<ContentDbContext> dbFactory) : ContentServiceBase
{
    public override async Task EnsureLoadedAsync()
    {
        if (Content is not null) return;

        await using var db = await dbFactory.CreateDbContextAsync();
        var rows = await db.ContentEntries
            .AsNoTracking()
            .OrderBy(x => x.Category)
            .ThenBy(x => x.SortOrder)
            .ToListAsync();

        List<ContentRow> Map(string category) => rows
            .Where(x => x.Category == category)
            .OrderBy(x => x.SortOrder)
            .Select(x => new ContentRow
            {
                Name = x.Name,
                InfoRu = x.InfoRu,
                InfoEn = x.InfoEn,
                InfoDe = x.InfoDe,
                InfoUa = x.InfoUa
            })
            .ToList();

        Content = new ContentRoot
        {
            FullInfo = Map("full_info"),
            DifferentInfo = Map("different_info"),
            LinesInfo = Map("lines_info"),
            AboutInfo = Map("about_info"),
            GeneralInfo = Map("general_info")
        };
    }
}
