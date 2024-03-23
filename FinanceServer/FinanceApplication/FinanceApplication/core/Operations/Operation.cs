using System;

namespace FinanceApplication.core.Operations
{
    public class Operation
    {
        public int OperationId { get; private set; }
        public decimal Amount { get; private set; }
        public int UserId { get; private set; }
        public int WalletId { get; private set; }
        public DateTime Date { get; private set; }
        public string Details { get; private set; }
        public int Categoryid { get; private set; }

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
