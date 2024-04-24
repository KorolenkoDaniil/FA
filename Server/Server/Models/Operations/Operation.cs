
using SQLite;

namespace Server.Operations
{
    [Table("Operations")]
    public class Operation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UserID { get; set; }
        public string Date { get; set; }
        public bool Profit { get; set; }
        public decimal Sum { get; set; }
        public int WalletId { get; set; }
        public string Cathegory { get; set; }
        public string Description { get; set; }

        public Operation() { }

        public Operation(int operationId ,int userID, string date, bool profit, decimal sum, int wallet, string cathegory, string description)
        {
            Id = operationId;
            UserID = userID;
            Date = date;
            Profit = profit;
            Sum = sum;
            WalletId = wallet;
            Cathegory = cathegory;
            Description = description;
        }

        public override string ToString() => $"{Id} {UserID} {Date} {Profit} {Sum} {WalletId} {Cathegory} {Description}";


    }
}
