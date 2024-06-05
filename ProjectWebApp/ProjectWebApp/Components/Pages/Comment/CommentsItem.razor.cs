using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using ProjectWebApp.Data;

namespace ProjectWebApp.Components.Pages.Comment;

public partial class CommentsItem
{
    [Parameter] 
    public int Id { get; set; }

    [Inject] 
    private ApplicationDbContext Context { get; set; } = null!;
    
    private Models.Comment? Comment { get; set; }

    private string Date => $"{Comment?.Date.Day}.{Comment?.Date.Month}.{Comment?.Date.Year}";

    protected override void OnInitialized()
    {
        var comments = 
            from c in Context.Comments?.Include(c => c.User)
            where c.Id.Equals(Id)
            select c;

        Comment = comments.FirstOrDefault();
    }
}