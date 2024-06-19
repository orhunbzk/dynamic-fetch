using dynamicfetch.Models;
using Microsoft.EntityFrameworkCore;
namespace dynamicfetch.Persistence;

public class DynamicFetchDbContext : DbContext
{
    public DynamicFetchDbContext(DbContextOptions<DynamicFetchDbContext> options) : base(options)
    {
    }
    
    public DbSet<Ticket> Tickets { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>().HasKey(t => t.Id);
    }
}