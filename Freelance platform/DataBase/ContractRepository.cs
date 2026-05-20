namespace Freelance_Platform.Database
{
    using System.Collections.Generic;
    using System.Data.SQLite;
    using Freelance_Platform.Models;

    public class ContractRepository : BaseRepository
    {
        public bool AddContract(Contract c)
        {
            string sql = @"INSERT INTO Contracts (project_id, freelancer_id, start_date, end_date, status)
                           VALUES (@pid, @fid, @start, @end, @status)";
            var prms = new SQLiteParameter[] {
                new SQLiteParameter("@pid",    c.ProjectId),
                new SQLiteParameter("@fid",    c.FreelancerId),
                new SQLiteParameter("@start",  c.StartDate),
                new SQLiteParameter("@end",    c.EndDate),
                new SQLiteParameter("@status", c.Status)
            };
            return ExecuteNonQuery(sql, prms) > 0;
        }

        public bool UpdateStatus(int contractId, string status)
        {
            string sql = "UPDATE Contracts SET status = @status WHERE contract_id = @id";
            var prms = new SQLiteParameter[] {
                new SQLiteParameter("@status", status),
                new SQLiteParameter("@id",     contractId)
            };
            return ExecuteNonQuery(sql, prms) > 0;
        }

        public List<Contract> GetContractsByFreelancer(int freelancerId)
        {
            string sql = @"SELECT c.*, p.title AS project_title,
                           u.first_name || ' ' || u.last_name AS freelancer_name
                           FROM Contracts c
                           JOIN Projects    p ON c.project_id    = p.project_id
                           JOIN Freelancers f ON c.freelancer_id = f.freelancer_id
                           JOIN Users       u ON f.user_id       = u.user_id
                           WHERE c.freelancer_id = @fid
                           ORDER BY c.contract_id DESC";
            var prms = new SQLiteParameter[] { new SQLiteParameter("@fid", freelancerId) };
            return ExecuteList(sql, r => MapContract(r), prms);
        }

        public List<Contract> GetContractsByClient(int clientId)
        {
            string sql = @"SELECT c.*, p.title AS project_title,
                           u.first_name || ' ' || u.last_name AS freelancer_name
                           FROM Contracts c
                           JOIN Projects    p ON c.project_id    = p.project_id
                           JOIN Freelancers f ON c.freelancer_id = f.freelancer_id
                           JOIN Users       u ON f.user_id       = u.user_id
                           WHERE p.client_id = @cid
                           ORDER BY c.contract_id DESC";
            var prms = new SQLiteParameter[] { new SQLiteParameter("@cid", clientId) };
            return ExecuteList(sql, r => MapContract(r), prms);
        }

        private Contract MapContract(SQLiteDataReader r) => new Contract
        {
            ContractId = GetInt(r, "contract_id"),
            ProjectId = GetInt(r, "project_id"),
            FreelancerId = GetInt(r, "freelancer_id"),
            StartDate = GetString(r, "start_date"),
            EndDate = GetString(r, "end_date"),
            Status = GetString(r, "status"),
            ProjectTitle = GetString(r, "project_title"),
            FreelancerName = GetString(r, "freelancer_name")
        };
    }
}