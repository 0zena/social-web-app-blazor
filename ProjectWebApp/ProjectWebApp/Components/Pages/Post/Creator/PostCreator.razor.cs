using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using ProjectWebApp.Components.Account;
using ProjectWebApp.Data;

namespace ProjectWebApp.Components.Pages.Post.Creator;

public partial class PostCreator
{
    [SupplyParameterFromForm]
    private InputModel Input { get; set; } = new();
    
    [SupplyParameterFromQuery]
    private string? ReturnUrl { get; set; }
    
    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = default!;
    
    [Inject]
    private ApplicationDbContext Context { get; set; } = null!;

    [Inject]
    private IdentityUserAccessor UserAccessor { get; set; } = null!;

    [Inject]
    private IdentityRedirectManager RedirectManager { get; set; } = null!;
    
    private readonly DateTime _dateTime = DateTime.Now;
    
    public async Task Create()
    {
        var post = new Models.Post
        {
            Title = Input.Title,
            Bio = Input.Bio,
            User = await UserAccessor.GetRequiredUserAsync(HttpContext),
            Date = _dateTime
        };

        Context.Add(post);
        await Context.SaveChangesAsync();
        RedirectManager.RedirectTo("/");
    }

    public sealed class InputModel
    {
        [Required]
        [Display(Name = "Title")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Title must be 2-150 chars long")]
        public string Title { get; set; } = string.Empty;
        
        [Display(Name = "Bio")]
        [StringLength(5000, MinimumLength = 2, ErrorMessage = "Description must be 2-5000 chars long")]
        public string Bio { get; set; } = string.Empty;
    }
}