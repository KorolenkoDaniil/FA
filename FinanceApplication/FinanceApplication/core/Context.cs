using FinanceApp.classes.Users;
using FinanceApp.classes.Wallets;
using FinanceApplication.core.Category;
using FinanceApplication.core.Colors;
using FinanceApplication.core.Operations;
using System.Collections.Generic;

namespace FinanceApp.classes
{
    public class Context
    {
        public User User { get; private set; }
        public Colorss Color { get; private set; }
        public List<Wallet> Wallets { get; private set; }
        public List<Category> Categories { get; private set; }
        public List<Operation> Operations { get; private set; }
        public List<Colorss> Colors { get; private set; }

        public bool monthPeriod = true;

        public List<string> WalletTypes = new List<string>
        {
            "Денежные средства",
            "Сберегательный счет",
            "Расчетный счет",
            "Пенсионный счет",
            "Дебетовая карта",
            "Копилка",
            "Криптовалютный кошелек",
            "кредитная карта"
        };


        public void ChangeTheme(Colorss color) => Color = color;
        public void ChangeUser(User user) => User = user;
        public void SetWalletsCollection(List<Wallet> wallets) => Wallets = wallets;
        public void SetCategoryCollection(List<Category> categories) => Categories = categories;
        public void SetOperationsCollection(List<Operation> operations) => Operations = operations;
        public void SetColorsCollection(List<Colorss> colors) => Colors = colors;
        

    }
}
