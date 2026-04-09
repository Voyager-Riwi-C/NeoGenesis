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
        Console.Clear();
        Console.WriteLine($"\n  ══ {title} ══\n");
    }

    public static void Pause()
    {
        Console.WriteLine("\n  Press any key to continue...");
        Console.ReadKey();
    }
}