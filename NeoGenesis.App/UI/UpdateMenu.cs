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

        Console.Write("  Dinosaur ID to update: ");
        if (!int.TryParse(Console.ReadLine(), out int dinoId))
        {
            ConsoleHelper.ShowError("Invalid ID");
            ConsoleHelper.Pause();
            return;
        }

        try
        {
            _service.Update(dinoId, dinosaur);
        }
        catch (Exception ex)
        {
            ConsoleHelper.ShowError(ex.Message);
        }

        ConsoleHelper.Pause();
    }
}
