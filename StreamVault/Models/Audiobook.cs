using System.ComponentModel.DataAnnotations;

namespace StreamVaultAdmin.Models;

// Represents an audiobook within the StreamVault catalogue.
// Inherits common properties from the Content base class and
// includes audiobook-specific information such as the author,
// narrator and duration.
public class Audiobook : Content
{
    [Required]
    [StringLength(100)]
    public string Author { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Narrator { get; set; } = string.Empty;

    [Range(1, 5000)]
    [Display(Name = "Duration (minutes)")]
    public int DurationMinutes { get; set; }

    public override ContentType ContentType => ContentType.Audiobook;

    public override string Summary =>
        $"{Author} • Narrated by {Narrator}";
}