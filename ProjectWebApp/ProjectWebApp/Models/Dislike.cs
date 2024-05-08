using ProjectWebApp.Data;

namespace ProjectWebApp.Models;

public class Dislike
{
    public int Id { get; set; }
    
    public DateTime Date { get; set; }
    
    public ApplicationUser User { get; set; }
    
    public Post Post { get; set; }
    
}