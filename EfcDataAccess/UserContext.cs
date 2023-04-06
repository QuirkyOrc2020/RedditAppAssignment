using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<SubForum> SubForums { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/User.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<User>().HasKey(user => user.Id);
        modelBuilder.Entity<SubForum>().HasKey(subforum => subforum.Id);
        modelBuilder.Entity<Post>().HasKey(post => post.Id);
        modelBuilder.Entity<Comment>().HasKey(comment => comment.Id);
    }
}