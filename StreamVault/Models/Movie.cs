using System.ComponentModel.DataAnnotations;

namespace StreamVaultAdmin.Models;

// Represents a movie within the StreamVault catalogue.
// Inherits common properties from the Content base class and
// includes movie-specific information such as the director and duration.
public class Movie : Content
{
    [Range(1, 1000)]
    [Display(Name = "Duration (minutes)")]
    public int DurationMinutes { get; set; }

    [Required]
    [StringLength(100)]
    public string Director { get; set; } = string.Empty;

    public override ContentType ContentType => ContentType.Movie;

    public override string Summary =>
        $"{DurationMinutes} mins • Directed by {Director}";
}