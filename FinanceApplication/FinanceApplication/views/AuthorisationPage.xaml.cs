using FinanceApp.classes;
using FinanceApp.classes.Users;
using FinanceApp.classes.Wallets;
using FinanceApplication.core.Category;
using FinanceApplication.core.Colors;
using FinanceApplication.core.Operations;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorisationPage : ContentPage
    {
        Context context = new Context();
        public AuthorisationPage(Context context)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.context = context;
            BindingContext = this;
            ErrorLabel.IsVisible = false;
            BadRequestLabel.IsVisible = false;
        }

        private async void LogInClicked(object sender, System.EventArgs e)
        {
            Regex regex = new Regex(@"@gmail.com");

            if (string.IsNullOrEmpty(entryEmail.Text) || string.IsNullOrEmpty(entryPass1.Text)) { ErrorLabel.IsVisible = true; return; }
            else if (!regex.IsMatch(entryEmail.Text)) { ErrorLabel.IsVisible = true; return; }
            else
            {
                context.ChangeUser(await UserRepository.AuthoriseUser(entryEmail.Text, entryPass1.Text));
                if (context.User != null)
                {
                    context.ChangeTheme(await ColorRepository.GetColor(context.User.ColorId));
                    context.SetWalletsCollection(await WalletRepository.GetWallets(context.User.UserId));
                    context.SetCategoryCollection(await CategoryRepository.GetCategorys(context.User.UserId));
                    context.SetOperationsCollection(await OperationRepository.GetOperations(context.User.UserId));
                    await Navigation.PushAsync(new ListPage(context));
                }
                else
                {
                    BadRequestLabel.IsVisible = true;
                }
            }
        }
    }
}