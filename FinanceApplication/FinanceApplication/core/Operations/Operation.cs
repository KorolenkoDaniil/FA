using FinanceApp.classes.Wallets;
using System;
namespace FinanceApplication.core.Operations
{
    public class Operation
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string Date { get; set; }
        public bool Profit { get; set; }
        public decimal Sum { get; set; }
        public int WalletId { get; set; }
        public string Cathegory { get; set; }
        public string Description { get; set; }
        public Operation() { }
        public Operation(int userID, string date, bool profit, decimal sum, int wallet, string cathegory, string description)
        {
            UserID = userID;
            Date = date;
            Profit = profit;
            Sum = sum;
            WalletId = wallet;
            Cathegory = cathegory;
            Description = description;
        }
        public override string ToString() => $"{Id} {UserID} {Date} {Profit} {Sum} id кошелька {WalletId} id категории {Cathegory} {Description}";
        public override bool Equals(object obj) => obj is Operation operation && operation.Id == Id;
    }
}
