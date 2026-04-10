namespace NeoGenesis.App.Services;

using NeoGenesis.App.Models;
using NeoGenesis.App.Repositories;

public class DInosaurService
{
    private DinosaurRepository repo;

    public DInosaurService(DinosaurRepository repository)
    {
        repo = repository;
    }

    public void Create(Dinosaur dinosaur)
    {
        ValidateFields(dinosaur);

        if (repo.EmailExists(dinosaur.Email))
            throw new Exception("Email is already registered");

        if (repo.UsernameExists(dinosaur.Username))
            throw new Exception("Username is already in use");

        // Save
        repo.Save(dinosaur);
    }

    public void Update(int id, Dinosaur dinosaur)
    {
        Dinosaur? existing = repo.GetById(id);
        if (existing == null)
            throw new Exception("Dinosaur not found");

        ValidateFields(dinosaur);

        if (dinosaur.Email != existing.Email && repo.EmailExists(dinosaur.Email))
            throw new Exception("Email is already registered");

        if (dinosaur.Username != existing.Username && repo.UsernameExists(dinosaur.Username))
            throw new Exception("Username is already in use");

        // Update
        existing.FirstName = dinosaur.FirstName;
        existing.Species = dinosaur.Species;
        existing.Username = dinosaur.Username;
        existing.Email = dinosaur.Email;

        repo.Update(existing);
    }

    private void ValidateFields(Dinosaur dinosaur)
    {
        if (string.IsNullOrEmpty(dinosaur.FirstName))
            throw new Exception("First name is required");

        if (string.IsNullOrEmpty(dinosaur.Species))
            throw new Exception("Species is required");

        if (string.IsNullOrEmpty(dinosaur.Username))
            throw new Exception("Username is required");

        if (string.IsNullOrEmpty(dinosaur.Email))
            throw new Exception("Email is required");

        if (!ValidateEmailFormat(dinosaur.Email))
            throw new Exception("Email format is not valid");
    }

    private bool ValidateEmailFormat(string email)
    {
        int atCount = 0;
        int atPosition = -1;

        for (int i = 0; i < email.Length; i++)
        {
            if (email[i] == '@')
            {
                atCount++;
                atPosition = i;
            }
        }

        if (atCount != 1)
            return false;

        if (atPosition == 0 || atPosition == email.Length - 1)
            return false;

        return true;
    }

    public List<Dinosaur> GetAll()
    {
        return repo.GetAll();
    }

    public Dinosaur GetById(int id)
    {
        Dinosaur? dinosaur = repo.GetById(id);
        if (dinosaur == null)
            throw new Exception("Dinosaur not found");
        return dinosaur;
    }

    public void Delete(int id)
    {
        Dinosaur? dinosaur = repo.GetById(id);
        if (dinosaur == null)
            throw new Exception("Dinosaur not found");

        repo.Delete(dinosaur);
    }
}