using SQLite;

namespace FinanceApp.classes.Wallets
{
    [Table("Wallets")]
    public class Wallet
    {
        [PrimaryKey, AutoIncrement]
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Color { get; set; }
        public bool Include { get; set; }
        public int IconId { get; set; }


        public Wallet () { }
        public Wallet (int userid, string name, string type, decimal amount, string color, bool include, int iconid)
        {
            UserId = userid;
            Name = name;
            Type = type;
            Amount = amount;
            Color = color;
            Include = include;
            IconId = iconid;
        }
        public override string ToString() => $"{WalletId} {UserId} {Name} {Type} {Amount} {Color} {Include} {IconId} ";

    }
}
