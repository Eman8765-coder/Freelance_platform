using System.Collections.Generic;
using System.Data.SQLite;
using Freelance_Platform.Models;

namespace Freelance_Platform.Database
{
    public class ProjectRepository : BaseRepository
    {
        public bool AddProject(Project p)
        {
            string sql = @"INSERT INTO Projects (client_id, title, description, budget, deadline, status)
                           VALUES (@cid, @title, @desc, @budget, @deadline, @status)";
            var prms = new SQLiteParameter[] {
                new SQLiteParameter("@cid",      p.ClientId),
                new SQLiteParameter("@title",    p.Title),
                new SQLiteParameter("@desc",     p.Description),
                new SQLiteParameter("@budget",   p.Budget),
                new SQLiteParameter("@deadline", p.Deadline),
                new SQLiteParameter("@status",   p.Status)
            };
            return ExecuteNonQuery(sql, prms) > 0;
        }

        public bool UpdateProject(Project p)
        {
            string sql = @"UPDATE Projects SET title=@title, description=@desc,
                           budget=@budget, deadline=@deadline, status=@status
                           WHERE project_id=@id";
            var prms = new SQLiteParameter[] {
                new SQLiteParameter("@title",    p.Title),
                new SQLiteParameter("@desc",     p.Description),
                new SQLiteParameter("@budget",   p.Budget),
                new SQLiteParameter("@deadline", p.Deadline),
                new SQLiteParameter("@status",   p.Status),
                new SQLiteParameter("@id",       p.ProjectId)
            };
            return ExecuteNonQuery(sql, prms) > 0;
        }

        public bool DeleteProject(int projectId)
        {
            string sql = "DELETE FROM Projects WHERE project_id = @id";
            var prms = new SQLiteParameter[] { new SQLiteParameter("@id", projectId) };
            return ExecuteNonQuery(sql, prms) > 0;
        }

        // All open projects (for freelancers to browse)
        public List<Project> GetOpenProjects()
        {
            string sql = @"SELECT p.*, u.first_name || ' ' || u.last_name AS client_name
                           FROM Projects p
                           JOIN Clients c ON p.client_id = c.client_id
                           JOIN Users   u ON c.user_id   = u.user_id
                           WHERE p.status = 'open'
                           ORDER BY p.project_id DESC";
            return ExecuteList(sql, r => MapProject(r));
        }

        // Projects posted by a specific client
        public List<Project> GetProjectsByClient(int clientId)
        {
            string sql = @"SELECT p.*, u.first_name || ' ' || u.last_name AS client_name
                           FROM Projects p
                           JOIN Clients c ON p.client_id = c.client_id
                           JOIN Users   u ON c.user_id   = u.user_id
                           WHERE p.client_id = @cid
                           ORDER BY p.project_id DESC";
            var prms = new SQLiteParameter[] { new SQLiteParameter("@cid", clientId) };
            return ExecuteList(sql, r => MapProject(r), prms);
        }

        public Project? GetProjectById(int projectId)
        {
            string sql = @"SELECT p.*, u.first_name || ' ' || u.last_name AS client_name
                           FROM Projects p
                           JOIN Clients c ON p.client_id = c.client_id
                           JOIN Users   u ON c.user_id   = u.user_id
                           WHERE p.project_id = @id";
            var prms = new SQLiteParameter[] { new SQLiteParameter("@id", projectId) };
            return ExecuteSingle(sql, r => MapProject(r), prms);
        }

        private Project MapProject(SQLiteDataReader r) => new Project
        {
            ProjectId = GetInt(r, "project_id"),
            ClientId = GetInt(r, "client_id"),
            Title = GetString(r, "title"),
            Description = GetString(r, "description"),
            Budget = GetDouble(r, "budget"),
            Deadline = GetString(r, "deadline"),
            Status = GetString(r, "status"),
            ClientName = GetString(r, "client_name")
        };
    }
}