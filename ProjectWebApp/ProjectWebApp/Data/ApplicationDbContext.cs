using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectWebApp.Models;

namespace ProjectWebApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Post>? Posts { get; set; }
        
        public DbSet<Comment>? Comments { get; set; }
        
        public DbSet<Like>? Likes { get; set; }
        
        public DbSet<Dislike>? Dislikes { get; set; }
        
        
    }

}
