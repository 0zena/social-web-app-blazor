using ProjectWebApp.Data;

namespace ProjectWebApp.Models;

public class Like
{
    public int Id { get; set; }
    
    public DateTime Date { get; set; }

    public required ApplicationUser User { get; set; }
    
    public required Post Post { get; set; }
}