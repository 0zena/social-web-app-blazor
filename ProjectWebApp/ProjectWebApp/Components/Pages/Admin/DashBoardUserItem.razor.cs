using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ProjectWebApp.Components.Account;
using ProjectWebApp.Data;

namespace ProjectWebApp.Components.Pages.Admin;

public partial class DashBoardUserItem : ComponentBase
{
    [Parameter] 
    public ApplicationUser User { get; set; } = null!;

    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = null!;
    
    [Inject]
    private IdentityUserAccessor UserAccessor { get; set; } = null!;

    [Inject]
    private ApplicationDbContext Context { get; set; } = null!;
    
    [Inject] 
    private UserManager<ApplicationUser> UserManager { get; set; } = null!;

    [Inject] 
    private SignInManager<ApplicationUser> SignInManager { get; set; } = null!;

    [Inject] 
    private IdentityRedirectManager RedirectManager { get; set; } = null!;
    
    private List<Models.Post>? Posts { get; set; }
    
    private List<Models.Comment>? Comments { get; set; }

    private bool Disabled => !Posts.IsNullOrEmpty()
                             || !Comments.IsNullOrEmpty()
                             || User == UserAccessor.GetRequiredUserAsync(HttpContext).Result;

    protected override void OnInitialized()
    {
        var posts = from p in Context.Posts
            where p.User.Equals(User)
            select p;

        var comments = from c in Context.Comments
            where c.User.Equals(User)
            select c;

        Posts = posts.ToList();
        Comments = comments.ToList();
    }

    private async Task DeleteUserBlog()
    {
        await using (Context)
        {
            var posts = from p in Context.Posts
                where p.User.Equals(User)
                select p;

            var comments = from c in Context.Comments
                where c.User.Equals(User)
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

    private async Task DeleteUserProfile()
    {
        var result = await UserManager.DeleteAsync(User);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException("Unexpected error occurred deleting user.");
        }
        
        RedirectManager.RedirectToCurrentPage();
    }
}