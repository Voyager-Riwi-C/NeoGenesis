namespace NeoGenesis.App.Helpers;

public static class ConsoleHelper
{
    public static string AskInput(string label)
    {
        Console.Write($"  {label}: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string AskOptional(string label)
    {
        Console.Write($"  {label} (opcional): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static bool Confirm(string message)
    {
        Console.Write($"\n  {message} (S/N): ");
        return Console.ReadLine()?.Trim().ToUpper() == "S";
    }

    public static void ShowSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n  ✓ {message}");
        Console.ResetColor();
    }

    public static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n  ✗ {message}");
        Console.ResetColor();
    }

    public static void ShowWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n  ⚠ {message}");
        Console.ResetColor();
    }

    public static void ShowTitle(string title)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n  ══ {title} ══\n");
        Console.ResetColor();
    }

    public static void Pause()
    {
        Console.WriteLine("\n  Presiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
}