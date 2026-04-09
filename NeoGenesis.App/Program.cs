/*using NeoGenesis.App.Data;
using NeoGenesis.App.Repositories;
using NeoGenesis.App.Services;
using NeoGenesis.App.UI;
using Microsoft.EntityFrameworkCore;

var db = new AppDbContext();

var repo = new DinosaurRepository(db); //error por falta de la dbconexion
var service = new DinosaurService(repo);
var menu = new MainMenu(service); //falla porque no se ha definido un constructor

menu.Show();*/

//PRUEBA DE QUE SI FUNCIONA VALE
using NeoGenesis.App.Data;

var db = new AppDbContext();

Console.WriteLine(db.Database.CanConnect()
  ? "✅ Conexión exitosa"
  : "❌ No se pudo conectar");


//CAMBIOS DE DANI
// var db = new AppDbContext();
// db.Database.Migrate();

// var repo    = new DinosaurRepository(db);
// var service = new DinosaurService(repo);
// var menu    = new MainMenu(service);

// menu.Show();

/*
Console.WriteLine("NeoGenesis Park — sistema iniciando...");
Console.ReadKey();*/