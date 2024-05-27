using FinanceApp.classes;
using FinanceApp.classes.Wallets;
using FinanceApplication.core.Colors;
using FinanceApplication.icons;
using System.Linq;
using Xamarin.Forms;

namespace FinanceApplication.core
{
    public class ExtendedWallet
    {
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Include {  get; set; }
        public decimal Amount { get; set; }
        public string DarkMode { get; set; }
        public int ColorId { get; set; }
        public int IconId { get; set; }
        public ImageSource WalletIconPath { get; set; }
        public ExtendedWallet() { }
        public ExtendedWallet(int walletId, int userId, string name, string type, bool include, decimal amount, string darkMode, int colorId, int iconId)
        {
            WalletId = walletId;
            UserId = userId;
            Name = name;
            Type = type;
            Include = include;
            Amount = amount;
            DarkMode = darkMode;
            ColorId = colorId;
            IconId = iconId;
            WalletIconPath = Icons.WalletsIcons[IconId];
            CalculateSum();
        }

        public override string ToString()
        {
            return $"WalletId {WalletId} UserId {UserId} Name {Name} Type {Type} ColorId {ColorId} Amount {Amount} DarkMode {DarkMode} IconId {IconId}";
        }

        public void ChangeColors()
        {
            Colorss color = Context.Colors.FirstOrDefault(col => col.ColorId == ColorId);
            DarkMode = color.DarkMode;
        }

        public void CalculateSum() => 
           Amount = Context.Operations.Where(operation => operation.WalletId == WalletId && operation.Profit).Sum(o => o.Sum) - Context.Operations.Where(operation => operation.WalletId == WalletId && !operation.Profit).Sum(o => o.Sum);
        
    }
}
