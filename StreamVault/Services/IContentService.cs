using StreamVaultAdmin.Models;

namespace StreamVaultAdmin.Services;

public interface IContentService
{
    // <summary>
    // Returns all content, optionally filtered by title and content type.
    // </summary>
    Task<IEnumerable<Content>> GetAllAsync(
        string? searchTerm = null,
        ContentType? contentType = null);

    // <summary>
    // Returns a single content item by its ID.
    // </summary>
    Task<Content?> GetByIdAsync(int id);

    // <summary>
    // Adds a new content item.
    // </summary>
    Task AddAsync(Content content);

    // <summary>
    // Updates an existing content item.
    // </summary>
    Task UpdateAsync(Content content);

    // <summary>
    // Deletes a content item.
    // </summary>
    Task DeleteAsync(int id);

    // <summary>
    // Checks whether a content item exists.
    // </summary>
    Task<bool> ExistsAsync(int id);
}