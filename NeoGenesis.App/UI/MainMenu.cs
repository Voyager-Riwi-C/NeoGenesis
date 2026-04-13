using NeoGenesis.App.Services;
using NeoGenesis.App.Services;
using NeoGenesis.App.Helpers;

namespace NeoGenesis.App.UI;

public class MainMenu
{
    private readonly DinosaurService _service;

    public MainMenu(DinosaurService service) => _service = service;

    public void Show()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine(" NeoGenesis Park");
            Console.ResetColor();
            Console.WriteLine("  1. Register a Dinosaur");
            Console.WriteLine("  2. View Dinosaurs");
            Console.WriteLine("  3. Update Dinosaur");
            Console.WriteLine("  4. Delete Dinosaur");
            Console.WriteLine("  0. Exit\n");
            Console.Write("  Select an option: ");

            switch (Console.ReadLine())
            {
                case "1": new InsertMenu(_service).Show();  break;
                case "2": new QueryMenu(_service).Show();   break;
                case "3": new UpdateMenu(_service).Show();  break;
                case "4": new DeleteMenu(_service).Show();  break;
                case "0": running = false;                  break;
                default:
                    ConsoleHelper.ShowError("Invalid option.");
                    ConsoleHelper.Pause();
                    break;
            }
        }
    }
}