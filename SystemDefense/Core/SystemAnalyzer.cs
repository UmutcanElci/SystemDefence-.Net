using Tools;

namespace Core;


public class SystemAnalyzer
{
    private readonly StringArsenal _stringArsenal = new();
    private Random rnd = new();
    private (string CorrectTool, string MissionText) MissionSelector()
    {

        int mission = rnd.Next(1, 4);

        return mission switch
        {
            1 => ("1", "[MISSION] Find the extensions of the suspicious files immediately!"),
            2 => ("2", "[MISSION] Mask the sensitive data (IPs, IDs) in the logs before they leak!"),
            3 => ("3", "[MISSION] The logs are scattered. Combine them into a single report!"),
            _ => ("1", "[MISSION] Find the extensions of the suspicious files immediately!")
        };
    }


    public async Task<int> AnalyzeLogsAsync(List<(string DisplayLog, string RawFileName)> logs)
    {
        var currentMission = MissionSelector();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nChoose the right Tool...");
        Console.WriteLine($"\n{currentMission.MissionText}");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("\n[1] -- Open StringArsenal (Tools for Fixing Suspicious Files)");
        Console.WriteLine("[2] -- Cancel Analyzing and Reboot the System...");
        Console.ResetColor();

        await Task.Delay(1000);
        string? choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== STRING ARSENAL ===");
            Console.WriteLine("[1] FindExtension");
            Console.WriteLine("[2] MaskSensitiveData");
            Console.WriteLine("[3] CombineLogs");
            Console.WriteLine("Which tool do you want to use? (1/2/3): ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            string? toolChoice = Console.ReadLine();

            if (toolChoice == currentMission.CorrectTool)
            {
                if (toolChoice == "1")
                {
                    foreach (var log in logs)
                    {
                        string ext = _stringArsenal.FindExtension(log.RawFileName);
                        string extDisplay = string.IsNullOrEmpty(ext) ? "NONE (HIDDEN!!)" : ext;
                        Console.WriteLine($"\nFile : {log.RawFileName,-20} --> Extension : {extDisplay}");
                        await Task.Delay(400);
                    }
                    return 0;
                }
                else if (toolChoice == "2")
                {
                    foreach (var log in logs)
                    {
                        string maskedLog = _stringArsenal.IdMasking(log.DisplayLog);
                        Console.WriteLine(maskedLog);
                        await Task.Delay(400);
                    }
                    return 0;
                }
                else if (toolChoice == "3")
                {
                    {
                        var stringLogs = logs.Select(l => l.DisplayLog).ToList();
                        string combinedReport = _stringArsenal.CombineLogs(stringLogs);

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\n[COMPRESSING DATA] Compressing logs into a single data payload...");
                        await Task.Delay(1000);

                        string visualStream = combinedReport.Replace("\n", " ][ ").Replace("\r", "");

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"[START] {visualStream} [END]\n");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"[INFO] 3 separate logs successfully combined. Total Payload Size: {combinedReport.Length} bytes.");
                        Console.ResetColor();

                        await Task.Delay(800);
                    }

                    Console.WriteLine("\nInitializing...");
                    await Task.Delay(600);
                    Console.WriteLine("System saved successfully...");
                    Console.ResetColor();
                    return 0;
                }
                else if (toolChoice == "1" || toolChoice == "2" || toolChoice == "3")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n[FAILED] You selected a valid tool, but it's the WRONG one for this mission!");
                    Console.WriteLine("The attack succeeded while you were trying to use the wrong equipment...");
                    Console.ResetColor();

                    return rnd.Next(15, 30);
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n[ERROR] Invalid tool selection! You panicked and hit the wrong keys.");
                    Console.ResetColor();

                    return 10;
                }
            }
            else if (choice == "2")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nRebooting the system and ignoring the logs...");
                Console.ResetColor();
                return rnd.Next(30, 57);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Input!");
                Console.ResetColor();
                return 10;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nRebooting the system and ignoring the logs...");
            Console.ResetColor();
            return rnd.Next(30, 57);
        }
    }
}
