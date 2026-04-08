using NeoGenesis.App.Data;
using NeoGenesis.App.Repositories;
using NeoGenesis.App.Services;
using NeoGenesis.App.UI;
using Microsoft.EntityFrameworkCore;

var db = new AppDbContext();

var repo = new DinosaurRepository(db); //error por falta de la dbconexion
var service = new DinosaurService(repo);
var menu = new MainMenu(service); //falla porque no se ha definido un constructor

menu.Show();



