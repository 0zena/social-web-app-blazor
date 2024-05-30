using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using ProjectWebApp.Components.Account;
using ProjectWebApp.Data;
using ProjectWebApp.Models;

namespace ProjectWebApp.Components.Pages.Post.Details;

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
        var comment = new Comment
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
        [Length(1, 200)] 
        public string Content { get; set; } = null!;
    }
}