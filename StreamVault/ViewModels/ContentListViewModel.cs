using StreamVaultAdmin.Models;

namespace StreamVaultAdmin.ViewModels;

public class ContentListViewModel
{
    /// <summary>
    /// The list of content items displayed in the catalogue.
    /// </summary>
    public IEnumerable<Content> Contents { get; set; } = Enumerable.Empty<Content>();

    /// <summary>
    /// The current search term entered by the user.
    /// </summary>
    public string? SearchTerm { get; set; }

    /// <summary>
    /// The currently selected content type filter.
    /// </summary>
    public ContentType? SelectedType { get; set; }
}