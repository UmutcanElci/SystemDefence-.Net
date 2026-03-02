namespace Core;


public class Menu
{

    public void ShowOptions()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nSELECTION 1...");
        Console.WriteLine("SELECTION 2...");
        Console.WriteLine("SELECTION 3...");
        Console.ResetColor();
    }
}
