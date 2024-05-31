using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using ProjectWebApp.Components.Account;
using ProjectWebApp.Data;

namespace ProjectWebApp.Components.Pages.Comment;

public partial class CommentCreator
{

    [Parameter] 
    public Models.Post Post { get; set; } = null!;

    [Inject] 
    private ApplicationDbContext Context { get; set; } = null!;
    
    [Inject] 
    private IdentityUserAccessor UserAccessor { get; set; } = null!;
    
    [Inject]
    private IdentityRedirectManager RedirectManager { get; set; } = null!;
    
    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = default!;
    
    [SupplyParameterFromForm]
    private InputModel Model { get; set; } = new();

    private readonly DateTime _dateTime = DateTime.Now;

    private async Task CreateComment()
    {
        var comment = new Models.Comment
        {
            Content = Model.Content,
            User = await UserAccessor.GetRequiredUserAsync(HttpContext),
            Post = Post,
            Date = _dateTime
        };

        Context.Comments!.Add(comment);
        await Context.SaveChangesAsync();
        RedirectManager.RedirectToCurrentPage();
    }

    private sealed class InputModel
    {
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Comment must be at 2 to 500 chars")] 
        public string Content { get; set; } = null!;
    }
}