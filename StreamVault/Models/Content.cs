using System.ComponentModel.DataAnnotations;

namespace StreamVaultAdmin.Models;

public abstract class Content
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
    [StringLength(50)]
    public string Genre { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Age Rating")]
    public string AgeRating { get; set; } = string.Empty;

    // Implemented by each derived class
    public abstract ContentType ContentType { get; }

    // Used on catalogue pages without checking the runtime type
    public abstract string Summary { get; }
}