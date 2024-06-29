using GameStoreFrontend.Models;

namespace GameStoreFrontend.Clients;

public class GenresClient
{
    private readonly Genre[] genres = 
    [
        new ()
        {
            Id = 1,
            Name = "Action RPG"            
        },
        new ()
        {
            Id = 2,
            Name = "Sports"
        },
        new ()
        {
            Id = 3,
            Name = "MMORPG"
        },
        new ()
        {
            Id = 4,
            Name = "Strategy"
        }
    ];

    public Genre[] GetGenres() => genres;
}
