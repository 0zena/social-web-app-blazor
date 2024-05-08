using ProjectWebApp.Data;

namespace ProjectWebApp.Models;

public class Like
{
    public int Id { get; set; }
    
    public DateTime Date { get; set; }
    
    public ApplicationUser User { get; set; }
    
    // Navigation property
    public Post Post { get; set; }
    
    public int PostId { get; set; }
}