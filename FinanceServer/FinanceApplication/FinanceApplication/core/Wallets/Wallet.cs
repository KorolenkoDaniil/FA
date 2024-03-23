using FinanceApp.classes.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceApp.classes.Wallets
{
    public class Wallet
    {
        public int WalletId { get; private set; }
        public int UserId { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public decimal Amount { get; private set; }
        public int ColorId { get; private set; }
        public bool Include { get; private set; }
        public int IconId { get; private set; }


        public Wallet (int userid, string name, string type, decimal amount, int colorID, bool include, int iconid)
        {
            UserId = userid;
            Name = name;
            Type = type;
            Amount = amount;
            ColorId = colorID;
            Include = include;
            IconId = iconid;
        }
        public override string ToString() => $"{WalletId} {UserId} {Name} {Type} {Amount} {ColorId} {Include} {IconId} ";

    }
}
