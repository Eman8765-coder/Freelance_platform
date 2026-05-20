namespace Freelance_Platform.Database
{
    using System.Collections.Generic;
    using System.Data.SQLite;
    using Freelance_Platform.Models;

    public class ReviewRepository : BaseRepository
    {
        public bool AddReview(Review rv)
        {
            string sql = @"INSERT INTO Reviews (contract_id, rating, feedback, review_date)
                           VALUES (@cid, @rating, @feedback, datetime('now'))";
            var prms = new SQLiteParameter[] {
                new SQLiteParameter("@cid",      rv.ContractId),
                new SQLiteParameter("@rating",   rv.Rating),
                new SQLiteParameter("@feedback", rv.Feedback)
            };
            return ExecuteNonQuery(sql, prms) > 0;
        }

        public List<Review> GetReviewsByContract(int contractId)
        {
            string sql = @"SELECT rv.*, p.title AS project_title,
                           u.first_name || ' ' || u.last_name AS freelancer_name
                           FROM Reviews rv
                           JOIN Contracts   c ON rv.contract_id  = c.contract_id
                           JOIN Projects    p ON c.project_id    = p.project_id
                           JOIN Freelancers f ON c.freelancer_id = f.freelancer_id
                           JOIN Users       u ON f.user_id       = u.user_id
                           WHERE rv.contract_id = @cid";
            var prms = new SQLiteParameter[] { new SQLiteParameter("@cid", contractId) };
            return ExecuteList(sql, r => MapReview(r), prms);
        }

        public List<Review> GetReviewsByFreelancer(int freelancerId)
        {
            string sql = @"SELECT rv.*, p.title AS project_title,
                           u.first_name || ' ' || u.last_name AS freelancer_name
                           FROM Reviews rv
                           JOIN Contracts   c ON rv.contract_id  = c.contract_id
                           JOIN Projects    p ON c.project_id    = p.project_id
                           JOIN Freelancers f ON c.freelancer_id = f.freelancer_id
                           JOIN Users       u ON f.user_id       = u.user_id
                           WHERE c.freelancer_id = @fid";
            var prms = new SQLiteParameter[] { new SQLiteParameter("@fid", freelancerId) };
            return ExecuteList(sql, r => MapReview(r), prms);
        }

        private Review MapReview(SQLiteDataReader r) => new Review
        {
            ReviewId = GetInt(r, "review_id"),
            ContractId = GetInt(r, "contract_id"),
            Rating = GetInt(r, "rating"),
            Feedback = GetString(r, "feedback"),
            ReviewDate = GetString(r, "review_date"),
            ProjectTitle = GetString(r, "project_title"),
            FreelancerName = GetString(r, "freelancer_name")
        };
    }
}