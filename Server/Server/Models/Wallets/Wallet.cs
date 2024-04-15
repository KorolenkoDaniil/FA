using SQLite;

namespace Server.Wallets
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
        public int ColorId { get; set; }
        public bool Include { get; set; }
        public int IconId { get; set; }


        public Wallet () { }
        public Wallet (int walletId, int userid, string name, string type, decimal amount, int colorId, bool include, int iconid)
        {
            WalletId = walletId;
            UserId = userid;
            Name = name;
            Type = type;
            Amount = amount;
            ColorId = colorId;
            Include = include;
            IconId = iconid;
        }
        public override string ToString() => $"{WalletId} {UserId} {Name} {Type} {Amount} {ColorId} {Include} {IconId} ";

    }
}
