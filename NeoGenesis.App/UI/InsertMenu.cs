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
        var registrationCode = ConsoleHelper.AskInput("Registration Code");

        var (isValid, error) = _service.ValidateNewDinosaur(name, species, registrationCode);
        if (!isValid)
        {
            ConsoleHelper.ShowError(error);
            ConsoleHelper.Pause();
            return;
        }

        var ageInput = ConsoleHelper.AskInput("Age");
        var (ageValid, ageError) = _service.ValidateAge(ageInput, out int age);
        if (!ageValid)
        {
            ConsoleHelper.ShowError(ageError);
            ConsoleHelper.Pause();
            return;
        }

        var dietType       = ConsoleHelper.AskOptional("Diet Type(carnivore/herbivore)");
        var trackingDevice = ConsoleHelper.AskOptional("Tracking Device");
        var location       = ConsoleHelper.AskOptional("Location");

        // TODO: preguntar el zone id
        Console.Write("  Zone ID : ");
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

        // TODO: llamar _service.Add(dinosaur) cuando este el repo check 
        ConsoleHelper.ShowSuccess($"Dinosaur '{name}' registered successfully.");
        ConsoleHelper.Pause();
    }
}