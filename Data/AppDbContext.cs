using ConfigurationService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
namespace ConfigurationService.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Service> Services { get; set; }
    public DbSet<HealthCheck> HealthChecks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Service>()
        .HasIndex(s => s.Url)
        .IsUnique();

        modelBuilder.Entity<HealthCheck>()
        .HasOne(h => h.Service)
        .WithMany(s => s.HealthChecks)
        .HasForeignKey(h => h.ServiceId);
    }
}