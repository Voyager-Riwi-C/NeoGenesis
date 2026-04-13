using NeoGenesis.App.Models;
using NeoGenesis.App.Services;
using NeoGenesis.App.Helpers;

namespace NeoGenesis.App.UI;

public class DeleteMenu
{
    private readonly DinosaurService _service;

    public DeleteMenu(DinosaurService service) => _service = service;

    public void Show()
    {
        ConsoleHelper.ShowTitle("Delete Dinosaur");
        
        Console.Write("  Dinosaur ID to delete: ");
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
        
        if (!ConsoleHelper.Confirm($"Are you sure you want to delete '{dinosaur.Name}'?"))
        {
            ConsoleHelper.ShowError("Operation cancelled.");
            ConsoleHelper.Pause();
            return;
        }
        
        _service.Delete(id);
        ConsoleHelper.ShowSuccess($"Dinosaur '{dinosaur.Name}' deleted successfully.");
        ConsoleHelper.Pause();
    }
}


