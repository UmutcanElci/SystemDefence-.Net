// See https://aka.ms/new-console-template for more information

using Tests;


if (args.Length > 0 && args[0] == "test")
{
    Tests.GeneralTest.RunAll();
    return;
}
