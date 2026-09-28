using Microsoft.EntityFrameworkCore;

namespace PythagorasMatrix.Blazor.Data;

public sealed class ContentDbContext(DbContextOptions<ContentDbContext> options) : DbContext(options)
{
    public DbSet<ContentEntry> ContentEntries => Set<ContentEntry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContentEntry>(entity =>
        {
            entity.ToTable("ContentEntries");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Category).IsRequired();
            entity.HasIndex(x => new { x.Category, x.SortOrder });
            entity.HasIndex(x => new { x.Category, x.Name });
        });
    }
}
