namespace NeoGenesis.App.Helpers;

public class ConsoleHelper
{
    public static void ShowTitle(string title)
    {
        Console.WriteLine($"\n=== {title} ===\n");
    }

    public static void ShowSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✓ {message}");
        Console.ResetColor();
    }

    public static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"✗ {message}");
        Console.ResetColor();
    }

    public static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        try { Console.ReadKey(true); } catch { }
    }

    public static string AskRequired(string label)
    {
        string? input;
        while (true)
        {
            Console.Write($"  {label}: ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();
            ShowError("This field is required");
        }
    }

    public static string AskOptional(string label)
    {
        Console.Write($"  {label}: ");
        return Console.ReadLine()?.Trim() ?? "";
    }

    public static string AskLettersOnly(string label)
    {
        while (true)
        {
            string input = AskRequired(label);
            if (ContainsNumber(input))
            {
                ShowError("This field must contain letters only");
                continue;
            }
            return input;
        }
    }

    public static int AskNonNegativeInt(string label)
    {
        while (true)
        {
            Console.Write($"  {label}: ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int value) && value >= 0)
                return value;
            ShowError("Please enter a valid non-negative number");
        }
    }

    public static string AskOptionalDiet(string label)
    {
        while (true)
        {
            string input = AskOptional(label);
            if (string.IsNullOrWhiteSpace(input))
                return "";

            string diet = input.Trim();
            if (!diet.Equals("Carnivore", StringComparison.OrdinalIgnoreCase)
                && !diet.Equals("Herbivore", StringComparison.OrdinalIgnoreCase))
            {
                ShowError("Must be 'Carnivore' or 'Herbivore'");
                continue;
            }

            return char.ToUpperInvariant(diet[0]) + diet[1..].ToLowerInvariant();
        }
    }

    private static bool ContainsNumber(string value)
    {
        foreach (char c in value)
        {
            if (char.IsDigit(c))
                return true;
        }
        return false;
    }
}
