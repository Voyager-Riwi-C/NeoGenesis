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

        var name             = ConsoleHelper.AskLettersOnly("Dinosaur name");
        var species          = ConsoleHelper.AskLettersOnly("Species");
        var registrationCode = ConsoleHelper.AskRequired("Registration code");
        var age              = ConsoleHelper.AskNonNegativeInt("Age");
        var dietType         = ConsoleHelper.AskOptionalDiet("Diet type (Carnivore/Herbivore)");
        var trackingDevice = ConsoleHelper.AskOptional("Tracking device");
        var location       = ConsoleHelper.AskOptional("Location");
        var zoneId         = ConsoleHelper.AskNonNegativeInt("Zone ID");

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
