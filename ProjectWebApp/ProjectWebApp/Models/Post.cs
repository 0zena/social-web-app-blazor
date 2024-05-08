namespace ProjectWebApp.Models;

public class Post
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Bio { get; set; }
    
    public IEnumerable<Comment> Comments { get; set; }
    public IEnumerable<Like> Likes { get; set; }
    public IEnumerable<Dislike> Dislikes { get; set; }
}