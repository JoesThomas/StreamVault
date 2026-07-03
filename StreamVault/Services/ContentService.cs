using Microsoft.EntityFrameworkCore;
using StreamVaultAdmin.Data;
using StreamVaultAdmin.Models;

namespace StreamVaultAdmin.Services;

public class ContentService : IContentService
{
    private readonly AppDbContext _context;

    public ContentService(AppDbContext context)
    {
        _context = context;
    }

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

        return await query
            .OrderBy(c => c.Title)
            .ToListAsync();
    }

    public async Task<Content?> GetByIdAsync(int id)
    {
        return await _context.Contents
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Content content)
    {
        _context.Contents.Add(content);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Content content)
    {
        _context.Update(content);

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

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Contents
            .AnyAsync(c => c.Id == id);
    }

    public Task UpdateAsync(int id, Content content)
    {
        throw new NotImplementedException();
    }
}