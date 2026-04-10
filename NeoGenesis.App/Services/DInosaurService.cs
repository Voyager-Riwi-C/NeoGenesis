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
        CleanFields(dinosaur);
        ValidateFields(dinosaur);

        if (EmailExistsIgnoreCase(dinosaur.Email))
            throw new Exception("Email is already registered");

        if (UsernameExistsIgnoreCase(dinosaur.Username))
            throw new Exception("Username is already in use");

        // Save
        repo.Save(dinosaur);
    }

    public void Update(int id, Dinosaur dinosaur)
    {
        Dinosaur? existing = repo.GetById(id);
        if (existing == null)
            throw new Exception("Dinosaur not found");

        CleanFields(dinosaur);
        ValidateFields(dinosaur);

        if (!string.Equals(dinosaur.Email, existing.Email, StringComparison.OrdinalIgnoreCase)
            && EmailExistsIgnoreCase(dinosaur.Email))
            throw new Exception("Email is already registered");

        if (!string.Equals(dinosaur.Username, existing.Username, StringComparison.OrdinalIgnoreCase)
            && UsernameExistsIgnoreCase(dinosaur.Username))
            throw new Exception("Username is already in use");

        // Update
        existing.FirstName = dinosaur.FirstName;
        existing.Species = dinosaur.Species;
        existing.Username = dinosaur.Username;
        existing.Email = dinosaur.Email;

        repo.Update(existing);
    }

    private void CleanFields(Dinosaur dinosaur)
    {
        dinosaur.FirstName = dinosaur.FirstName.Trim();
        dinosaur.Species = dinosaur.Species.Trim();
        dinosaur.Username = dinosaur.Username.Trim();
        dinosaur.Email = dinosaur.Email.Trim();
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
        if (email.Contains(" "))
            return false;

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

        int dotAfterAt = email.IndexOf('.', atPosition);
        if (dotAfterAt == -1 || dotAfterAt == email.Length - 1)
            return false;

        return true;
    }

    private bool EmailExistsIgnoreCase(string email)
    {
        List<Dinosaur> allDinosaurs = repo.GetAll();

        foreach (Dinosaur d in allDinosaurs)
        {
            if (string.Equals(d.Email, email, StringComparison.OrdinalIgnoreCase))
                return true;
        }

        return false;
    }

    private bool UsernameExistsIgnoreCase(string username)
    {
        List<Dinosaur> allDinosaurs = repo.GetAll();

        foreach (Dinosaur d in allDinosaurs)
        {
            if (string.Equals(d.Username, username, StringComparison.OrdinalIgnoreCase))
                return true;
        }

        return false;
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