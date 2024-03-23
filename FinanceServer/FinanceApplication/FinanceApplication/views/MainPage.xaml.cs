using FinanceApp.classes;
using FinanceApp.classes.Users;
using FinanceApp.classes.Wallets;
using FinanceApplication.core.Category;
using FinanceApplication.core.Colors;
using FinanceApplication.core.Operations;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FinanceApplication
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            P();
        }

        //public async void P()
        //{
        //    Context context = new Context();

        //    User user = new User("A", "a", "a", 1);
        //    context.ChangeUser(await UserRepository.SaveUser(user));
        //    Console.WriteLine(context.User);

        //    Console.WriteLine("цвет");
        //    Console.WriteLine(await ColorRepository.GetColor(1));

        //    await WalletRepository.SaveWallet(new Wallet(context.User.UserId, "b", "b", 11, 1, true, 0));
        //    await WalletRepository.SaveWallet(new Wallet(context.User.UserId, "b", "b", 11, 1, true, 0));
        //    List <Wallet> wallets = await WalletRepository.GetWallets(context.User.UserId);
        //    Console.WriteLine("счета");
        //    foreach (var a in wallets) Console.WriteLine(a);


        //    await CategoryRepository.SaveCategory(new Category("C", context.User.UserId, 1));
        //    await CategoryRepository.SaveCategory(new Category("C", context.User.UserId, 1));
        //    List<Category> categories = await CategoryRepository.GetCategorys(context.User.UserId);
        //    Console.WriteLine("категории");
        //    foreach (var a in wallets) Console.WriteLine(a);


        //    await OperationRepository.SaveOperation(new Operation(20, context.User.UserId, wallets[0].WalletId, DateTime.Now, "D", categories[0].CategoryId));
        //    await OperationRepository.SaveOperation(new Operation(20, context.User.UserId, wallets[0].WalletId, DateTime.Now, "D", categories[0].CategoryId));
        //    List<Operation> operations = await OperationRepository.GetOperations(context.User.UserId);
        //    Console.WriteLine("операции");
        //    foreach (var a in wallets) Console.WriteLine(a);
        //}
    }
}
