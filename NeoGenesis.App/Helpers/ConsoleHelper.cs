namespace NeoGenesis.App.Helpers;

public static class ConsoleHelper
{
    public static string AskRequired(string label)
    {
        while (true)
        {
            var value = AskInput(label).Trim();
            if (!string.IsNullOrWhiteSpace(value))
                return value;

            ShowError($"{label} is required");
        }
    }

    public static string AskLettersOnly(string label)
    {
        while (true)
        {
            var value = AskRequired(label);
            bool valid = true;

            foreach (char c in value)
            {
                if (!char.IsLetter(c) && c != ' ' && c != '-')
                {
                    valid = false;
                    break;
                }
            }

            if (valid)
                return value;

            ShowError($"{label} must contain letters only");
        }
    }

    public static int AskNonNegativeInt(string label)
    {
        while (true)
        {
            var input = AskInput(label).Trim();
            if (int.TryParse(input, out int value) && value >= 0)
                return value;

            ShowError($"{label} must be a non-negative number");
        }
    }

    public static string AskOptionalDiet(string label)
    {
        while (true)
        {
            var value = AskOptional(label).Trim();
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            if (value.Equals("Carnivore", StringComparison.OrdinalIgnoreCase))
                return "Carnivore";

            if (value.Equals("Herbivore", StringComparison.OrdinalIgnoreCase))
                return "Herbivore";

            ShowError("Diet type must be Carnivore or Herbivore");
        }
    }

    public static string AskInput(string label)
    {
        Console.Write($"  {label}: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string AskOptional(string label)
    {
        Console.Write($"  {label} (optional): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static bool Confirm(string message)
    {
        Console.Write($"\n  {message} (Y/N): ");
        return Console.ReadLine()?.Trim().ToUpper() == "Y";
    }

    public static void ShowSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n {message}");
        Console.ResetColor();
    }

    public static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n  {message}");
        Console.ResetColor();
    }

    public static void ShowWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n  {message}");
        Console.ResetColor();
    }

    public static void ShowTitle(string title)
    {
        try { Console.Clear(); } catch { }
        Console.WriteLine($"\n  == {title} ==\n");
    }

    public static void Pause()
    {
        Console.WriteLine("\n  Press Enter to continue...");
        Console.ReadLine();
    }
}