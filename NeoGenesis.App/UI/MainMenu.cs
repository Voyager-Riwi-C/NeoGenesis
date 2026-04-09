namespace NeoGenesis.App.UI;

using NeoGenesis.App.Services;
using NeoGenesis.App.Models;

public class MainMenu
{
    private DInosaurService service;

    public MainMenu(DInosaurService dinoService)
    {
        service = dinoService;
    }

    public void Show()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n=== Main Menu ===");
            Console.WriteLine("1. Create dinosaur");
            Console.WriteLine("2. View all");
            Console.WriteLine("3. View one");
            Console.WriteLine("4. Update dinosaur");
            Console.WriteLine("5. Delete dinosaur");
            Console.WriteLine("6. Exit");
            Console.Write("Choose option: ");

            string option = Console.ReadLine() ?? string.Empty;

            if (option == "1")
                CreateDinosaur();
            else if (option == "2")
                ViewAll();
            else if (option == "3")
                ViewOne();
            else if (option == "4")
                UpdateDinosaur();
            else if (option == "5")
                DeleteDinosaur();
            else if (option == "6")
                exit = true;
            else
                Console.WriteLine("Invalid option");
        }
    }

    private void CreateDinosaur()
    {
        Console.WriteLine("\n--- Create Dinosaur ---");

        Console.Write("First Name: ");
        string firstName = Console.ReadLine() ?? string.Empty;

        Console.Write("Species: ");
        string species = Console.ReadLine() ?? string.Empty;

        Console.Write("Username: ");
        string username = Console.ReadLine() ?? string.Empty;

        Console.Write("Email: ");
        string email = Console.ReadLine() ?? string.Empty;

        Dinosaur dinosaur = new Dinosaur();
        dinosaur.FirstName = firstName;
        dinosaur.Species = species;
        dinosaur.Username = username;
        dinosaur.Email = email;

        try
        {
            service.Create(dinosaur);
            Console.WriteLine("Dinosaur created successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private void ViewAll()
    {
        Console.WriteLine("\n--- Dinosaur List ---");
        List<Dinosaur> list = service.GetAll();

        if (list.Count == 0)
        {
            Console.WriteLine("No dinosaurs registered");
            return;
        }

        foreach (Dinosaur d in list)
        {
            Console.WriteLine($"ID: {d.Id}");
            Console.WriteLine($"First Name: {d.FirstName}");
            Console.WriteLine($"Species: {d.Species}");
            Console.WriteLine($"Username: {d.Username}");
            Console.WriteLine($"Email: {d.Email}");
            Console.WriteLine("---");
        }
    }

    private void ViewOne()
    {
        Console.WriteLine("\n--- View Dinosaur ---");
        Console.Write("Enter dinosaur ID: ");
        string idText = Console.ReadLine() ?? string.Empty;

        if (!int.TryParse(idText, out int id))
        {
            Console.WriteLine("Error: Invalid ID");
            return;
        }

        try
        {
            Dinosaur d = service.GetById(id);
            Console.WriteLine($"\nID: {d.Id}");
            Console.WriteLine($"First Name: {d.FirstName}");
            Console.WriteLine($"Species: {d.Species}");
            Console.WriteLine($"Username: {d.Username}");
            Console.WriteLine($"Email: {d.Email}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private void UpdateDinosaur()
    {
        Console.WriteLine("\n--- Update Dinosaur ---");
        Console.Write("Enter dinosaur ID to update: ");
        string idText = Console.ReadLine() ?? string.Empty;

        if (!int.TryParse(idText, out int id))
        {
            Console.WriteLine("Error: Invalid ID");
            return;
        }

        try
        {
            Dinosaur existing = service.GetById(id);
            Console.WriteLine($"\nCurrent data:");
            Console.WriteLine($"First Name: {existing.FirstName}");
            Console.WriteLine($"Species: {existing.Species}");
            Console.WriteLine($"Username: {existing.Username}");
            Console.WriteLine($"Email: {existing.Email}");

            Console.WriteLine("\nEnter new data (or press Enter to keep current):");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(firstName))
                firstName = existing.FirstName;

            Console.Write("Species: ");
            string species = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(species))
                species = existing.Species;

            Console.Write("Username: ");
            string username = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(username))
                username = existing.Username;

            Console.Write("Email: ");
            string email = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(email))
                email = existing.Email;

            Console.WriteLine($"\nNew data:");
            Console.WriteLine($"First Name: {firstName}");
            Console.WriteLine($"Species: {species}");
            Console.WriteLine($"Username: {username}");
            Console.WriteLine($"Email: {email}");
            Console.Write("\nConfirm update? (yes/no): ");
            string confirm = Console.ReadLine() ?? string.Empty;

            if (confirm.ToLower() != "yes")
            {
                Console.WriteLine("Update cancelled");
                return;
            }

            Dinosaur updated = new Dinosaur();
            updated.FirstName = firstName;
            updated.Species = species;
            updated.Username = username;
            updated.Email = email;

            service.Update(id, updated);
            Console.WriteLine("Dinosaur updated successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private void DeleteDinosaur()
    {
        Console.WriteLine("\n--- Delete Dinosaur ---");
        Console.Write("Enter dinosaur ID to delete: ");
        string idText = Console.ReadLine() ?? string.Empty;

        if (!int.TryParse(idText, out int id))
        {
            Console.WriteLine("Error: Invalid ID");
            return;
        }

        try
        {
            Dinosaur d = service.GetById(id);
            Console.WriteLine($"\nDinosaur data:");
            Console.WriteLine($"First Name: {d.FirstName}");
            Console.WriteLine($"Species: {d.Species}");
            Console.WriteLine($"Username: {d.Username}");
            Console.WriteLine($"Email: {d.Email}");
            Console.Write("\nConfirm delete? (yes/no): ");
            string confirm = Console.ReadLine() ?? string.Empty;

            if (confirm.ToLower() != "yes")
            {
                Console.WriteLine("Delete cancelled");
                return;
            }

            service.Delete(id);
            Console.WriteLine("Dinosaur deleted successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}