using System.ComponentModel.DataAnnotations;
using ProjectWebApp.Data;

namespace ProjectWebApp.Models;

public class Comment
{
    public int Id { get; set; }
    
    [MaxLength(5000)] 
    public string? Content { get; set; }
    
    public DateTime Date { get; set; }
    
    public required ApplicationUser User { get; set; }
    
    public required Post Post { get; set; }
}