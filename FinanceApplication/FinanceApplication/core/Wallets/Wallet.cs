using FinanceApp.classes.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceApp.classes.Wallets
{
    public class Wallet
    {
        private string v1;
        private int v2;
        private string v3;
        private int v4;
        private bool v5;

        public int WalletId { get; private set; }
        public int UserId { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public decimal Amount { get; private set; }
        public int ColorId { get; private set; }
        public bool Include { get; private set; }
        //public int IconId { get; private set; }

        public Wallet () { }

        public Wallet (int userid, string name, string type, decimal amount, int colorID, bool include)
        {
            UserId = userid;
            Name = name;
            Type = type;
            Amount = amount;
            ColorId = colorID;
            Include = include;
            //IconId = iconid;
        }

        public Wallet(string v1, int v2, int userId, string v3, int v4, bool v5)
        {
            this.v1 = v1;
            this.v2 = v2;
            UserId = userId;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
        }

        public override string ToString() => $"{WalletId} {UserId} {Name} {Type} {Amount} {ColorId} {Include}";

    }
}
