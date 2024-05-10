using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ProjectWebApp.Data;

namespace ProjectWebApp.Models;

public class Post
{
    public int ID { get; set; }
    
    [MaxLength(150)]
    public string? Title { get; set; }
    
    [MaxLength(1000)]
    public string? Bio { get; set; }
    
    public required ApplicationUser User { get; set; }
    
    public IEnumerable<Comment>? Comments { get; set; }
    
    public IEnumerable<Like>? Likes { get; set; }
    
    public IEnumerable<Dislike>? Dislikes { get; set; }
}