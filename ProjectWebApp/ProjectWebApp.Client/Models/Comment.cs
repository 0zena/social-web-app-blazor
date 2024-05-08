namespace ProjectWebApp.Client.Models;

public class Comment
{
    public int Id { get; set; }
    
    public string? Content { get; set; }
    
    public DateTime Date { get; set; }
    
    public Post? Post { get; set; }
}