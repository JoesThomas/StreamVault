using StreamVaultAdmin.Models;
using StreamVaultAdmin.ViewModels;

namespace StreamVaultAdmin.Mapping;

// Provides methods to convert between domain models (Content)
// and view models (ContentViewModel). This separates the data
// stored in the database from the data displayed in the user interface.
public static class ContentMapper
{
    // Converts a Content entity into a ContentViewModel
    // for use in the application's views.
    public static ContentViewModel ToViewModel(Content content)
    {
        var vm = new ContentViewModel
        {
            // Map the properties shared by all content types.
            Id = content.Id,
            Title = content.Title,
            Description = content.Description,
            ReleaseDate = content.ReleaseDate,
            Genre = content.Genre,
            AgeRating = content.AgeRating,
            SelectedType = content.ContentType
        };
        // Map specific properties.
        switch (content)
        {
            case Movie movie:
                vm.DurationMinutes = movie.DurationMinutes;
                vm.Director = movie.Director;
                break;

            case Series series:
                vm.NumberOfSeasons = series.NumberOfSeasons;
                vm.TotalEpisodes = series.TotalEpisodes;
                break;

            case Audiobook audiobook:
                vm.Author = audiobook.Author;
                vm.Narrator = audiobook.Narrator;
                vm.DurationMinutes = audiobook.DurationMinutes;
                break;

            case MusicAlbum album:
                vm.Artist = album.Artist;
                vm.TrackCount = album.TrackCount;
                vm.RecordLabel = album.RecordLabel;
                break;
        }

        return vm;
    }

    // Converts a ContentViewModel into the appropriate
    // Content-derived entity ready to be stored in the database.
    public static Content ToEntity(ContentViewModel vm)
    {
        // Create the correct derived content object based on
        // the selected content type.
        return vm.SelectedType switch
        {
            ContentType.Movie => new Movie
            {
                Id = vm.Id,
                Title = vm.Title,
                Description = vm.Description,
                ReleaseDate = vm.ReleaseDate,
                Genre = vm.Genre,
                AgeRating = vm.AgeRating,
                DurationMinutes = vm.DurationMinutes ?? 0,
                Director = vm.Director ?? string.Empty
            },

            ContentType.Series => new Series
            {
                Id = vm.Id,
                Title = vm.Title,
                Description = vm.Description,
                ReleaseDate = vm.ReleaseDate,
                Genre = vm.Genre,
                AgeRating = vm.AgeRating,
                NumberOfSeasons = vm.NumberOfSeasons ?? 1,
                TotalEpisodes = vm.TotalEpisodes ?? 1
            },

            ContentType.Audiobook => new Audiobook
            {
                Id = vm.Id,
                Title = vm.Title,
                Description = vm.Description,
                ReleaseDate = vm.ReleaseDate,
                Genre = vm.Genre,
                AgeRating = vm.AgeRating,
                Author = vm.Author ?? string.Empty,
                Narrator = vm.Narrator ?? string.Empty,
                DurationMinutes = vm.DurationMinutes ?? 0
            },

            ContentType.MusicAlbum => new MusicAlbum
            {
                Id = vm.Id,
                Title = vm.Title,
                Description = vm.Description,
                ReleaseDate = vm.ReleaseDate,
                Genre = vm.Genre,
                AgeRating = vm.AgeRating,
                Artist = vm.Artist ?? string.Empty,
                TrackCount = vm.TrackCount ?? 0,
                RecordLabel = vm.RecordLabel ?? string.Empty
            },

            _ => throw new InvalidOperationException("Unsupported content type.")
        };
    }
}