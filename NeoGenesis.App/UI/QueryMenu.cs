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

        try
        {
            var dinosaurs = _service.GetAll();
            if (dinosaurs.Count == 0)
            {
                ConsoleHelper.ShowError("No dinosaurs found");
                ConsoleHelper.Pause();
                return;
            }

            foreach (var dino in dinosaurs)
            {
                Console.WriteLine($"\n  ID: {dino.Id}");
                Console.WriteLine($"  Name: {dino.Name}");
                Console.WriteLine($"  Species: {dino.Species}");
                Console.WriteLine($"  Code: {dino.RegistrationCode}");
                Console.WriteLine($"  Age: {dino.Age}");
                Console.WriteLine($"  Diet: {dino.DietType}");
                Console.WriteLine($"  Device: {dino.TrackingDevice}");
                Console.WriteLine($"  Location: {dino.Location}");
                Console.WriteLine($"  Zone ID: {dino.ZoneId}");
                Console.WriteLine("  ---");
            }
        }
        catch (Exception ex)
        {
            ConsoleHelper.ShowError(ex.Message);
        }

        ConsoleHelper.Pause();
    }
}
