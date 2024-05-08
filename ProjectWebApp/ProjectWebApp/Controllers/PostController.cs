using Microsoft.AspNetCore.Mvc;
using ProjectWebApp.Data;
using ProjectWebApp.Models;

namespace ProjectWebApp.Controllers;

public class PostController(ApplicationDbContext context) : ControllerBase
{
    [HttpPost]
    [Route("Api/Post/Create")]
    public async Task CreatePost([FromBody] Post post)
    {
        context.Add(post);
        await context.SaveChangesAsync();
    }
}