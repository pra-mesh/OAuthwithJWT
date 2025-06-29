using Microsoft.EntityFrameworkCore;
using OAuthwithJWT.Models;

namespace OAuthwithJWT.Data.AppContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
    {

    }
    public DbSet<User> Users { get; set; }
    public DbSet<Test> Tests { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Provider).IsRequired().HasMaxLength(50);
            entity.Property(e => e.ProviderId).IsRequired().HasMaxLength(255);
            entity.Property(e => e.ProfilePicture).HasMaxLength(500);
            entity.HasIndex(e => new { e.Provider, e.ProviderId }).IsUnique();
            entity.HasIndex(e => e.Email);

        });
    }
}
