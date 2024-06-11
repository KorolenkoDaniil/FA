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
        public int IconId { get; set; }
        public Wallet() { }
        public Wallet(int userid, string name, string type, decimal amount, int colorID, bool include, int iconid)
        {
            UserId = userid;
            Name = name;
            Type = type;
            Amount = amount;
            ColorId = colorID;
            Include = include;
            IconId = iconid;
        }
        public Wallet(int WalletId, int userid, string name, string type, decimal amount, int colorID, bool include, int iconid) : this(userid, name, type, amount, colorID, include, iconid)
        {
            this.WalletId = WalletId;
        }
        public override string ToString() => $"WalletId {WalletId} UserId {UserId} Name {Name} Type {Type} Amount {Amount} ColorId {ColorId} Include {Include} IconId {IconId}";
        public override bool Equals(object obj) => obj is Wallet wallet && wallet.WalletId == WalletId;
    }
}
