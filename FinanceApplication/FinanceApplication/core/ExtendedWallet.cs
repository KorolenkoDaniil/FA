using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceApplication.core
{
    public class ExtendedWallet
    {
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string DarkMode { get; set; }
        public string LightMode { get; set; }
        public string DarkText { get; set; }
        public string LightText { get; set; }
    }
}
