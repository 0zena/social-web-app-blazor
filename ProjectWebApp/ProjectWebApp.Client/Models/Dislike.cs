namespace ProjectWebApp.Client.Models;

public class Dislike
{
    public int Id { get; set; }
    
    public DateTime Date { get; set; }
    
    public Post Post { get; set; }
    
}