namespace ProjectWebApp.Client.Models;

public class Like
{
    public int Id { get; set; }
    
    public DateTime Date { get; set; }
    
    // Navigation property
    public Post Post { get; set; }
    
    public int PostId { get; set; }
}