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
        ConsoleHelper.ShowTitle("Registrar Nuevo Dinosaurio");

        var name             = ConsoleHelper.AskInput("Nombre del dinosaurio");
        var species          = ConsoleHelper.AskInput("Especie");
        var registrationCode = ConsoleHelper.AskInput("Código de registro");

        var (isValid, error) = _service.ValidateNewDinosaur(name, species, registrationCode);
        if (!isValid)
        {
            ConsoleHelper.ShowError(error);
            ConsoleHelper.Pause();
            return;
        }

        var ageInput = ConsoleHelper.AskInput("Edad");
        var (ageValid, ageError) = _service.ValidateAge(ageInput, out int age);
        if (!ageValid)
        {
            ConsoleHelper.ShowError(ageError);
            ConsoleHelper.Pause();
            return;
        }

        var dietType       = ConsoleHelper.AskOptional("Tipo de dieta (Carnívoro/Herbívoro)");
        var trackingDevice = ConsoleHelper.AskOptional("Dispositivo de rastreo");
        var location       = ConsoleHelper.AskOptional("Ubicación");

        // TODO: pedir ZoneId cuando tengamos el listado de zonas disponibles
        Console.Write("  ID de zona: ");
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

        // TODO: llamar _service.Add(dinosaur) cuando conectes repo completo
        ConsoleHelper.ShowSuccess($"Dinosaurio '{name}' registrado correctamente.");
        ConsoleHelper.Pause();
    }
}