using System;
using System.Data.SQLite;
using Freelance_Platform.Models;

namespace Freelance_Platform.Database
{
    public class UserRepository : BaseRepository
    {
        public User? Login(string email, string password)
        {
            string sql = "SELECT * FROM Users WHERE email = @email AND is_active = 1";

            var parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@email", email)
            };

            var user = ExecuteSingle(sql, reader => new User
            {
                UserId = GetInt(reader, "user_id"),
                FirstName = GetString(reader, "first_name"),
                LastName = GetString(reader, "last_name"),
                Email = GetString(reader, "email"),
                PasswordHash = GetString(reader, "password_hash"),
                Phone = GetString(reader, "phone"),
                Role = GetString(reader, "role"),
                IsActive = GetBoolean(reader, "is_active")
            }, parameters);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return user;

            return null;
        }

        public bool Register(User user, string plainPassword)
        {
            // Check if email already exists
            string checkSql = "SELECT COUNT(*) FROM Users WHERE email = @email";
            var checkParams = new SQLiteParameter[]
            {
                new SQLiteParameter("@email", user.Email)
            };
            long count = Convert.ToInt64(ExecuteScalar(checkSql, checkParams));
            if (count > 0) return false;

            // Hash password
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(plainPassword);

            // Step 1 — Insert into Users table
            string userSql = @"INSERT INTO Users
                (first_name, last_name, email, password_hash, phone, role)
                VALUES
                (@firstName, @lastName, @email, @passwordHash, @phone, @role)";

            var userParams = new SQLiteParameter[]
            {
                new SQLiteParameter("@firstName",    user.FirstName),
                new SQLiteParameter("@lastName",     user.LastName),
                new SQLiteParameter("@email",        user.Email),
                new SQLiteParameter("@passwordHash", passwordHash),
                new SQLiteParameter("@phone",        user.Phone),
                new SQLiteParameter("@role",         user.Role)
            };

            int rows = ExecuteNonQuery(userSql, userParams);
            if (rows == 0) return false;

            // Step 2 — Get the new user_id
            string idSql = "SELECT user_id FROM Users WHERE email = @email";
            var idParams = new SQLiteParameter[]
            {
                new SQLiteParameter("@email", user.Email)
            };
            object idResult = ExecuteScalar(idSql, idParams);
            if (idResult == null) return false;

            int newUserId = Convert.ToInt32(idResult);

            // Step 3 — Insert into Clients or Freelancers table
            if (user.Role == "client")
            {
                string clientSql = @"INSERT INTO Clients (user_id, company_name)
                                     VALUES (@userId, @company)";
                var clientParams = new SQLiteParameter[]
                {
                    new SQLiteParameter("@userId",  newUserId),
                    new SQLiteParameter("@company", user.CompanyName ?? "")
                };
                ExecuteNonQuery(clientSql, clientParams);
            }
            else if (user.Role == "freelancer")
            {
                string freeSql = @"INSERT INTO Freelancers
                    (user_id, experience, hourly_rate, rating)
                    VALUES (@userId, @exp, @rate, 0)";
                var freeParams = new SQLiteParameter[]
                {
                    new SQLiteParameter("@userId", newUserId),
                    new SQLiteParameter("@exp",    user.Experience  ?? ""),
                    new SQLiteParameter("@rate",   user.HourlyRate)
                };
                ExecuteNonQuery(freeSql, freeParams);
            }

            return true;
        }

        public int GetClientId(int userId)
        {
            string sql = "SELECT client_id FROM Clients WHERE user_id = @userId";
            var parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@userId", userId)
            };
            object result = ExecuteScalar(sql, parameters);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public int GetFreelancerId(int userId)
        {
            string sql = "SELECT freelancer_id FROM Freelancers WHERE user_id = @userId";
            var parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@userId", userId)
            };
            object result = ExecuteScalar(sql, parameters);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public User? GetUserById(int userId)
        {
            string sql = "SELECT * FROM Users WHERE user_id = @id";
            var parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@id", userId)
            };
            return ExecuteSingle(sql, reader => new User
            {
                UserId = GetInt(reader, "user_id"),
                FirstName = GetString(reader, "first_name"),
                LastName = GetString(reader, "last_name"),
                Email = GetString(reader, "email"),
                PasswordHash = GetString(reader, "password_hash"),
                Phone = GetString(reader, "phone"),
                Role = GetString(reader, "role"),
                IsActive = GetBoolean(reader, "is_active")
            }, parameters);
        }
    }
}