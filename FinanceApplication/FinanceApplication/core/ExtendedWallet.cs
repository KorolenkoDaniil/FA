using FinanceApp.classes;
using FinanceApplication.core.Colors;
using System.Linq;

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
        public string DarkText { get; set; }
        public string LightText { get; set; }
        public int ColorId { get; set; }
        public Context context { get; set; }


        public void ChangeColors()
        {
            Colorss color = context.Colors.FirstOrDefault(col => col.ColorId == ColorId);
            DarkMode = color.DarkMode;
            LightMode = color.LightMode;
            DarkText = color.DarkText;
            LightMode = color.LightMode;
     
        }
    }
}
