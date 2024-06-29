using GameStoreFrontend.Models;

namespace GameStoreFrontend.Clients;

public class GamesClient
{

    private readonly List<GameSummary> games = 
    [
        new()
        {
            Id = 1,
            Name = "Lost Ark",
            Genre = "Action RPG",
            Price = 19.99M,
            ReleaseDate = new DateOnly(2019, 12, 4)
        },
        new()
        {
            Id = 2,
            Name = "Final Fantasy XIV",
            Genre = "MMORPG",
            Price = 59.99M,
            ReleaseDate = new DateOnly(2010, 9, 30)
        },
        new()
        {
            Id = 3,
            Name = "Honkai Star Rail",
            Genre = "Strategy",
            Price = 29.99M,
            ReleaseDate = new DateOnly(2023, 4, 23)
        }
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames() => games.ToArray();

    public void AddGame(GameDetails game)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);
        var genre = genres.Single(genre => genre.Id == int.Parse(game.GenreId));

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(gameSummary);
    }

}
