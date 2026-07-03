using System.ComponentModel.DataAnnotations;

namespace StreamVaultAdmin.Models;

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