using System.ComponentModel.DataAnnotations;
using StreamVaultAdmin.Models;

namespace StreamVaultAdmin.ViewModels;

public class ContentViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    [DataType(DataType.Date)]
    public DateOnly ReleaseDate { get; set; }

    [Required]
    public string Genre { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Age Rating")]
    public string AgeRating { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Content Type")]
    public ContentType SelectedType { get; set; }

    // Movie

    public int? DurationMinutes { get; set; }

    public string? Director { get; set; }

    // Series

    public int? NumberOfSeasons { get; set; }

    public int? TotalEpisodes { get; set; }

    // Audiobook

    public string? Author { get; set; }

    public string? Narrator { get; set; }

    // Music Album

    public string? Artist { get; set; }

    public int? TrackCount { get; set; }

    public string? RecordLabel { get; set; }
}