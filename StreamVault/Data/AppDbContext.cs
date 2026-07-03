using Microsoft.EntityFrameworkCore;
using StreamVaultAdmin.Models;

namespace StreamVaultAdmin.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Content> Contents => Set<Content>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Content>()
                 .HasDiscriminator<string>("ContentType")
                 .HasValue<Movie>("Movie")
                 .HasValue<Series>("Series")
                 .HasValue<Audiobook>("Audiobook")
                 .HasValue<MusicAlbum>("MusicAlbum");

        modelBuilder.Entity<Content>()
            .HasIndex(c => c.Title);
    }
}