using NeoGenesis.App.Data;
using NeoGenesis.App.Models;

namespace NeoGenesis.App.Repositories;

public class DinosaurRepository
{
    //readonly -> es para que una vez que se ejecute no se pueda modificar la bd
    private readonly AppDbContext db;
    
    public  DinosaurRepository(AppDbContext db)
    {
        this.db = db;
    }
    
    //OBTENER TODOS
    public List<Dinosaur> GetAll()
    {
        return db.Dinosaurs.ToList();
    }
    
    // OBTENER POR ID
    public Dinosaur? GetById(int id)
    {
        return db.Dinosaurs.FirstOrDefault(d => d.Id == id);
    }
    
    // CREAR
    public void Add(Dinosaur dinosaur)
    {
        db.Dinosaurs.Add(dinosaur);
        db.SaveChanges();
    }
    
    // ACTUALIZAR
    public void Update(Dinosaur dinosaur)
    {
        db.Dinosaurs.Update(dinosaur);
        db.SaveChanges();
    }
    
    // ELIMINAR
    public void Delete(int id)
    {
        var dinosaur = db.Dinosaurs.FirstOrDefault(d => d.Id == id);
        if (dinosaur != null)
        {
            db.Dinosaurs.Remove(dinosaur);
            db.SaveChanges();
        }
    }
}





