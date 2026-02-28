namespace Tests;


public static class GeneralTest
{
    public static void RunAll()
    {
        Console.Clear();
        Console.WriteLine("--- GENERAL TESTS STARTING ---");

        bool allPassed = true;

        if (!StringTester.RunTestFindExtension()) { allPassed = false; }

        if (allPassed)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-- ALL TESTS PASS SUCCESFULLY --");
            Console.ResetColor();
            Environment.Exit(0);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-- SOME TEST FAILED --");
            Console.ResetColor();
            Environment.Exit(1);
        }


    }
}
