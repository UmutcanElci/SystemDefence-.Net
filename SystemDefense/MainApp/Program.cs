// See https://aka.ms/new-console-template for more information

using Tests;
using Core;


var a = new SimulationManager();

await a.StartSimulation();


if (args.Length > 0 && args[0] == "test")
{
    Tests.GeneralTest.RunAll();
    return;
}
