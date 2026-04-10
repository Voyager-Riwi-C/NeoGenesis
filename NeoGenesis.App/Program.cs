using NeoGenesis.App.Data;
using NeoGenesis.App.Repositories;
using NeoGenesis.App.Services;
using NeoGenesis.App.UI;
using Microsoft.EntityFrameworkCore;

var db = new AppDbContext();
db.Database.Migrate();

var repo = new DinosaurRepository(db);
var service = new DinosaurService(repo);
var menu = new MainMenu(service);

menu.Show();

Console.WriteLine("NeoGenesis Park — System started...");
try { Console.ReadKey(); } catch { }