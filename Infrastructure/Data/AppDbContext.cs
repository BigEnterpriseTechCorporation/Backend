using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public sealed class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { 
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User -> Article (Author)
        modelBuilder.Entity<Article>()
            .HasOne(a => a.Author)
            .WithMany(u => u.AuthoredArticles)
            .HasForeignKey(a => a.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // User -> Article (LastEditor)
        modelBuilder.Entity<Article>()
            .HasOne(a => a.LastEditedBy)
            .WithMany(u => u.EditedArticles)
            .HasForeignKey(a => a.LastEditedById)
            .OnDelete(DeleteBehavior.Restrict);
        
        // User -> Assigment (Responsible)
        modelBuilder.Entity<Assignment>()
            .HasOne(t => t.ResponsibleUser)
            .WithMany(u => u.ResponsibleAssignments)
            .HasForeignKey(t => t.ResponsibleUserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
        modelBuilder.Entity<Assignment>().HasIndex(t => t.Status);
    }
}