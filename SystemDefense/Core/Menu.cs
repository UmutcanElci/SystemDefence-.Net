using Database;

namespace Core;


public class Menu
{
    private readonly SystemAnalyzer _systemAnalyzer = new();

    public async Task<int> ShowOptions()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n ----SYSTEM SAVE MENU---- ");
        Console.WriteLine("[1] -- Pull the Suspicious Files from the Database and Analyze it....");
        Console.WriteLine("[2] -- Reboot The System (will lower your system stability...)");
        Console.ResetColor();
        string? choice = Console.ReadLine();
        int damageTaken = 0;
        if (choice == "1")
        {
            await Task.Delay(1000);
            Console.WriteLine("\nConnecting the Database..");
            await Task.Delay(500);
            Console.WriteLine("\nPulling Logs....");

            var db = new DbManager();

            var logs = db.GetData(3);

            damageTaken = await _systemAnalyzer.AnalyzeLogsAsync((logs));
            if (damageTaken > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"\nSystem stability lower {damageTaken} point....");
                Console.ResetColor();
            }
        }
        else if (choice == "2")
        {
            Random rnd = new Random();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nSystem Rebooting....");
            await Task.Delay(2000);
            damageTaken = rnd.Next(2, 57);
            Console.WriteLine($"\nSystem stability lower {damageTaken} point....");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("\nInvalid input!!");
            damageTaken = 5;
            Console.WriteLine($"\nSystem stability lower {damageTaken} point....");
        }
        Console.WriteLine("\nTo Continue please press ENTER...");
        Console.ReadLine();

        return damageTaken;
    }
}
