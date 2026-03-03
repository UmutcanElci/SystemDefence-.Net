namespace Core;

using Interfaces;
using Database;

public class SimulationManager
{
    public List<ISimulationEvents>? AllEvents;
    public Menu? menu;

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
        while (true)
        {
            await AllEvents.First().ExecuteAsync();

            menu.ShowOptions();
            break;
        }
    }

}
