using Microsoft.EntityFrameworkCore;
using StreamVaultAdmin.Models;

namespace StreamVaultAdmin.Data;

// Entity Framework Core database context for the StreamVault application.
// Manages the database connection and maps application models to database tables.
public class AppDbContext : DbContext
{
    // Initialises the database context using the configured options
    // supplied through dependency injection.
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Represents the collection of all content items stored in the database.
    // Entity Framework uses this property to perform CRUD operations.
    public DbSet<Content> Contents => Set<Content>();

    // Configures the database model when the application starts.
    // Registers all derived content types and creates an index on the
    // Title property to improve search performance.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Register derived content types for Entity Framework.
        modelBuilder.Entity<Movie>();
        modelBuilder.Entity<Series>();
        modelBuilder.Entity<Audiobook>();
        modelBuilder.Entity<MusicAlbum>();

        // Create an index on the Title column to speed up searches.
        modelBuilder.Entity<Content>()
            .HasIndex(c => c.Title);
    }
}