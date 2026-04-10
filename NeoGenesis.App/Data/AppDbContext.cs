namespace NeoGenesis.App.Data;

using Microsoft.EntityFrameworkCore;
using NeoGenesis.App.Models;

public class AppDbContext : DbContext
{
    public DbSet<Dinosaur> Dinosaurs { get; set; }
    public DbSet<Zone> Zones { get; set; }
    public DbSet<Sector> Sectors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=neoGenesis.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
