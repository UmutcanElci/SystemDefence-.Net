namespace Events;


using Interfaces;

public class DataLeakEvent : ISimulationEvents
{

    public string Name { get; set; } = "Data Leak";
    public int Level { get; set; } = 2;
    public int Time { get; set; } = 15;

    public async Task ExecuteAsync()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n[WARNING] -{Name}- DETECTED... [LEVEL 2 THREAT]");
        await Task.Delay(200);
        Console.WriteLine($"\n[INFO] --> To solve this warning you have {Time} seconds...");
        Console.ResetColor();

        await Task.Delay(500);
        Console.WriteLine("\nSystem logs analyzing......");

        await Task.Delay(2000);
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nAnalyze Done. An unexpected IP address is pulling data!!");
        Console.ResetColor();
    }
}
