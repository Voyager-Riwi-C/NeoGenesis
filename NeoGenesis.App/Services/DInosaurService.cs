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

    // Validations
    public void Create(Dinosaur dinosaur)
    {
        if (string.IsNullOrEmpty(dinosaur.FirstName))
            throw new Exception("First name is required");

        if (string.IsNullOrEmpty(dinosaur.Species))
            throw new Exception("Species is required");

        if (string.IsNullOrEmpty(dinosaur.Username))
            throw new Exception("Username is required");

        if (string.IsNullOrEmpty(dinosaur.Email))
            throw new Exception("Email is required");

        bool emailIsValid = ValidateEmailFormat(dinosaur.Email);
        if (!emailIsValid)
            throw new Exception("Email format is not valid");

        // Check duplicates
        bool emailExists = repo.EmailExists(dinosaur.Email);
        if (emailExists)
            throw new Exception("Email is already registered");

        bool usernameExists = repo.UsernameExists(dinosaur.Username);
        if (usernameExists)
            throw new Exception("Username is already in use");

        // Save
        repo.Save(dinosaur);
    }

    public void Update(int id, Dinosaur dinosaur)
    {
        Dinosaur? existing = repo.GetById(id);
        if (existing == null)
            throw new Exception("Dinosaur not found");

        if (string.IsNullOrEmpty(dinosaur.FirstName))
            throw new Exception("First name is required");

        if (string.IsNullOrEmpty(dinosaur.Species))
            throw new Exception("Species is required");

        if (string.IsNullOrEmpty(dinosaur.Username))
            throw new Exception("Username is required");

        if (string.IsNullOrEmpty(dinosaur.Email))
            throw new Exception("Email is required");

        bool emailIsValid = ValidateEmailFormat(dinosaur.Email);
        if (!emailIsValid)
            throw new Exception("Email format is not valid");

        // Check duplicates (excluding current dinosaur)
        if (dinosaur.Email != existing.Email)
        {
            bool emailExists = repo.EmailExists(dinosaur.Email);
            if (emailExists)
                throw new Exception("Email is already registered");
        }

        if (dinosaur.Username != existing.Username)
        {
            bool usernameExists = repo.UsernameExists(dinosaur.Username);
            if (usernameExists)
                throw new Exception("Username is already in use");
        }

        // Update
        existing.FirstName = dinosaur.FirstName;
        existing.Species = dinosaur.Species;
        existing.Username = dinosaur.Username;
        existing.Email = dinosaur.Email;

        repo.Update(existing);
    }

    private bool ValidateEmailFormat(string email)
    {
        if (!email.Contains("@"))
            return false;

        int atPosition = email.IndexOf("@");

        if (atPosition == 0)
            return false;

        if (atPosition == email.Length - 1)
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