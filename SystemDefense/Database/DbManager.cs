using Microsoft.Data.Sqlite;

namespace Database;

public class DbManager
{
    private readonly string connectionString = "Data Source=SystemLogs.db";

    public void InitializeDatabase()
    {
        using var connection = new SqliteConnection(connectionString);

        connection.Open();

        using var dbCommand = connection.CreateCommand();

        dbCommand.CommandText = @"
              CREATE TABLE IF NOT EXISTS SystemLogs (
               Id INTEGER PRIMARY KEY AUTOINCREMENT,
                LogDate TEXT,
                Username TEXT NULL,
                FileName TEXT NULL,
                Details TEXT NULL)
          ";

        dbCommand.ExecuteNonQuery();

        dbCommand.CommandText = "SELECT COUNT(*) FROM SystemLogs";

        var count = (long)dbCommand.ExecuteScalar();

        if (count == 0)
        {
            Console.WriteLine("Database is Empty... Data Seed Simulation starting...");
            SeedData(connection);
        }
        else
        {
            Console.WriteLine($"Databse is ready.. {count} Logs found in Database..");
        }

    }

    private void SeedData(SqliteConnection connection)
    {
        var random = new Random();
        string[] users = { "jellodowntown", "Alice", "Bob", "Admin", null, "  Hacker_99  ", "trulyleotard", "woodlarksugar", "gurglevinstra     ", "galeopte rus xanadu ", "4426512ffa2", "o?3yQKNaneon", "  #mJ3mDconeon ", "ztp7&Ljjneon" };
        string[] files = { "files_v12.pdf", "secret/real/deal/an_old_doccc_v3.docx", "home/config.json", null, ".gitignore", "photoooo.png", "2024_CLI-889_PAST-DUE_105.pdf", "2026-01-08_AcmeSupply_INV-1042_v52.pdf", "2024_CLI-889_PAST-DUE_105_LumenParts_03_03-05-2026.pdf", "wierdFFiles.txt", "a/23471/843231/aaa234f261432.ttttba" };
        string[] details = { "123456789012", "987654321098", "AAA Error  XX", null, "System Login - Success", "111122223333", "  System log - c-> 2671412UO3^kfs", "Putarem quodque tamquam ii ob....", "可 耳 矣 關雎 曰： 意. 誨 ，愈聽愈惱 覽 也懊悔不了", "ZZJI3B16AJ DHIEC2D6L8W0ONCKO9K6", "Something happening", "Downloading....", "izbKQEEYBGDSKiDG" };


        using var transaction = connection.BeginTransaction();
        using var insertCommand = connection.CreateCommand();

        insertCommand.CommandText = @"
            INSERT INTO SystemLogs (LogDate, Username, FileName, Details) 
            VALUES ($date, $user, $file, $details)";

        insertCommand.Parameters.AddWithValue("$date", "");
        insertCommand.Parameters.AddWithValue("$user", "");
        insertCommand.Parameters.AddWithValue("$file", "");
        insertCommand.Parameters.AddWithValue("$details", "");

        for (int i = 0; i < 2000; i++)
        {
            string? selectedUser = users[random.Next(users.Length)];
            string? selectedFile = files[random.Next(files.Length)];
            string? selectedDetail = details[random.Next(details.Length)];

            insertCommand.Parameters["$date"].Value = DateTime.Now.AddMinutes(-i).ToString("yyyy-MM-dd HH:mm:ss");
            insertCommand.Parameters["$user"].Value = (object?)selectedUser ?? DBNull.Value;
            insertCommand.Parameters["$file"].Value = (object?)selectedFile ?? DBNull.Value;
            insertCommand.Parameters["$details"].Value = (object?)selectedDetail ?? DBNull.Value;

            insertCommand.ExecuteNonQuery();
        }

        transaction.Commit();

        Console.WriteLine("2000 Log Created....");
    }

    public List<string> GetData(int limit)
    {
        var datas = new List<string>();

        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT FileName FROM SystemLogs WHERE FileName IS NOT NULL ORDER BY RANDOM() LIMIT $limit";
        command.Parameters.AddWithValue("$limit", limit);

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            datas.Add(reader.GetString(0));
        }

        return datas;
    }
}


