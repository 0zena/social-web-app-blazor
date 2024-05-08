using ProjectWebApp.Client.Models;

namespace ProjectWebApp.Client.Http.Services;

public interface IPostHttpService
{ 
    Task CreateAsync(Post post);
}