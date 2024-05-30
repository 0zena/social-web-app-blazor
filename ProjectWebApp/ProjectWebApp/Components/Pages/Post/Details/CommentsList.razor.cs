using Microsoft.AspNetCore.Components;
using ProjectWebApp.Data;
using ProjectWebApp.Models;

namespace ProjectWebApp.Components.Pages.Post.Details;

public partial class CommentsList : ComponentBase
{
    [Parameter] 
    public Models.Post Post { get; set; } = null!;
    
    private List<Comment>? Comments { get; set; }
    
    [Inject] 
    private ApplicationDbContext Context { get; set; } = null!;

    protected override void OnInitialized()
    {
        var comments = from c in Context.Comments
            where c.Post.Equals(Post) 
            select c;

        Comments = comments.ToList();
    }
}

