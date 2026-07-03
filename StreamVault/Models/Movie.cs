using System.ComponentModel.DataAnnotations;

namespace StreamVaultAdmin.Models;

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