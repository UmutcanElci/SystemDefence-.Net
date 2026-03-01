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
        Console.WriteLine($"Find File Extension Success - {successTests} test cases passed...");
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
        Console.WriteLine($"Find File Name Success - {successTests} test cases passed...");
        Console.ResetColor();
        return isSuccess;
    }


}



