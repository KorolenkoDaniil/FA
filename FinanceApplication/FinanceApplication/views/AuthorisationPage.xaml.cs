using FinanceApp.classes;
using FinanceApp.classes.Users;
using FinanceApp.classes.Wallets;
using FinanceApplication.core.Category;
using FinanceApplication.core.Colors;
using FinanceApplication.core.Operations;
using FinanceApplication.icons;
using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorisationPage : ContentPage
    {
        private Regex regex = new Regex(@"@gmail.com$");

        public AuthorisationPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = this;
            ErrorLabel.IsVisible = false;
            BadRequestLabel.IsVisible = false;
            Loading.IsVisible = false;
            CheckImage.Source = ImageSource.FromResource(Icons.Iconspath[16]);
        }

        private async void LogInClicked(object sender, EventArgs e)
        {
            try
            {

                LogInButton.IsEnabled = false;
                entryPass1.IsEnabled = false;
                entryEmail.IsEnabled = false;
                Loading.IsVisible = true;
                BadRequestLabel.IsVisible = false;

                if (!Validator.ValidateString(entryEmail.Text, 20) || !Validator.ValidateString(entryPass1.Text, 15)) { ErrorLabel.IsVisible = true; 
                    return; 
                }
                else if (!regex.IsMatch(entryEmail.Text)) 
                { 
                    ErrorLabel.IsVisible = true; 
                    return;
                }
                else
                {
                    Context.ChangeUser(await UserRepository.AuthoriseUser(entryEmail.Text, entryPass1.Text));
                    if (Context.User != null)
                    {
                        Context.ChangeTheme(await ColorRepository.GetColor( Context.User.ColorId));
                        Context.SetWalletsCollection(await WalletRepository.GetWallets(Context.User.UserId));
                        Context.SetCategoryCollection(await CategoryRepository.GetCategorys(Context.User.UserId));
                        Context.SetOperationsCollection(await OperationRepository.GetOperations(Context.User.UserId));
                        await Navigation.PushAsync(new ListPage(DateTime.Now));
                    }
                    else BadRequestLabel.IsVisible = true;
                }
            }
            finally
            {
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    Loading.IsVisible = false; // Добавьте эту строку
                    LogInButton.IsEnabled = true;
                    Loading.IsVisible = false;
                    entryPass1.IsEnabled = true;
                    entryEmail.IsEnabled = true;
                    return false;
                });
            }
        }

        private void entryEmail_Focused(object sender, FocusEventArgs e) => CheckImage.IsVisible = false;

        private void entryEmail_Unfocused(object sender, FocusEventArgs e)
        {
            CheckImage.IsVisible = true;
            if (!Validator.ValidateString(entryEmail.Text, 40) || !regex.IsMatch(entryEmail.Text))
                CheckImage.Source = ImageSource.FromResource(Icons.Iconspath[16]);
            else
                CheckImage.Source = ImageSource.FromResource(Icons.Iconspath[15]);
        }
    }
}