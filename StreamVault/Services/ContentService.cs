using Microsoft.EntityFrameworkCore;
using StreamVaultAdmin.Data;
using StreamVaultAdmin.Models;

namespace StreamVaultAdmin.Services;

// Provides the business logic for managing content within the
// StreamVault catalogue. This service performs CRUD operations
// using Entity Framework Core and separates database access
// from the MVC controllers.
public class ContentService : IContentService
{
    // Database context used to access the application's data.
    private readonly AppDbContext _context;

    // Creates a new instance of the ContentService.
    public ContentService(AppDbContext context)
    {
        _context = context;
    }

    // Retrieves all content items from the database, with optional
    // filtering by title and content type.
    public async Task<IEnumerable<Content>> GetAllAsync(
        string? searchTerm = null,
        ContentType? contentType = null)
    {
        IQueryable<Content> query = _context.Contents;

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(c =>
                c.Title.Contains(searchTerm));
        }

        // Filter the results by the selected content type.
        if (contentType.HasValue)
        {
            query = contentType.Value switch
            {
                ContentType.Movie =>
                    query.OfType<Movie>().Cast<Content>(),

                ContentType.Series =>
                    query.OfType<Series>().Cast<Content>(),

                ContentType.Audiobook =>
                    query.OfType<Audiobook>().Cast<Content>(),

                ContentType.MusicAlbum =>
                    query.OfType<MusicAlbum>().Cast<Content>(),

                _ => query
            };
        }

        // Return the filtered results ordered by title.
        return await query
            .OrderBy(c => c.Title)
            .ToListAsync();
    }

    // Retrieves a single content item using its unique identifier.
    public async Task<Content?> GetByIdAsync(int id)
    {
        return await _context.Contents
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    // Adds a new content item to the database.
    public async Task AddAsync(Content content)
    {
        _context.Contents.Add(content);

        await _context.SaveChangesAsync();
    }

    // Updates an existing content item in the database.
    public async Task UpdateAsync(Content content)
    {
        var existing = await _context.Contents.FindAsync(content.Id);

        if (existing == null)
            return;

        _context.Entry(existing).CurrentValues.SetValues(content);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var content = await GetByIdAsync(id);

        if (content == null)
            return;

        _context.Contents.Remove(content);

        await _context.SaveChangesAsync();
    }

    // Determines whether a content item exists in the database.
    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Contents
            .AnyAsync(c => c.Id == id);
    }
}