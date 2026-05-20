namespace Freelance_Platform.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int ContractId { get; set; }
        public double Amount { get; set; }
        public string PaymentDate { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;   // Cash / Bank Transfer / JazzCash / EasyPaisa

        // For display
        public string ProjectTitle { get; set; } = string.Empty;
    }
}