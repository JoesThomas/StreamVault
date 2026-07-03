using StreamVaultAdmin.Models;

namespace StreamVaultAdmin.Data;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        if (context.Contents.Any())
            return;

        var catalogue = new List<Content>
        {
            new Movie
            {
                Title = "The Dark Knight",
                Description = "Batman faces the Joker in Gotham City.",
                ReleaseDate = new DateOnly(2008, 7, 18),
                Genre = "Action",
                AgeRating = "15",
                DurationMinutes = 152,
                Director = "Christopher Nolan"
            },

            new Movie
            {
                Title = "Inception",
                Description = "A thief steals information through dreams.",
                ReleaseDate = new DateOnly(2010, 7, 16),
                Genre = "Sci-Fi",
                AgeRating = "12",
                DurationMinutes = 148,
                Director = "Christopher Nolan"
            },

            new Series
            {
                Title = "Breaking Bad",
                Description = "A chemistry teacher turns to manufacturing drugs.",
                ReleaseDate = new DateOnly(2008, 1, 20),
                Genre = "Drama",
                AgeRating = "18",
                NumberOfSeasons = 5,
                TotalEpisodes = 62
            },

            new Series
            {
                Title = "Stranger Things",
                Description = "A group of friends uncover supernatural mysteries.",
                ReleaseDate = new DateOnly(2016, 7, 15),
                Genre = "Sci-Fi",
                AgeRating = "15",
                NumberOfSeasons = 4,
                TotalEpisodes = 34
            },

            new Audiobook
            {
                Title = "The Hobbit",
                Description = "Bilbo Baggins begins an unexpected journey.",
                ReleaseDate = new DateOnly(1937, 9, 21),
                Genre = "Fantasy",
                AgeRating = "PG",
                Author = "J.R.R. Tolkien",
                Narrator = "Andy Serkis",
                DurationMinutes = 1240
            },

            new Audiobook
            {
                Title = "Project Hail Mary",
                Description = "A lone astronaut attempts to save humanity.",
                ReleaseDate = new DateOnly(2021, 5, 4),
                Genre = "Science Fiction",
                AgeRating = "12",
                Author = "Andy Weir",
                Narrator = "Ray Porter",
                DurationMinutes = 960
            },

            new MusicAlbum
            {
                Title = "Thriller",
                Description = "Best-selling album of all time.",
                ReleaseDate = new DateOnly(1982, 11, 30),
                Genre = "Pop",
                AgeRating = "U",
                Artist = "Michael Jackson",
                TrackCount = 9,
                RecordLabel = "Epic Records"
            },

            new MusicAlbum
            {
                Title = "Back in Black",
                Description = "Classic rock album.",
                ReleaseDate = new DateOnly(1980, 7, 25),
                Genre = "Rock",
                AgeRating = "U",
                Artist = "AC/DC",
                TrackCount = 10,
                RecordLabel = "Albert Productions"
            }
        };

        context.Contents.AddRange(catalogue);
        context.SaveChanges();
    }
}