namespace Tests;


public static class StringTester
{
    public static bool RunTestFindExtension()
    {

        var testCases = new Dictionary<string, string> {
          {"/var/log/syslog/connection_backup.log",".log"},
          {"/home/user/projects/website/assets/img/header_v2.png",".png"},
          {"/etc/nginx/conf.d/default.conf",".conf"},
            {"/tmp/.hidden_99/cache_data/temp_file_458.tmp_data",".tmp_data"},
              {"/mnt/storage/asdfghjkl_123/xyz_abc/archive.tar_old",".tar_old"},
                {"test.txt",".txt"},
                  {"just_a_file",""},
                    {".gitignore",""}      };

        var tools = new Tools.StringArsenal();
        int successTests = 0;
        bool isSuccess = true;

        foreach (var testCase in testCases)
        {
            string result = tools.FindExtension(testCase.Key);

            if (result != testCase.Value)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("TEST FAIL !");
                Console.WriteLine($"Error in : {result}");
                Console.ResetColor();

                isSuccess = false;
            }
            else
            {
                successTests++;
            }
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nFind File Extension Success - {successTests} test cases passed...");
        Console.ResetColor();
        return isSuccess;
    }

    public static bool RunTesFindFileName()
    {

        var testCases = new Dictionary<string, string> {
          {"/var/log/syslog/connection_backup.log","connection_backup.log"},
          {"/home/user/projects/website/assets/img/header_v2.png","header_v2.png"},
          {"/etc/nginx/conf.d/default.conf","default.conf"},
            {"/tmp/.hidden_99/cache_data/temp_file_458.tmp_data","temp_file_458.tmp_data"},
              {"/mnt/storage/asdfghjkl_123/xyz_abc/archive.tar_old","archive.tar_old"},
                {"test.txt","test.txt"},
                  {"just_a_file",""},
                    {".gitignore",""}      };



        var tools = new Tools.StringArsenal();
        int successTests = 0;
        bool isSuccess = true;

        foreach (var testCase in testCases)
        {
            string result = tools.FindFileName(testCase.Key);
            if (result != testCase.Value)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("TEST FAIL !");
                Console.WriteLine($"Error in : {result}");
                Console.ResetColor();

                isSuccess = false;
            }
            else
            {
                successTests++;
            }
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nFind File Name Success - {successTests} test cases passed...");
        Console.ResetColor();
        return isSuccess;
    }

    public static bool RunTestCleanFormat()
    {
        var tools = new Tools.StringArsenal();

        string[] userArr = { "    ADam", " Tom ", "BOB  ", "", "Alice" };
        string[] contentArr = { "   Wierd File.txt", " new list added ", "42612346612234", "something", "" };

        string[] expectedBodies = {
        "adam wierd-file.txt",
        "tom new-list-added",
        "Secure Content...",
        "",
        ""
    };

        string dateStr = DateTime.Now.ToString("dd.MM.yyyy");
        int successTests = 0;
        bool isSuccess = true;

        for (int i = 0; i < userArr.Length; i++)
        {
            string result = tools.CleanFormat(userArr[i], contentArr[i]);

            string expectedResult = "";
            if (!string.IsNullOrEmpty(expectedBodies[i]))
            {
                if (expectedBodies[i] == "Secure Content...")
                {
                    expectedResult = "Secure Content...";
                }
                else
                {
                    expectedResult = $"-->[{dateStr}] {expectedBodies[i]}";
                }
            }

            if (result == expectedResult)
            {
                successTests++;
            }
            else
            {
                isSuccess = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"FAIL! Input: '{userArr[i]}' & '{contentArr[i]}'");
                Console.WriteLine($"Expected: '{expectedResult}'");
                Console.WriteLine($"Got     : '{result}'");
                Console.ResetColor();
            }
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nClean Format Success - {successTests} test case passed.");
        Console.ResetColor();

        return isSuccess;
    }

    public static bool RunTestSafeFileCreate()
    {
        var testCases = new Dictionary<string, string> {
          {"/var/log/syslog/connection_backup.lo  g",".log"},
          {"/home/user/projects/website/assets/img/header_v2.  p ng",".png"},
          {"/etc/nginx/conf.d/default.co  nf",".conf"},
            {"/tmp/.hidden_99/cache_data/temp_file_458.t mp _data",".tmp_data"},
              {"/mnt/storage/asdfghjkl_123/xyz_abc/archive.tar _o ld",".tar_old"},
                {"test.txt",".  txt"},
                  {"just_a_file",""},
                    {".gitignore",""}      };

        var tools = new Tools.StringArsenal();
        bool isSuccess = true;
        int successTests = 0;

        foreach (var testCase in testCases)
        {
            string result = tools.FindFileName(testCase.Key);
            if (result != testCase.Value)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("TEST FAIL !");
                Console.WriteLine($"Error in : {result}");
                Console.ResetColor();

                isSuccess = false;
            }
            else
            {
                successTests++;
            }
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nSafe File Create Success - {successTests} test cases passed...");
        Console.ResetColor();
        return isSuccess;
    }
}



