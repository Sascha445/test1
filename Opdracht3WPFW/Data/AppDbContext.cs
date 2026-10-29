using Microsoft.EntityFrameworkCore;
using Opdracht3WPFW.Models;

namespace Opdracht3WPFW.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Blogpost> Blogposts { get; set; }
}