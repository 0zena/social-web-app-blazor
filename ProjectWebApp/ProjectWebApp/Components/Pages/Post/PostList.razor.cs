using System.Collections.Immutable;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using ProjectWebApp.Data;

namespace ProjectWebApp.Components.Pages.Post;

public partial class PostList : ComponentBase
{
    [Inject]
    private ApplicationDbContext Context { get; set; } = null!;
}