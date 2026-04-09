using NeoGenesis.App.Models;
using NeoGenesis.App.Services;
using NeoGenesis.App.Helpers;

namespace NeoGenesis.App.UI;

public class UpdateMenu
{
    private readonly DinosaurService _service;

    public UpdateMenu(DinosaurService service) => _service = service;

    public void Show()
    {
        ConsoleHelper.ShowTitle("Update Dinosaur");

        Console.Write("  Dinosaur ID to update: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            ConsoleHelper.ShowError("Invalid ID.");
            ConsoleHelper.Pause();
            return;
        }
        
        var dinosaur = _service.GetById(id);
        if (dinosaur == null)
        {
            ConsoleHelper.ShowError("Dinosaur not found.");
            ConsoleHelper.Pause();
            return;
        }
        
        Console.WriteLine($"  Current name: {dinosaur.Name}");
        var name = ConsoleHelper.AskInput("New name");
        Console.WriteLine($"  Current species: {dinosaur.Species}");
        var species = ConsoleHelper.AskInput("New species");
        var ageInput = ConsoleHelper.AskInput("New age");
        var (ageValid, ageError) = _service.ValidateAge(ageInput, out int age);
        if (!ageValid)
        {
            ConsoleHelper.ShowError(ageError);
            ConsoleHelper.Pause();
            return;
        }
        
        dinosaur.Name    = name;
        dinosaur.Species = species;
        dinosaur.Age     = age;
        
        if (!ConsoleHelper.Confirm($"Save changes for '{dinosaur.Name}'?"))
        {
            ConsoleHelper.ShowWarning("Update cancelled.");
            ConsoleHelper.Pause();
            return;
        }

        _service.Update(dinosaur);
        ConsoleHelper.ShowSuccess($"Dinosaur '{name}' updated successfully.");
        ConsoleHelper.Pause();
    }
}