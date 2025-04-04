using System.Net.Mime;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public sealed class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Image> Images { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { 
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User -> Image (Uploader)
        modelBuilder.Entity<Image>()
            .HasOne(t => t.UploadedBy)
            .WithMany(u => u.UploadedImages)
            .HasForeignKey(t => t.UploadedById)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
    }
}