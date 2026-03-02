namespace Interfaces;

public interface ISimulationEvents
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Time { get; set; }
    Task ExecuteAsync();
}
