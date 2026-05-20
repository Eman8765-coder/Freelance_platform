using System;
using System.Data.SQLite;
using System.IO;

namespace Freelance_Platform.Database
{
    public static class DbConnection
    {
        private static string _connectionString = string.Empty;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    // Look for db.sqlite in the Database folder
                    // next to the running .exe file
                    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string dbPath = Path.Combine(baseDirectory, "Database", "db.sqlite");
                    _connectionString = $"Data Source={dbPath};Version=3;FailIfMissing=False;";
                }
                return _connectionString;
            }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }
    }
}