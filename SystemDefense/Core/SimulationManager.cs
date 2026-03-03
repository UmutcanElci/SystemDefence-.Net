namespace Core;

using Interfaces;
using Database;

public class SimulationManager
{
    public List<ISimulationEvents>? AllEvents;
    public Menu? menu;
    public int SystemStability = 100;

    public SimulationManager()
    {
        AllEvents = new List<ISimulationEvents>();
        menu = new Menu();

        var db = new Database.DbManager();
        db.InitializeDatabase();

        AllEvents.Add(new Events.DataLeakEvent());
    }

    public async Task StartSimulation()
    {
        var db = new DbManager();
        var rnd = new Random();
        while (SystemStability >= 0)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"=== [SYSTEM STATUS] STABILITY: {SystemStability}% ===\n");
            Console.ResetColor();

            var streamLogs = db.GetData(15);
            foreach (var log in streamLogs)
            {
                Console.WriteLine($"[TRAFFIC] {DateTime.Now:HH:mm:ss} - Packet scanned: {log}");
                await Task.Delay(500);
            }

            await AllEvents.First().ExecuteAsync();

            int damage = await menu.ShowOptions();

            SystemStability -= damage;
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(@"
          _____          __  __ ______    ______      ________ _____  
         / ____|   /\   |  \/  |  ____|  / __ \ \    / /  ____|  __ \ 
        | |  __   /  \  | \  / | |__    | |  | \ \  / /| |__  | |__) |
        | | |_ | / /\ \ | |\/| |  __|   | |  | |\ \/ / |  __| |  _  / 
        | |__| |/ ____ \| |  | | |____  | |__| | \  /  | |____| | \ \ 
         \_____/_/    \_\_|  |_|______|  \____/   \/   |______|_|  \_\
        ");
        Console.WriteLine("\nSYSTEM STABILITY CRITICAL. KERNEL PANIC.");
        Console.ResetColor();
    }

}
