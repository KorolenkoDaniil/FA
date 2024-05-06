using FinanceApp.classes.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceApp.classes.Wallets
{
    public class Wallet
    {
    

        public int WalletId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public int ColorId { get; set; }
        public bool Include { get; set; }

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

        public Wallet (int WalletId, int userid, string name, string type, decimal amount, int colorID, bool include): this(userid, name,  type,  amount,  colorID, include){
           this.WalletId = WalletId;
        }

  
        public override string ToString() => $"{WalletId} {UserId} {Name} {Type} {Amount} цве {ColorId} {Include}";

    }
}
