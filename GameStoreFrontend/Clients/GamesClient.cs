using System.Security.Cryptography.X509Certificates;
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
        Genre genre = GetGenreById(game.GenreId);

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

    public GameDetails GetGame(int id)
    {
        GameSummary? game = GetGameSummaryById(id);

        var genre = genres.Single(genre => string.Equals(genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public void UpdateGame(GameDetails updatedGame)
    {
        var genre = GetGenreById(updatedGame.GenreId);
        GameSummary existingGame = GetGameSummaryById(updatedGame.Id);

        existingGame.Name = updatedGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    public void DeleteGame(int id)
    {
        var game = GetGameSummaryById(id);
        games.Remove(game);
    }


    private GameSummary GetGameSummaryById(int id)
    {
        GameSummary? game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        return genres.Single(genre => genre.Id == int.Parse(id));
    }

}
