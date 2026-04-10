using Microsoft.EntityFrameworkCore;
using NeoGenesis.App.Models;

namespace NeoGenesis.App.Data;

public class AppDbContext : DbContext
{
    public DbSet<Dinosaur> Dinosaurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=dinosaurs.db");
    }
}
