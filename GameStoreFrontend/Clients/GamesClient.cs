using System.Security.Cryptography.X509Certificates;
using GameStoreFrontend.Models;

namespace GameStoreFrontend.Clients;

public class GamesClient(HttpClient httpClient)
{
    //CRUD
    public async Task<GameSummary[]> GetGamesAsync() 
        => await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? []; //Esse games vem do get do backend, caso seja nulo retorna um array vazio
    

    public async Task AddGameAsync(GameDetails game)
        => await httpClient.PostAsJsonAsync("games", game); //games do backend
    

    public async Task<GameDetails> GetGameAsync(int id)
        => await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}")
            ?? throw new Exception("Could not find game!");
    

    public async Task UpdateGameAsync(GameDetails updatedGame)
        => await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);


    public async Task DeleteGameAsync(int id)
        => await httpClient.DeleteAsync($"games/{id}");

}
