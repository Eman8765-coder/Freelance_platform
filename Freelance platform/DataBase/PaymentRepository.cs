using System.Collections.Generic;
using System.Data.SQLite;
using Freelance_Platform.Models;

namespace Freelance_Platform.Database
{
    public class PaymentRepository : BaseRepository
    {
        public bool AddPayment(Payment p)
        {
            string sql = @"INSERT INTO Payments 
                           (contract_id, amount, payment_date, payment_method)
                           VALUES (@cid, @amount, datetime('now'), @method)";
            var prms = new SQLiteParameter[]
            {
                new SQLiteParameter("@cid",    p.ContractId),
                new SQLiteParameter("@amount", p.Amount),
                new SQLiteParameter("@method", p.PaymentMethod)
            };
            return ExecuteNonQuery(sql, prms) > 0;
        }

        // For CLIENT — payments they made
        public List<Payment> GetPaymentsByClient(int clientId)
        {
            string sql = @"SELECT pay.*, p.title AS project_title
                           FROM Payments pay
                           JOIN Contracts c ON pay.contract_id = c.contract_id
                           JOIN Projects  p ON c.project_id   = p.project_id
                           WHERE p.client_id = @cid
                           ORDER BY pay.payment_id DESC";
            var prms = new SQLiteParameter[]
            {
                new SQLiteParameter("@cid", clientId)
            };
            return ExecuteList(sql, r => MapPayment(r), prms);
        }

        // For FREELANCER — payments they received
        public List<Payment> GetPaymentsByFreelancer(int freelancerId)
        {
            string sql = @"SELECT pay.*, p.title AS project_title
                           FROM Payments pay
                           JOIN Contracts c ON pay.contract_id = c.contract_id
                           JOIN Projects  p ON c.project_id   = p.project_id
                           WHERE c.freelancer_id = @fid
                           ORDER BY pay.payment_id DESC";
            var prms = new SQLiteParameter[]
            {
                new SQLiteParameter("@fid", freelancerId)
            };
            return ExecuteList(sql, r => MapPayment(r), prms);
        }

        // Total earnings for a freelancer
        public double GetTotalEarnings(int freelancerId)
        {
            string sql = @"SELECT COALESCE(SUM(pay.amount), 0)
                           FROM Payments pay
                           JOIN Contracts c ON pay.contract_id = c.contract_id
                           WHERE c.freelancer_id = @fid";
            var prms = new SQLiteParameter[]
            {
                new SQLiteParameter("@fid", freelancerId)
            };
            object result = ExecuteScalar(sql, prms);
            return result != null ? System.Convert.ToDouble(result) : 0;
        }

        private Payment MapPayment(SQLiteDataReader r) => new Payment
        {
            PaymentId = GetInt(r, "payment_id"),
            ContractId = GetInt(r, "contract_id"),
            Amount = GetDouble(r, "amount"),
            PaymentDate = GetString(r, "payment_date"),
            PaymentMethod = GetString(r, "payment_method"),
            ProjectTitle = GetString(r, "project_title")
        };
    }
}