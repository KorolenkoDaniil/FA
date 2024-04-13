using FinanceApp.classes.Users;
using FinanceApp.classes.Wallets;
using FinanceApplication.core.Category;
using FinanceApplication.core.Colors;
using FinanceApplication.core.Operations;
using System.Collections.Generic;

namespace FinanceApp.classes
{
    public static class Context
    {
        public static User User { get; private set; }
        public static Colorss Color { get; private set; }
        public static List<Wallet> Wallets { get; private set; }
        public static List<Category> Categories { get; private set; }
        public static List<Operation> Operations { get; private set; }
        public static List<Colorss> Colors { get; private set; }

        public static bool monthPeriod = true;


        public static void ChangeTheme(Colorss color) => Color = color;
        public static void ChangeUser(User user) => User = user;
        public static void SetWalletsCollection(List<Wallet> wallets) => Wallets = wallets;
        public static void SetCategoryCollection(List<Category> categories) => Categories = categories;
        public static void SetOperationsCollection(List<Operation> operations) => Operations = operations;
        public static void SetColorsCollection(List<Colorss> colors) => Colors = colors;
        

    }
}
