using System.ComponentModel.DataAnnotations;

namespace StreamVaultAdmin.Models;

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