﻿using System;

namespace FinanceApplication.core.Operations
{
    class Operation
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public bool Profit { get; set; }
        public decimal Sum { get; set; }
        public string Wallet { get; set; }
        public string Cathegory { get; set; }
        public string Description { get; set; }

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
