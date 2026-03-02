namespace Core;

using Interfaces;

public class SimulationManager
{
    public List<ISimulationEvents>? AllEvents;
    public Menu? menu;

    public SimulationManager()
    {
        AllEvents = new List<ISimulationEvents>();
        menu = new Menu();

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
