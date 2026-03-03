using Database;

namespace Core;


public class Menu
{

    public void ShowOptions()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n ----SYSTEM SAVE MENU---- ");
        Console.WriteLine("[1] -- Pull the Suspicious Files from the Database and Analyze it....");
        Console.WriteLine("[2] -- Reboot The System (will lower your system stability...)");
        Console.ResetColor();
        string? choice = Console.ReadLine();

        if (choice == "1")
        {
            Task.Delay(1000);
            Console.WriteLine("\nConnecting the Database..");
            Task.Delay(500);
            Console.WriteLine("\nPulling Logs....");

            var db = new DbManager();

            var logs = db.GetData(3);

            Console.WriteLine("\nSuspicious Files :");
            foreach (var log in logs)
            {
                Console.WriteLine($"- {log}");
            }

        }
        else if (choice == "2")
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nSystem Rebooting....");
            Task.Delay(2000);
            Console.WriteLine("\nSystem stability lower {number} point....");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("\nInvalid input!!");
        }
        Console.WriteLine("\nTo Continue please press ENTER...");
        Console.ReadLine();
    }
}
