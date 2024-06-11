using FinanceApp.classes.Users;
using FinanceApp.classes.Wallets;
using FinanceApplication.core.Category;
using FinanceApplication.core.Colors;
using FinanceApplication.core.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public static decimal IncreaseOperationsSum { get; private set; }
        public static decimal ConsumeOperationsSum { get; private set; } = 0;
        public static bool monthPeriod = true;
        public static decimal OperationsSum { get; private set; }
        public static string colorsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Colors");
        public static string codePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "AuntificationCode");
        public static string[] WalletTypes = new string[]{
            "Денежные средства",
            "Сберегательный счет",
            "Расчетный счет",
            "Пенсионный счет",
            "Дебетовая карта",
            "Копилка",
            "Криптовалютный кошелек",
            "кредитная карта"};
        public static void ChangeTheme(Colorss color) => Color = color;
        public static void ChangeUser(User user) => User = user;
        public static void SetWalletsCollection(List<Wallet> wallets) => Wallets = wallets;
        public static void SetCategoryCollection(List<Category> categories) => Categories = categories;
        public static void SetOperationsCollection(List<Operation> operations)
        {
            Operations = operations;
            CalculateIncreaseSum();
            CalculateConsumeSum();
        }
        public static void SetColorsCollection(List<Colorss> colors) => Colors = colors;
        public static void CalculateIncreaseSum() =>
            IncreaseOperationsSum = Operations.Where(op => op.Profit).Sum(u => u.Sum);
        public static void CalculateConsumeSum() =>
            ConsumeOperationsSum = Operations.Where(op => !op.Profit).Sum(u => u.Sum);
    }
}
