using System.ComponentModel.DataAnnotations;

namespace StreamVaultAdmin.Models;

public class MusicAlbum : Content
{
    [Required]
    [StringLength(100)]
    public string Artist { get; set; } = string.Empty;

    [Range(1, 100)]
    public int TrackCount { get; set; }

    [Required]
    [StringLength(100)]
    public string RecordLabel { get; set; } = string.Empty;

    public override ContentType ContentType => ContentType.MusicAlbum;

    public override string Summary =>
        $"{Artist} • {TrackCount} track(s)";
}