using Microsoft.EntityFrameworkCore;
using PythagorasMatrix.Blazor.Components;
using PythagorasMatrix.Blazor.Data;
using PythagorasMatrix.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddSingleton<PythagorasCalculator>();

// Change ContentProvider in appsettings.json to "Json" or "Database".
var contentProvider = builder.Configuration["ContentProvider"] ?? "Json";

if (contentProvider.Equals("Database", StringComparison.OrdinalIgnoreCase))
{
    var connectionString = builder.Configuration.GetConnectionString("ContentDatabase")
        ?? "Data Source=Data/pythagoras-content.db";

    builder.Services.AddPooledDbContextFactory<ContentDbContext>(options =>
        options.UseSqlite(connectionString));
    builder.Services.AddScoped<IContentService, DatabaseContentService>();
}
else if (contentProvider.Equals("Json", StringComparison.OrdinalIgnoreCase))
{
    builder.Services.AddScoped<IContentService, JsonContentService>();
}
else
{
    throw new InvalidOperationException(
        $"Unsupported ContentProvider '{contentProvider}'. Use 'Json' or 'Database'.");
}

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();
