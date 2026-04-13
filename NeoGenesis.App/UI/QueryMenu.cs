using NeoGenesis.App.Models;
using NeoGenesis.App.Services;
using NeoGenesis.App.Helpers;

namespace NeoGenesis.App.UI;

public class QueryMenu
{
    private readonly DinosaurService _service;

    public QueryMenu(DinosaurService service) => _service = service;

    public void Show()
    {
        ConsoleHelper.ShowTitle("View Dinosaurs");

        var list = _service.GetAll();

        if (!list.Any())
        {
            ConsoleHelper.ShowWarning("No dinosaurs registered.");
            ConsoleHelper.Pause();
            return;
        }
        
        foreach (var d in list)
        {
            Console.WriteLine($"  [{d.Id}] {d.Name} | {d.Species} | Age: {d.Age} | Zone: {d.ZoneId}");
        }
        
        ConsoleHelper.Pause();
    }
}