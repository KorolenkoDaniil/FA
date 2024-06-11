using Xamarin.Forms;

namespace FinanceApplication.core
{
    public class ExtendedDayOperation
    {
        public int Id { get; set; }
        public bool Profit { get; set; }
        public string Date { get; set; }
        public decimal Sum { get; set; }
        public int WalletId { get; set; }
        public string Cathegory { get; set; }
        public string Description { get; set; }
        public string WalletName { get; set; }
        public ImageSource walletIcon { get; set; }
        public Color color { get; set; }
        public ExtendedDayOperation(int id, bool profit, string date, decimal sum, int walletId, string cathegory, string description, string walletName, ImageSource walletIcon, Color color)
        {
            Id = id;
            Profit = profit;
            Date = date;
            Sum = sum;
            WalletId = walletId;
            Cathegory = cathegory;
            Description = description;
            WalletName = walletName;
            this.walletIcon = walletIcon;
            this.color = color;
        }

        public override string ToString()
        {
            return $"Id {Id} Profit {Profit} Date {Date} Sum {Sum} WalletId {WalletId} Cathegory {Cathegory} Description {Description} WalletName {WalletName} walletIcon {walletIcon} color {color}";
        }

    }
}
