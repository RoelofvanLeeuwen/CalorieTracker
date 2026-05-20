using CalorieTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Product>          Products          => Set<Product>();
    public DbSet<ConsumptionEntry> ConsumptionEntries => Set<ConsumptionEntry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
