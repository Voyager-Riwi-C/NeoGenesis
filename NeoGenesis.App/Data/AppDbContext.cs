namespace NeoGenesis.App.Data;

using Microsoft.EntityFrameworkCore;
using NeoGenesis.App.Models;

public class AppDbContext : DbContext
{
    public DbSet<Dinosaur> Dinosaurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=dinosaurs.db");
    }
}