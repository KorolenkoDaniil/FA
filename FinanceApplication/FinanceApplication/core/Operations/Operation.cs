using System;

namespace FinanceApplication.core.Operations
{
    public class Operation
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int Day { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public bool Profit { get; set; }
        public decimal Sum { get; set; }
        public int WalletId { get; set; }
        public string Cathegory { get; set; }
        public string Description { get; set; }

        public Operation() { }

        public Operation(int userID, int day, string month, int year, bool profit, decimal sum, int wallet, string cathegory, string description)
        {
            UserID = userID;
            Day = day;
            Month = month;
            Year = year;
            Profit = profit;
            Sum = sum;
            WalletId = wallet;
            Cathegory = cathegory;
            Description = description;
        }

        public override string ToString() => $"{Id} {UserID} {Day} {Month} {Year} {Profit} {Sum} {WalletId} {Cathegory} {Description}";

    }
}
