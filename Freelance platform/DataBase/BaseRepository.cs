using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace   Freelance_Platform.Database
{
    // All repository classes inherit from this base class.
    // It provides reusable database methods so we don't repeat
    // connection code in every repository.
    public abstract class BaseRepository
    {
        protected SQLiteConnection GetConnection()
        {
            return DbConnection.GetConnection();
        }

        // Use for INSERT, UPDATE, DELETE — returns number of rows affected
        protected int ExecuteNonQuery(string sql, SQLiteParameter[]? parameters = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // Use for SELECT that returns a single value (e.g. COUNT, last inserted ID)
        protected object ExecuteScalar(string sql, SQLiteParameter[]? parameters = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        // Use for SELECT that returns many rows — fills a DataTable (used for DataGridView)
        protected DataTable ExecuteReader(string sql, SQLiteParameter[]? parameters = null)
        {
            var dataTable = new DataTable();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        // Use for SELECT that returns one object (e.g. find user by ID)
        protected T ExecuteSingle<T>(string sql, Func<SQLiteDataReader, T> mapper, SQLiteParameter[]? parameters = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return mapper(reader);
                        return default(T)!;
                    }
                }
            }
        }

        // Use for SELECT that returns a list of objects (e.g. all projects)
        protected List<T> ExecuteList<T>(string sql, Func<SQLiteDataReader, T> mapper, SQLiteParameter[]? parameters = null)
        {
            var results = new List<T>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            results.Add(mapper(reader));
                    }
                }
            }
            return results;
        }

        // Helper methods to safely read values from SQLiteDataReader
        protected string GetString(SQLiteDataReader reader, string columnName)
        {
            int i = reader.GetOrdinal(columnName);
            return reader.IsDBNull(i) ? string.Empty : reader.GetString(i);
        }

        protected int GetInt(SQLiteDataReader reader, string columnName)
        {
            int i = reader.GetOrdinal(columnName);
            return reader.IsDBNull(i) ? 0 : reader.GetInt32(i);
        }

        protected double GetDouble(SQLiteDataReader reader, string columnName)
        {
            int i = reader.GetOrdinal(columnName);
            return reader.IsDBNull(i) ? 0.0 : reader.GetDouble(i);
        }

        protected bool GetBoolean(SQLiteDataReader reader, string columnName)
        {
            int i = reader.GetOrdinal(columnName);
            return !reader.IsDBNull(i) && reader.GetInt32(i) == 1;
        }

        protected DateTime GetDateTime(SQLiteDataReader reader, string columnName)
        {
            int i = reader.GetOrdinal(columnName);
            return reader.IsDBNull(i) ? DateTime.MinValue : reader.GetDateTime(i);
        }

        protected long GetLastInsertRowId()
        {
            object result = ExecuteScalar("SELECT last_insert_rowid();");
            return result != null ? Convert.ToInt64(result) : 0;
        }
    }
}