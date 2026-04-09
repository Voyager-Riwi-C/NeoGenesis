namespace NeoGenesis.App.Repositories;

using NeoGenesis.App.Data;
using NeoGenesis.App.Models;

public class DinosaurRepository
{
    private AppDbContext db;

    public DinosaurRepository(AppDbContext context)
    {
        db = context;
    }

    public void Save(Dinosaur dinosaur)
    {
        db.Dinosaurs.Add(dinosaur);
        db.SaveChanges();
    }

    public List<Dinosaur> GetAll()
    {
        return db.Dinosaurs.ToList();
    }

    public Dinosaur? GetById(int id)
    {
        foreach (Dinosaur d in db.Dinosaurs)
        {
            if (d.Id == id)
                return d;
        }
        return null;
    }

    public void Update(Dinosaur dinosaur)
    {
        db.Dinosaurs.Update(dinosaur);
        db.SaveChanges();
    }

    public void Delete(Dinosaur dinosaur)
    {
        db.Dinosaurs.Remove(dinosaur);
        db.SaveChanges();
    }

    public bool EmailExists(string email)
    {
        foreach (Dinosaur d in db.Dinosaurs)
        {
            if (d.Email == email)
                return true;
        }
        return false;
    }

    public bool UsernameExists(string username)
    {
        foreach (Dinosaur d in db.Dinosaurs)
        {
            if (d.Username == username)
                return true;
        }
        return false;
    }
}