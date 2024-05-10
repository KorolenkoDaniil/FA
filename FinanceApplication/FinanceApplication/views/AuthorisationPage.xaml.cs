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
        Context context = new Context();
            
        private Regex regex = new Regex(@"@gmail.com$");

        public AuthorisationPage(Context context)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.context = context;
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

                if (!Validator.ValidateString(entryEmail.Text, 20) || !Validator.ValidateString(entryPass1.Text, 15)) { ErrorLabel.IsVisible = true; return; }
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
                        await Navigation.PushAsync(new ListPage(DateTime.Now, context));
                    }
                    else BadRequestLabel.IsVisible = true;
                }
            }
//<<<<<<< HEAD
//            catch
//            {
//                BadRequestLabel.IsVisible = true;
//            }
//=======
//            catch { BadRequestLabel.IsVisible = true; }
//>>>>>>> \
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