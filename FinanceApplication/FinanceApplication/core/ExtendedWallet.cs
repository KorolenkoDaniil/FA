using FinanceApp.classes;
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
        public string LightMode { get; set; }
        public int ColorId { get; set; }
        public int IconId { get; set; }
        public ImageSource WalletIconPath { get; set; }
        public Context context { get; set; }

        public ExtendedWallet() { }
        public ExtendedWallet(int walletId, int userId, string name, string type, bool include, decimal amount, string darkMode, string lightMode, int colorId, int iconId, Context context)
        {
            WalletId = walletId;
            UserId = userId;
            Name = name;
            Type = type;
            Include = include;
            Amount = amount;
            DarkMode = darkMode;
            LightMode = lightMode;
            ColorId = colorId;
            IconId = iconId;
            WalletIconPath = ImageSource.FromResource(Icons.WalletsIcons[IconId]); ;
            this.context = context;
        }

        public override string ToString()
        {
            return $"WalletId {WalletId} UserId {UserId} Name {Name} Type {Type} ColorId {ColorId} Amount {Amount} DarkMode {DarkMode} LightMode {LightMode} IconId {IconId}";
        }

        public void ChangeColors()
        {
            Colorss color = context.Colors.FirstOrDefault(col => col.ColorId == ColorId);
            DarkMode = color.DarkMode;
            LightMode = color.LightMode;
        }
    }
}
