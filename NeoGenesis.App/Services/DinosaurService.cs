namespace NeoGenesis.App.Services;

using NeoGenesis.App.Models;
using NeoGenesis.App.Repositories;

public class DinosaurService
{
    private DinosaurRepository repo;

    public DinosaurService(DinosaurRepository repository)
    {
        repo = repository;
    }

    public void Create(Dinosaur dinosaur)
    {
        ValidateFields(dinosaur);

        repo.Save(dinosaur);
    }

    public void Update(int id, Dinosaur dinosaur)
    {
        Dinosaur? existing = repo.GetById(id);
        if (existing == null)
            throw new Exception("Dinosaur not found");

        ValidateFields(dinosaur);

        Console.WriteLine("\nAre you sure you want to update this dinosaur?");
        Console.WriteLine($"Name: {existing.Name} -> {dinosaur.Name}");
        Console.WriteLine($"Species: {existing.Species} -> {dinosaur.Species}");
        Console.WriteLine($"Code: {existing.RegistrationCode} -> {dinosaur.RegistrationCode}");
        Console.WriteLine($"Age: {existing.Age} -> {dinosaur.Age}");
        Console.WriteLine("\nType 'yes' to continue or anything else to cancel:");
        string? response = Console.ReadLine();

        if (response != "yes")
        {
            Console.WriteLine("Update cancelled.");
            return;
        }

        // Update
        existing.Name = dinosaur.Name;
        existing.Species = dinosaur.Species;
        existing.RegistrationCode = dinosaur.RegistrationCode;
        existing.Age = dinosaur.Age;
        existing.DietType = dinosaur.DietType;
        existing.TrackingDevice = dinosaur.TrackingDevice;
        existing.Location = dinosaur.Location;
        existing.ZoneId = dinosaur.ZoneId;

        repo.Update(existing);
        Console.WriteLine("Dinosaur updated successfully.");
    }

    private void ValidateFields(Dinosaur dinosaur)
    {
        if (string.IsNullOrWhiteSpace(dinosaur.Name))
            throw new Exception("Name is required");

        if (string.IsNullOrWhiteSpace(dinosaur.Species))
            throw new Exception("Species is required");

        if (ContainsNumber(dinosaur.Name))
            throw new Exception("Name must contain letters only");

        if (ContainsNumber(dinosaur.Species))
            throw new Exception("Species must contain letters only");

        if (string.IsNullOrWhiteSpace(dinosaur.RegistrationCode))
            throw new Exception("Registration code is required");

        if (dinosaur.Age < 0)
            throw new Exception("Age must be positive");

        if (!string.IsNullOrWhiteSpace(dinosaur.DietType))
        {
            string diet = dinosaur.DietType.Trim();
            if (!diet.Equals("Carnivore", StringComparison.OrdinalIgnoreCase)
                && !diet.Equals("Herbivore", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Diet type must be Carnivore or Herbivore");
            }

            dinosaur.DietType = char.ToUpperInvariant(diet[0]) + diet[1..].ToLowerInvariant();
        }
    }

    private bool ContainsNumber(string value)
    {
        foreach (char c in value)
        {
            if (char.IsDigit(c))
                return true;
        }

        return false;
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

        Console.WriteLine("\nWARNING! This action cannot be undone.");
        Console.WriteLine($"You will delete the dinosaur: {dinosaur.Name}");
        Console.WriteLine("Are you completely sure you want to delete this dinosaur?");
        Console.WriteLine("Type 'delete' to confirm or anything else to cancel:");
        string? response = Console.ReadLine();

        if (response != "delete")
        {
            Console.WriteLine("Operation cancelled.");
            return;
        }

        repo.Delete(dinosaur);
        Console.WriteLine("Dinosaur deleted.");
    }
}