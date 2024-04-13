using FinanceApp.classes;
using FinanceApp.classes.Users;
using FinanceApp.classes.Wallets;
using FinanceApplication.core.Category;
using FinanceApplication.core.Colors;
using FinanceApplication.core.Operations;
using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorisationPage : ContentPage
    {
        public AuthorisationPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = this;
            ErrorLabel.IsVisible = false;
            BadRequestLabel.IsVisible = false;
        }

        private async void LogInClicked(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"@gmail.com");

            if (string.IsNullOrEmpty(entryEmail.Text) || string.IsNullOrEmpty(entryPass1.Text)) { ErrorLabel.IsVisible = true; return; }
            else if (!regex.IsMatch(entryEmail.Text)) { ErrorLabel.IsVisible = true; return; }
            else
            {
                Context.ChangeUser(await UserRepository.AuthoriseUser(entryEmail.Text, entryPass1.Text));
                if (Context.User != null)
                {
                    Console.WriteLine(Context.User + "-----------------------------");
                    Context.ChangeTheme(await ColorRepository.GetColor(Context.User.ColorId));
                    Context.SetWalletsCollection(await WalletRepository.GetWallets(Context.User.UserId));
                    Context.SetCategoryCollection(await CategoryRepository.GetCategorys(Context.User.UserId));
                    Context.SetOperationsCollection (await OperationRepository.GetOperations(Context.User.UserId));
                    await Navigation.PushAsync(new ListPage(DateTime.Now));
                }
                else
                {
                    BadRequestLabel.IsVisible = true;
                }
            }
        }
    }
}