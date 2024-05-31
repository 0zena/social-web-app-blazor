using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Design;
using ProjectWebApp.Components.Account;
using ProjectWebApp.Data;

namespace ProjectWebApp.Components.Pages.Post;

public partial class PostList : ComponentBase
{
    [Inject]
    private ApplicationDbContext Context { get; set; } = null!;

    private List<Models.Post> Posts { get; set; } = new();

    [Inject] private IdentityRedirectManager NavigationManager { get; set; } = null!;

    private string? Type { get; set; } = "Newest";

    protected override void OnInitialized()
    {
        LoadPosts();
    }
    
    private void LoadPosts()
    {
        Console.WriteLine("LLL: " + Type);
        Posts = Type switch
        {
            "Oldest" => Context.Posts!.OrderBy(p => p.Date).ToList(),
            "Newest" => Context.Posts!.OrderByDescending(p => p.Date).ToList(),
            _ => Context.Posts!.OrderBy(p => p.Date).ToList()
        };
        StateHasChanged();
    }
    
    private void ToggleSortType()
    {
        Type = Type == "Newest" ? "Oldest" : "Newest";
        LoadPosts();
        NavigationManager.RedirectToCurrentPage();
    }

}


