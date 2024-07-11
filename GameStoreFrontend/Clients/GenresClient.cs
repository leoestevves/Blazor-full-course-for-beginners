using GameStoreFrontend.Models;

namespace GameStoreFrontend.Clients;

public class GenresClient(HttpClient httpClient)
{
    public async Task<Genre[]> GetGenresAsync() 
        => await httpClient.GetFromJsonAsync<Genre[]>("genres") ?? []; //genres vem do backend
}
