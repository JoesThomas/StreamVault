using System.ComponentModel.DataAnnotations;

namespace StreamVaultAdmin.Models;

// Represents a series within the StreamVault catalogue.
// Inherits common properties from the Content base class and
// includes series-specific information such as the numberOfSeasons and totalEpisodes.
public class Series : Content
{
    [Range(1, 100)]
    public int NumberOfSeasons { get; set; }

    [Range(1, 5000)]
    public int TotalEpisodes { get; set; }

    public override ContentType ContentType => ContentType.Series;

    public override string Summary =>
        $"{NumberOfSeasons} season(s), {TotalEpisodes} episode(s)";
}