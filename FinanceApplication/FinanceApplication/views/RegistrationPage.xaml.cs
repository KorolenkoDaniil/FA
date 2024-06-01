using FinanceApp.classes;
using FinanceApp.classes.Users;
using FinanceApp.classes.Wallets;
using FinanceApplication.core.Category;
using FinanceApplication.core.Colors;
using FinanceApplication.core.Operations;
using FinanceApplication.icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        private Regex regex = new Regex(@"@gmail.com$");
        public Random random = new Random();
        public RegistrationPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = this;
            ErrorLabel.IsVisible = false;
            BadRequestLabel.IsVisible = false;
            Loading.IsVisible = false;
            CheckImage.Source = ImageSource.FromResource(Icons.Iconspath[16]);
        }

        private async void CreateClicked(object sender, EventArgs e)
        {
            DisableControls();
            try
            {
                if (!ValidateInputs()) return;
                await SaveUserAndChangeTheme();
                if (Context.User != null)
                {
                    await HandleWallets();
                    await HandleCategories();
                    await HandleOperations();
                    await Navigation.PushAsync(new ListPage());
                }
                else BadRequestLabel.IsVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("=============" + ex.Message);
            }
            finally
            {
                EnableControlsAfterDelay();
            }
        }

        private void DisableControls()
        {
            CanselButton.IsEnabled = false;
            CreateButton.IsEnabled = false;
            entryEmail.IsEnabled = false;
            entryNickname.IsEnabled = false;
            entryPass1.IsEnabled = false;
            entryPass2.IsEnabled = false;
            Loading.IsVisible = true;
            BadRequestLabel.IsVisible = false;
        }

        private bool ValidateInputs()
        {
            if (!Validator.ValidateString(entryEmail.Text, 40) || !Validator.ValidateString(entryNickname.Text, 15) ||
                !Validator.ValidateString(entryPass1.Text, 15) || !Validator.ValidateString(entryPass2.Text, 15))
            {
                ErrorLabel.IsVisible = true;
                return false;
            }
            else if (!string.Equals(entryPass1.Text, entryPass2.Text))
            {
                ErrorLabel.IsVisible = true;
                return false;
            }
            else if (!regex.IsMatch(entryEmail.Text))
            {
                ErrorLabel.IsVisible = true;
                return false;
            }
            return true;
        }

        private async Task SaveUserAndChangeTheme()
        {
            Context.ChangeUser(await UserRepository.SaveUser(new User(entryNickname.Text, entryEmail.Text, entryPass1.Text, 1, true)));
            Context.ChangeTheme(await ColorRepository.GetColor(1));
        }

        private async Task HandleWallets()
        {
            List<Wallet> wallets = new List<Wallet>
    {
        new Wallet(Context.User.UserId, "кошелек 1", "Денежные средства", 0,  random.Next(0, Context.Colors.Count - 1), true, 1),
        new Wallet(Context.User.UserId, "кошелек 2", "Сберегательный счет", 0,  random.Next(0, Context.Colors.Count - 1), true, 3)
    };
            List<Task<Wallet>> saveTasks = wallets.Select(wallet => WalletRepository.SaveWallet(wallet)).ToList();
            if (saveTasks.Any(wallet => wallet == null))
                return;
            Context.SetWalletsCollection(await WalletRepository.GetWallets(Context.User.UserId));
        }

        private async Task HandleCategories()
        {
            List<Category> categories = new List<Category>
    {
        new Category("категория 1", Context.User.UserId, random.Next(0, Context.Colors.Count - 1), 0, true),
        new Category("категория 2", Context.User.UserId, random.Next(0, Context.Colors.Count - 1), 1, true),
        new Category("категория 3", Context.User.UserId, random.Next(0, Context.Colors.Count - 1), 2, true),
        new Category("категория 4", Context.User.UserId, random.Next(0, Context.Colors.Count - 1), 3, false),
        new Category("категория 5", Context.User.UserId, random.Next(0, Context.Colors.Count - 1), 4, false),
        new Category("категория 6", Context.User.UserId, random.Next(0, Context.Colors.Count - 1), 4, false),
    };
            List<Task<Category>> saveTasksCategories = categories.Select(category => CategoryRepository.SaveCategory(category)).ToList();
            if (saveTasksCategories.Any(category => category == null))
                return;

            await Task.WhenAll(saveTasksCategories);

            Context.SetCategoryCollection(await CategoryRepository.GetCategories(Context.User.UserId));
        }

            private async Task HandleOperations()
        {
            Context.SetOperationsCollection(await OperationRepository.GetOperations(Context.User.UserId));
        }

        private void EnableControlsAfterDelay()
        {
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                Loading.IsVisible = false;
                CanselButton.IsEnabled = true;
                CreateButton.IsEnabled = true;
                entryEmail.IsEnabled = true;
                entryNickname.IsEnabled = true;
                entryPass1.IsEnabled = true;
                entryPass2.IsEnabled = true;
                return false;
            });
        }

        private void entryEmail_Focused(object sender, FocusEventArgs e) => CheckImage.IsVisible = false;


        private void entryEmail_Unfocused(object sender, FocusEventArgs e)
        {
            CheckImage.IsVisible = true;
            if (!Validator.ValidateString(entryEmail.Text, 40) || !regex.IsMatch(entryEmail.Text))
                CheckImage.Source = Icons.Iconspath[16];
            else
                CheckImage.Source = Icons.Iconspath[15];
        }

        private async void CancelClicked(object sender, EventArgs e) => await Navigation.PopAsync();

    }
}