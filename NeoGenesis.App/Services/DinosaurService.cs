using NeoGenesis.App.Models;
using NeoGenesis.App.Repositories;

namespace NeoGenesis.App.Services;

public class DinosaurService
{
    private readonly DinosaurRepository _repository;

    public DinosaurService(DinosaurRepository repository)
    {
        _repository = repository;
    }

    // CRUD FROM REPOSITORIES
    public List<Dinosaur> GetAll()    => _repository.GetAll();
    public Dinosaur? GetById(int id)  => _repository.GetById(id);
    public void Add(Dinosaur d)       => _repository.Add(d);
    public void Update(Dinosaur d)    => _repository.Update(d);
    public void Delete(int id)        => _repository.Delete(id);

    // Validations

    public (bool isValid, string error) ValidateNewDinosaur(
        string name, string species, string registrationCode)
    {
        if (string.IsNullOrWhiteSpace(name))
            return (false, "Name cannot be empty.");

        if (string.IsNullOrWhiteSpace(species))
            return (false, "Species cannot be empty.");

        if (string.IsNullOrWhiteSpace(registrationCode))
            return (false, "Registration code cannot be empty.");

        return (true, string.Empty);
    }

    public (bool isValid, string error) ValidateAge(string input, out int age)
    {
        age = 0;
        if (!int.TryParse(input, out age))
            return (false, "Invalid Age(Age must be whole number).");
        if (age < 0)
            return (false, "Age cannot be a negative number.");
        return (true, string.Empty);
    }
}