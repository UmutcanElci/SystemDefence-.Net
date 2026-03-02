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
        string dateStr = DateTime.Now.ToString("dd.MM.yyyy");
        int successTests = 0;
        bool isSuccess = true;

        var testCases = new List<(string User, string Content, string Expected)>
        {
            ("    ADam", "   Wierd File.txt", $"-->[{dateStr}] adam wierd-file.txt"),
            (" Tom ", " new list added ", $"-->[{dateStr}] tom new-list-added"),
            ("BOB  ", "42612346612234", "Secure Content..."),
            ("", "something", ""),
            ("Alice", "", "")
        };

        foreach (var test in testCases)
        {
            string result = tools.CleanFormat(test.User, test.Content);
            if (result != test.Expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"FAIL (CleanFormat)! In: '{test.User}' & '{test.Content}' | Got: '{result}'");
                Console.ResetColor();
                isSuccess = false;
            }
            else successTests++;
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nClean Format Success - {successTests} test cases passed...");
        Console.ResetColor();
        return isSuccess;
    }

    public static bool RunTestSafeFileCreate()
    {
        var testCases = new Dictionary<string, string> {
          {"/var/log/syslog/connection_backup.lo  g", ".log"},
          {"/etc/nginx/conf.d/default.co  nf", ".conf"},
          {"test.txt", ".txt"},
          {"just_a_file", ""},
          {".gitignore", ""}
        };

        var tools = new Tools.StringArsenal();
        bool isSuccess = true;
        int successTests = 0;

        foreach (var testCase in testCases)
        {
            string result = tools.SafeFileCreate(testCase.Key);
            if (result != testCase.Value)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nFAIL (SafeFileCreate)! In: '{testCase.Key}' | Exp: '{testCase.Value}' | Got: '{result}'");
                Console.ResetColor();
                isSuccess = false;
            }
            else successTests++;
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nSafe File Create Success - {successTests} test cases passed...");
        Console.ResetColor();
        return isSuccess;
    }
    public static bool RunTestCombineLogs()
    {
        var tools = new Tools.StringArsenal();
        bool isSuccess = true;
        int successTests = 0;

        var testCases = new List<(List<string> Input, string Expected)>
        {
            (new List<string> { "Error 1", "Error 2" }, "Error 1\nError 2\n"),
            (new List<string>(), ""),
            (new List<string> { "Single Log" }, "Single Log\n")
        };

        foreach (var test in testCases)
        {
            string result = tools.CombineLogs(test.Input);

            if (result != test.Expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nFAIL (CombineLogs)!");
                Console.WriteLine($"\nBeklenen: '{test.Expected}' | Gelen: '{result}'");
                Console.ResetColor();
                isSuccess = false;
            }
            else successTests++;
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nCombine Logs Success - {successTests} test cases passed...");
        Console.ResetColor();
        return isSuccess;
    }

    public static bool RunTestIdMasking()
    {
        var tools = new Tools.StringArsenal();
        bool isSuccess = true;
        int successTests = 0;


        var testCases = new List<(string Input, string Expected)> {
            ("123456789012", "********9012"),
            ("987654321098", "********1098"),
            ("123", "123"),
            ("", ""),
            ("ABCDEFGH1234", "ABCDEFGH1234"),
            ("123456789012345", "123456789012345"),
            ("000000000000", "********0000"),
            ("111122223333", "********3333")
        };

        foreach (var test in testCases)
        {
            string result = tools.IdMasking(test.Input);
            if (result != test.Expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nFAIL (IdMasking)! In: '{test.Input}' | Exp: '{test.Expected}' | Got: '{result}'");
                Console.ResetColor();
                isSuccess = false;
            }
            else successTests++;
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nId Masking Success - {successTests} test cases passed...");
        Console.ResetColor();
        return isSuccess;
    }

    public static bool RunTestCharacterCount()
    {
        var tools = new Tools.StringArsenal();
        bool isSuccess = true;
        int successTests = 0;


        var testCases = new List<(string Str, char Ch, string Expected)> {
            ("Umut", 'u', "There is 2 'u' characters in the string."),
            ("Linux is awesome", 'e', "There is 2 'e' characters in the string."),
            ("No target here", 'z', "There is no 'z' character in this string!"),
            ("", 'a', ""),
            ("Null char test", '\0', ""),
            ("AAA aaa", 'A', "There is 6 'A' characters in the string."),
            ("Only one", 'y', "There is 1 'y' characters in the string.")
        };

        foreach (var test in testCases)
        {
            string result = tools.CharacterCount(test.Str, test.Ch);
            if (result != test.Expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nFAIL (CharacterCount)! In: '{test.Str}' | Exp: '{test.Expected}' | Got: '{result}'");
                Console.ResetColor();
                isSuccess = false;
            }
            else successTests++;
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nCharacter Count Success - {successTests} test cases passed...");
        Console.ResetColor();
        return isSuccess;
    }

    public static bool RunTestFileVersionControl()
    {
        var tools = new Tools.StringArsenal();
        bool isSuccess = true;
        int successTests = 0;

        var testCases = new Dictionary<string, int> {
            { "rapor_v12.pdf", 12 },
            { "eski_sozlesme_v3.docx", 3 },
            { "normal_dosya.pdf", -1 },
            { "", -1 }
        };

        foreach (var test in testCases)
        {
            int result = tools.FileVersionControl(test.Key);
            if (result != test.Value)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nFAIL (FileVersionControl)! In: '{test.Key}' | Exp: '{test.Value}' | Got: '{result}'");
                Console.ResetColor();
                isSuccess = false;
            }
            else successTests++;
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nFile Version Control Success - {successTests} test cases passed...");
        Console.ResetColor();
        return isSuccess;
    }
}



