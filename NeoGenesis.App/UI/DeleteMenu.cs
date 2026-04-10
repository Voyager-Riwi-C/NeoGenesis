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
            ConsoleHelper.ShowError("Invalid ID");
            ConsoleHelper.Pause();
            return;
        }

        try
        {
            _service.Delete(id);
        }
        catch (Exception ex)
        {
            ConsoleHelper.ShowError(ex.Message);
        }

        ConsoleHelper.Pause();
    }
}
