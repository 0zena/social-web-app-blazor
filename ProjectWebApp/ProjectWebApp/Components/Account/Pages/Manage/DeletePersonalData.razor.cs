using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using ProjectWebApp.Data;

namespace ProjectWebApp.Components.Account.Pages.Manage;

public partial class DeletePersonalData
{
    private string? _message;
    private ApplicationUser _user = default!;
    private bool _requirePassword;

    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = default!;

    [SupplyParameterFromForm]
    private InputModel Input { get; set; } = new();
    
    private List<Models.Post>? Posts { get; set; }
    
    private List<Models.Comment>? Comments { get; set; }

    private bool DisableDeleteProfile => !Posts.IsNullOrEmpty()
                                         || !Comments.IsNullOrEmpty();
    
    private bool DisableDeleteBlog => Posts.IsNullOrEmpty();

    protected override async Task OnInitializedAsync()
    {
        Input ??= new();
        _user = await UserAccessor.GetRequiredUserAsync(HttpContext);
        _requirePassword = await UserManager.HasPasswordAsync(_user);
        
        var posts = from p in Context.Posts
            where p.User.Equals(_user)
            select p;

        var comments = from c in Context.Comments
            where c.User.Equals(_user)
            select c;

        Posts = posts.ToList();
        Comments = comments.ToList();
    }

    private async Task OnValidSubmitAsync()
    {
        if (_requirePassword && !await UserManager.CheckPasswordAsync(_user, Input.Password))
        {
            _message = "Error: Incorrect password.";
            return;
        }

        var result = await UserManager.DeleteAsync(_user);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException("Unexpected error occurred deleting user.");
        }

        await SignInManager.SignOutAsync();

        var userId = await UserManager.GetUserIdAsync(_user);
        Logger.LogInformation("User with ID '{UserId}' deleted themselves.", userId);

        RedirectManager.RedirectToCurrentPage();
    }

    private async Task DeleteUsersBlog()
    {
        await using (Context)
        {
            var posts = from p in Context.Posts
                where p.User.Equals(_user)
                select p;
            
            var comments = from c in Context.Comments
                where c.User.Equals(_user)
                select c;

            foreach (var comment in comments)
            {
                Context?.Comments!.Remove(comment);
            }

            foreach (var post in posts)
            {
                Context?.Posts!.Remove(post);
            }
            await Context!.SaveChangesAsync();
        }

        RedirectManager.RedirectToCurrentPage();
    }
    
    private sealed class InputModel
    {
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}