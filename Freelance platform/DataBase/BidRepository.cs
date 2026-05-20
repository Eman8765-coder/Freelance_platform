namespace Freelance_Platform.Database
{
    using System.Collections.Generic;
    using System.Data.SQLite;
    using Freelance_Platform.Models;

    public class BidRepository : BaseRepository
    {
        public bool AddBid(Bid b)
        {
            string sql = @"INSERT INTO Bids (project_id, freelancer_id, bid_amount, proposal, bid_date)
                           VALUES (@pid, @fid, @amount, @proposal, datetime('now'))";
            var prms = new SQLiteParameter[] {
                new SQLiteParameter("@pid",      b.ProjectId),
                new SQLiteParameter("@fid",      b.FreelancerId),
                new SQLiteParameter("@amount",   b.BidAmount),
                new SQLiteParameter("@proposal", b.Proposal)
            };
            return ExecuteNonQuery(sql, prms) > 0;
        }

        public bool DeleteBid(int bidId)
        {
            string sql = "DELETE FROM Bids WHERE bid_id = @id";
            var prms = new SQLiteParameter[] { new SQLiteParameter("@id", bidId) };
            return ExecuteNonQuery(sql, prms) > 0;
        }

        // All bids on a specific project (for client to review)
        public List<Bid> GetBidsByProject(int projectId)
        {
            string sql = @"SELECT b.*, u.first_name || ' ' || u.last_name AS freelancer_name,
                           p.title AS project_title
                           FROM Bids b
                           JOIN Freelancers f ON b.freelancer_id = f.freelancer_id
                           JOIN Users       u ON f.user_id       = u.user_id
                           JOIN Projects    p ON b.project_id    = p.project_id
                           WHERE b.project_id = @pid
                           ORDER BY b.bid_amount ASC";
            var prms = new SQLiteParameter[] { new SQLiteParameter("@pid", projectId) };
            return ExecuteList(sql, r => MapBid(r), prms);
        }

        // All bids submitted by a freelancer
        public List<Bid> GetBidsByFreelancer(int freelancerId)
        {
            string sql = @"SELECT b.*, u.first_name || ' ' || u.last_name AS freelancer_name,
                           p.title AS project_title
                           FROM Bids b
                           JOIN Freelancers f ON b.freelancer_id = f.freelancer_id
                           JOIN Users       u ON f.user_id       = u.user_id
                           JOIN Projects    p ON b.project_id    = p.project_id
                           WHERE b.freelancer_id = @fid
                           ORDER BY b.bid_id DESC";
            var prms = new SQLiteParameter[] { new SQLiteParameter("@fid", freelancerId) };
            return ExecuteList(sql, r => MapBid(r), prms);
        }

        private Bid MapBid(SQLiteDataReader r) => new Bid
        {
            BidId = GetInt(r, "bid_id"),
            ProjectId = GetInt(r, "project_id"),
            FreelancerId = GetInt(r, "freelancer_id"),
            BidAmount = GetDouble(r, "bid_amount"),
            Proposal = GetString(r, "proposal"),
            BidDate = GetString(r, "bid_date"),
            FreelancerName = GetString(r, "freelancer_name"),
            ProjectTitle = GetString(r, "project_title")
        };
    }
}