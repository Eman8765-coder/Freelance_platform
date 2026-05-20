using System;
using System.Data.SQLite;
using System.IO;

namespace Freelance_Platform.Database
{
    // This class runs once when the app starts.
    // It creates all tables if they don't already exist.
    // This means you never have to manually create the database file.
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            // Create the Database folder if it doesn't exist
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dbFolder = Path.Combine(baseDirectory, "Database");
            if (!Directory.Exists(dbFolder))
                Directory.CreateDirectory(dbFolder);

            // Create the .sqlite file if it doesn't exist
            string dbPath = Path.Combine(dbFolder, "db.sqlite");
            if (!File.Exists(dbPath))
                SQLiteConnection.CreateFile(dbPath);

            // Now create all tables
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();

                string[] tables = new string[]
                {
                    @"CREATE TABLE IF NOT EXISTS Users (
                        user_id     INTEGER PRIMARY KEY AUTOINCREMENT,
                        first_name  TEXT NOT NULL,
                        last_name   TEXT NOT NULL,
                        email       TEXT UNIQUE NOT NULL,
                        password_hash TEXT NOT NULL,
                        phone       TEXT,
                        role        TEXT NOT NULL CHECK(role IN ('client','freelancer')),
                        is_active   INTEGER DEFAULT 1,
                        created_date TEXT DEFAULT CURRENT_TIMESTAMP
                    );",

                    @"CREATE TABLE IF NOT EXISTS Clients (
                        client_id    INTEGER PRIMARY KEY AUTOINCREMENT,
                        user_id      INTEGER NOT NULL,
                        company_name TEXT,
                        FOREIGN KEY(user_id) REFERENCES Users(user_id)
                    );",

                    @"CREATE TABLE IF NOT EXISTS Freelancers (
                        freelancer_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        user_id       INTEGER NOT NULL,
                        experience    TEXT,
                        hourly_rate   REAL DEFAULT 0,
                        rating        REAL DEFAULT 0,
                        FOREIGN KEY(user_id) REFERENCES Users(user_id)
                    );",

                    @"CREATE TABLE IF NOT EXISTS Skills (
                        skill_id      INTEGER PRIMARY KEY AUTOINCREMENT,
                        freelancer_id INTEGER NOT NULL,
                        skill_name    TEXT NOT NULL,
                        FOREIGN KEY(freelancer_id) REFERENCES Freelancers(freelancer_id)
                    );",

                    @"CREATE TABLE IF NOT EXISTS Projects (
                        project_id  INTEGER PRIMARY KEY AUTOINCREMENT,
                        client_id   INTEGER NOT NULL,
                        title       TEXT NOT NULL,
                        description TEXT,
                        budget      REAL,
                        deadline    TEXT,
                        status      TEXT DEFAULT 'open',
                        FOREIGN KEY(client_id) REFERENCES Clients(client_id)
                    );",

                    @"CREATE TABLE IF NOT EXISTS Bids (
                        bid_id        INTEGER PRIMARY KEY AUTOINCREMENT,
                        project_id    INTEGER NOT NULL,
                        freelancer_id INTEGER NOT NULL,
                        bid_amount    REAL,
                        proposal      TEXT,
                        bid_date      TEXT DEFAULT CURRENT_TIMESTAMP,
                        FOREIGN KEY(project_id)    REFERENCES Projects(project_id),
                        FOREIGN KEY(freelancer_id) REFERENCES Freelancers(freelancer_id)
                    );",

                    @"CREATE TABLE IF NOT EXISTS Contracts (
                        contract_id   INTEGER PRIMARY KEY AUTOINCREMENT,
                        project_id    INTEGER NOT NULL,
                        freelancer_id INTEGER NOT NULL,
                        start_date    TEXT,
                        end_date      TEXT,
                        status        TEXT DEFAULT 'active',
                        FOREIGN KEY(project_id)    REFERENCES Projects(project_id),
                        FOREIGN KEY(freelancer_id) REFERENCES Freelancers(freelancer_id)
                    );",

                    @"CREATE TABLE IF NOT EXISTS Payments (
                        payment_id     INTEGER PRIMARY KEY AUTOINCREMENT,
                        contract_id    INTEGER NOT NULL,
                        amount         REAL,
                        payment_date   TEXT DEFAULT CURRENT_TIMESTAMP,
                        payment_method TEXT,
                        FOREIGN KEY(contract_id) REFERENCES Contracts(contract_id)
                    );",

                    @"CREATE TABLE IF NOT EXISTS Reviews (
                        review_id   INTEGER PRIMARY KEY AUTOINCREMENT,
                        contract_id INTEGER NOT NULL,
                        rating      INTEGER CHECK(rating BETWEEN 1 AND 5),
                        feedback    TEXT,
                        review_date TEXT DEFAULT CURRENT_TIMESTAMP,
                        FOREIGN KEY(contract_id) REFERENCES Contracts(contract_id)
                    );"
                };

                foreach (string sql in tables)
                {
                    using (var cmd = new SQLiteCommand(sql, conn))
                        cmd.ExecuteNonQuery();
                }

                // Insert a default admin/test user if table is empty
                string checkUsers = "SELECT COUNT(*) FROM Users;";
                using (var cmd = new SQLiteCommand(checkUsers, conn))
                {
                    long count = (long)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        // Insert one test client and one test freelancer
                        // Password for both is: password123
                        string insertUsers = @"
                            INSERT INTO Users (first_name, last_name, email, password_hash, phone, role)
                            VALUES 
                            ('Ali', 'Hassan', 'ali@test.com', '$2a$11$KWDnMvbFLGQSBHH6dUHMDOCvqJHFBHoLzrLJc7SbKoGSv3s7XBj8K', '03001234567', 'client'),
                            ('Sara', 'Khan', 'sara@test.com', '$2a$11$KWDnMvbFLGQSBHH6dUHMDOCvqJHFBHoLzrLJc7SbKoGSv3s7XBj8K', '03009876543', 'freelancer');
                        ";
                        using (var cmd2 = new SQLiteCommand(insertUsers, conn))
                            cmd2.ExecuteNonQuery();

                        // Add client record for Ali (user_id = 1)
                        string insertClient = "INSERT INTO Clients (user_id, company_name) VALUES (1, 'Ali Tech')";
                        using (var cmd3 = new SQLiteCommand(insertClient, conn))
                            cmd3.ExecuteNonQuery();

                        // Add freelancer record for Sara (user_id = 2)
                        string insertFreelancer = "INSERT INTO Freelancers (user_id, experience, hourly_rate, rating) VALUES (2, '3 years web development', 25.0, 4.5)";
                        using (var cmd4 = new SQLiteCommand(insertFreelancer, conn))
                            cmd4.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}