
using SQLite;

namespace FinanceApplication.core.Operations
{
    [Table("Operations")]
    public class Operation
    {
        public int OperationId { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public int WalletId { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public int Categoryid { get; set; }


        public Operation () { }
        public Operation(decimal amount, int userid, int walletid, DateTime date, string details, int categoryid)
        {
            Amount = amount;
            UserId = userid;
            WalletId = walletid;
            Date = date;
            Details = details;
            Categoryid = categoryid;
        }

        public override string ToString() => 
            $"{OperationId} {Amount} {UserId} {WalletId} {Date} {Details} {Categoryid}";
    }
}
