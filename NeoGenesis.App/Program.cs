using NeoGenesis.App.Data;
using NeoGenesis.App.Repositories;
using NeoGenesis.App.Services;
using NeoGenesis.App.UI;

var db      = new AppDbContext();
var repo    = new DinosaurRepository(db);
var service = new DinosaurService(repo);
var menu    = new MainMenu(service);

menu.Show();

