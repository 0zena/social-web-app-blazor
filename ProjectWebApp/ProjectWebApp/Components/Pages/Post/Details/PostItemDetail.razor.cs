using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using ProjectWebApp.Components.Account;
using ProjectWebApp.Data;
using ProjectWebApp.Models;

namespace ProjectWebApp.Components.Pages.Post.Details;

public partial class PostItemDetail : ComponentBase
{
    [Parameter]
    public int Id { get; set; }
    
    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = default!;
    
    private Models.Post? Post { get; set; }
    
    [Inject]
    private ApplicationDbContext Context { get; set; } = null!;

    [Inject]
    private IdentityUserAccessor UserAccessor { get; set; } = null!;

    [Inject]
    private IdentityRedirectManager RedirectManager { get; set; } = null!;
    
    [SupplyParameterFromForm]
    private InputModel Model { get; set; } = new();

    private readonly DateTime _dateTime = DateTime.Now;

    private string Title => Post?.Title ?? "Untitled";
    
    protected override void OnInitialized()
    {
        Post = Context.Posts?.Find(Id)!;
    }

    private async Task LikePost()
    {
        var like = new Like
        {
            Post = Post!,
            User = await UserAccessor.GetRequiredUserAsync(HttpContext),
            Date = _dateTime
        };
        
        Context.Likes!.Add(like);
        await Context.SaveChangesAsync();
        RedirectManager.RedirectToCurrentPage();
    }

    private async Task DislikePost()
    {
        var like = new Dislike
        {
            Post = Post!,
            User = await UserAccessor.GetRequiredUserAsync(HttpContext),
            Date = _dateTime
        };
        
        Context.Dislikes!.Add(like);
        await Context.SaveChangesAsync();
        RedirectManager.RedirectToCurrentPage();
    }
    
    private async Task Delete()
    {
        Context?.Posts?.Remove(Post!);
        await Context!.SaveChangesAsync();
        RedirectManager.RedirectTo("/Posts");
    }

    public class InputModel
    {
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Comment must be at 2 to 500 chars")] 
        public string Content { get; set; } = null!;
    }
}