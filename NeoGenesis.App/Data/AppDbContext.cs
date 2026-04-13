using Microsoft.EntityFrameworkCore;
using NeoGenesis.App.Models;

namespace NeoGenesis.App.Data;

public class AppDbContext : DbContext
{
  public DbSet<Sector> Sectors { get; set; }
  public DbSet<Zone> Zones { get; set; }
  public DbSet<Dinosaur> Dinosaurs { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseNpgsql(
      "Host=204.168.220.79;Database=neogenesis;Username=postgres;Password=J3SnAS4D6b3NXqG4OEXv793O7eU1Kz"
    );
}

