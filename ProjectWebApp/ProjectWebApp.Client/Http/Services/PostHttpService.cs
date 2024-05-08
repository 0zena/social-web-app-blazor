using System.Net.Http.Json;
using ProjectWebApp.Client.Models;

namespace ProjectWebApp.Client.Http.Services;

public class PostHttpService(HttpClient client) : IPostHttpService
{

    public async Task CreateAsync(Post post)
    {
        await client.PostAsJsonAsync("/Api/Post/Create", post);
    }
}