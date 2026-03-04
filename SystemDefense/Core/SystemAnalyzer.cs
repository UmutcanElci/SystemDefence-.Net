using Tools;

namespace Core;


public class SystemAnalyzer
{
    private (string CorrectTool, string MissionText) MissionSelector()
    {
        Random rnd = new Random();

        int mission = rnd.Next(1, 4);

        return mission switch
        {
            1 => ("1", "[MISSION] FIND EXTENSION"),
            2 => ("1", "[MISSION] ID MASKING"),
            3 => ("1", "[MISSION] COMBINE LOGS"),
            _ => ("1", "[MISSION] FIND EXTENSION")
        };
    }

    private void PrintSuspiciousFiles(List<(string DisplayLog, string RawFileName)> logs)
    {
        foreach (var log in logs)
        {
            // Not sure about it....
        }
    }

    public async Task<int> AnalyzeLogsAsync(List<(string DisplayLog, string RawFileName)> logs)
    {

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        // Mission


        Console.WriteLine("\n[1] -- StringArsenal Tools (Tools for Fix Suspicous Files)");
        Console.WriteLine("\n[2] -- Cancel Analyzing and Reboot the System...");
        Console.ResetColor();
        await Task.Delay(1000);
        string? choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            string? toolChoice = Console.ReadLine();

            if (toolChoice == "1")
            {
                foreach (var log in logs)
                {
                    // Find Extension
                }
            }
            else if (toolChoice == "2")
            {
                // Id Masking
            }
            else if (toolChoice == "3")
            {
                // Combine Logs
            }
            else
            {
                // Invalid Input
            }
        }
        else if (choice == "2")
        {
            Random rnd = new Random(); // Bad....

            return rnd.Next(30, 57);
        }
        else
        {
            Console.WriteLine("\nInvalid Input!");
            return 10;
        }
        return 0;

    }
}
