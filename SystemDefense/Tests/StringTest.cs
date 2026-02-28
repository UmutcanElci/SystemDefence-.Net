namespace Tests;


public static class StringTester
{
    public static void RunTestFindExtension()
    {

        string[] testPaths = {
        "/var/log/syslog/connection_backup.log",
        "/home/user/projects/website/assets/img/header_v2.png",
        "/etc/nginx/conf.d/default.conf",
        "/tmp/.hidden_99/cache_data/temp_file_458.tmp_data",
        "/mnt/storage/asdfghjkl_123/xyz_abc/archive.tar_old",
        "test.txt",
        "just_a_file",
        ".gitignore"      };

        var tools = new Tools.StringArsenal();

        foreach (string path in testPaths)
        {
            string result = tools.FindExtension(path);

            if (!result.Contains("."))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("TEST FAIL !");
                Console.WriteLine($"Error in : {result}");
                Console.ResetColor();

                Environment.Exit(1);
            }
        }
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("ALL TEST PASS...");
        Console.ResetColor();
    }
}



