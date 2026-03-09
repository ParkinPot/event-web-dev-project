using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using event_web_dev_project.Models;

namespace event_web_dev_project.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser> 
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ActivityPost> ActivityPosts { get; set; }
    public DbSet<PostApplication> PostApplications { get; set; }
    public DbSet<Review> Reviews { get; set; }

}