
using SQLite;

namespace Server.Operations
{
    [Table("Operations")]
    public class Operation
    {
        [PrimaryKey]
        public int Id { get; private set; }
        public int UserID { get; private set; }
        public string Day { get; private set; }
        public string Month { get; private set; }
        public string Year { get; private set; }
        public bool Profit { get; private set; }
        public decimal Sum { get; private set; }
        public string Wallet { get; private set; }
        public string Cathegory { get; private set; }
        public string Description { get; private set; }

        public Operation() { }

        public Operation(int id, int userID, string day, string month, string year, bool profit, decimal sum, string wallet, string cathegory, string description)
        {
            Id = id;
            UserID = userID;
            Day = day;
            Month = month;
            Year = year;
            Profit = profit;
            Sum = sum;
            Wallet = wallet;
            Cathegory = cathegory;
            Description = description;
        }

        public override string ToString() => $"{Id} {UserID} {Day} {Month} {Year} {Profit} {Sum} {Wallet} {Cathegory} {Description}";

    }
}
