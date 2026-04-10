using NeoGenesis.App.Models;
using NeoGenesis.App.Services;
using NeoGenesis.App.Helpers;

namespace NeoGenesis.App.UI;

public class InsertMenu
{
    private readonly DinosaurService _service;

    public InsertMenu(DinosaurService service) => _service = service;

    public void Show()
    {
        ConsoleHelper.ShowTitle("Register New Dinosaur");

        var name             = ConsoleHelper.AskInput("Dinosaur name");
        var species          = ConsoleHelper.AskInput("Species");
        var registrationCode = ConsoleHelper.AskInput("Registration code");

        var ageInput = ConsoleHelper.AskInput("Age");
        if (!int.TryParse(ageInput, out int age))
        {
            ConsoleHelper.ShowError("Invalid age");
            ConsoleHelper.Pause();
            return;
        }

        var dietType       = ConsoleHelper.AskOptional("Diet type (Carnivore/Herbivore)");
        var trackingDevice = ConsoleHelper.AskOptional("Tracking device");
        var location       = ConsoleHelper.AskOptional("Location");

        Console.Write("  Zone ID: ");
        int.TryParse(Console.ReadLine(), out int zoneId);

        var dinosaur = new Dinosaur
        {
            Name             = name,
            Species          = species,
            RegistrationCode = registrationCode,
            Age              = age,
            DietType         = dietType,
            TrackingDevice   = trackingDevice,
            Location         = location,
            ZoneId           = zoneId,
            RegistrationDate = DateTime.Now
        };

        try
        {
            _service.Create(dinosaur);
            ConsoleHelper.ShowSuccess($"Dinosaur '{name}' registered successfully.");
        }
        catch (Exception ex)
        {
            ConsoleHelper.ShowError(ex.Message);
        }

        ConsoleHelper.Pause();
    }
}
