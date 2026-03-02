namespace Tests;


public static class GeneralTest
{
    public static void RunAll()
    {
        Console.Clear();
        Console.WriteLine("--- GENERAL TESTS STARTING ---");

        bool allPassed = true;

        if (!StringTester.RunTestFindExtension()) { allPassed = false; }

        if (!StringTester.RunTesFindFileName()) { allPassed = false; }

        if (!StringTester.RunTestCleanFormat()) { allPassed = false; }

        if (!StringTester.RunTestSafeFileCreate()) { allPassed = false; }

        if (!StringTester.RunTestCombineLogs()) { allPassed = false; }

        if (!StringTester.RunTestIdMasking()) { allPassed = false; }

        if (!StringTester.RunTestCharacterCount()) { allPassed = false; }

        if (!StringTester.RunTestFileVersionControl()) { allPassed = false; }

        if (allPassed)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n-- ALL TESTS PASS SUCCESFULLY --");
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
