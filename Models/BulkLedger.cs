using System.ComponentModel.DataAnnotations;

namespace student.Models
{
    public class BulkLedger
    {
        [Key]
        public string? Sr { get; set; } = "";
        public string? Date { get; set; } = "";
        public string? Academic_Year { get; set; } = "";
        public string? Session { get; set; } = "";
        public string? Alloted_Category { get; set; } = "";
        public string? Voucher_Type { get; set; } = "";
        public string? Voucher_No { get; set; } = "";
        public string? Roll_No { get; set; } = "";
        public string? Admno_UniqueId { get; set; } = "";
        public string? Status { get; set; } = "";
        public string? Fee_Category { get; set; } = "";
        public string? Faculty { get; set; } = "";
        public string? Program { get; set; } = "";
        public string? Department { get; set; } = "";
        public string? Batch { get; set; } = "";
        public string? Receipt_No { get; set; } = "";
        public string? Fee_Head { get; set; } = "";
        public string? Due_Amount { get; set; } = "";
        public string? Paid_Amount { get; set; } = "";
        public string? Concession_Amount { get; set; } = "";
        public string? Scholarship_Amount { get; set; } = "";
        public string? Reverse_Concession_Amount { get; set; } = "";
        public string? Write_Off_Amount { get; set; } = "";
        public string? Adjusted_Amount { get; set; } = "";
        public string? Refund_Amount { get; set; } = "";
        public string? Fund_TranCfer_Amount { get; set; } = "";
        public string? Remarks { get; set; } = "";
    }
}
