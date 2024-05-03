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
        Context context = new Context();

        private Regex regex = new Regex(@"@gmail.com$");
        public RegistrationPage(Context context)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.context = context;
            BindingContext = this;
            ErrorLabel.IsVisible = false;
            BadRequestLabel.IsVisible = false;
            Loading.IsVisible = false;
            //CheckImage.Source = ImageSource.FromResource(Icons.Iconspath[16]);

        }

        private async void CancelClicked(object sender, EventArgs e) => await Navigation.PopAsync();
        
        private async void CreateClicked(object sender, EventArgs e)
        {
            CanselButton.IsEnabled = false;
            CreateButton.IsEnabled = false;
            entryEmail.IsEnabled = false;
            entryNickname.IsEnabled = false;
            entryPass1.IsEnabled = false;
            entryPass2.IsEnabled = false;
            Loading.IsVisible = true;
            BadRequestLabel.IsVisible = false;

            Regex regex = new Regex(@"@gmail.com$");

            try
            {
                if (!Validator.ValidateString(entryEmail.Text, 40) || !Validator.ValidateString(entryNickname.Text, 15) ||
                    !Validator.ValidateString(entryPass1.Text, 15) || !Validator.ValidateString(entryPass2.Text, 15)) { ErrorLabel.IsVisible = true; return; }

                else if (!string.Equals(entryPass1.Text, entryPass2.Text)) { ErrorLabel.IsVisible = true; return; }
                else if (!regex.IsMatch(entryEmail.Text)) { ErrorLabel.IsVisible = true; return; }
                else
                {
                    context.ChangeUser(await UserRepository.SaveUser(new User(entryNickname.Text, entryEmail.Text, entryPass1.Text, 1)));
                    context.ChangeTheme(await ColorRepository.GetColor(1));
                }

                Console.WriteLine("кропка   2");
                if (context.User != null)
                {
                    List<Wallet> wallets = new List<Wallet>
                {
                    new Wallet(context.User.UserId, "кошелек 1", "денежные средства", 0, 5, true),
                    new Wallet(context.User.UserId, "кошелек 2", "сберегательный счет", 0, 6, true)
                };


                    List<Task<Wallet>> saveTasks = wallets.Select(wallet => WalletRepository.SaveWallet(wallet)).ToList();

                    if (saveTasks.Any(wallet => wallet == null))
                        return;
                    context.SetWalletsCollection(await WalletRepository.GetWallets(context.User.UserId));

                    List<Category> categories = new List<Category>
                {
                    new Category("категория 1", context.User.UserId, 2),
                    new Category("категория 2", context.User.UserId, 3),
                    new Category("категория 3", context.User.UserId, 4),
                    new Category("категория 4", context.User.UserId, 5),
                    new Category("категория 5", context.User.UserId, 6),
                };


                    List<Task<Category>> saveTasksCategories = categories.Select(category => CategoryRepository.SaveCategory(category)).ToList();

                    if (saveTasksCategories.Any(category => category == null))
                        return;

                    Console.WriteLine("кропка   4");
                    context.SetCategoryCollection(await CategoryRepository.GetCategorys(context.User.UserId));

                    foreach (var a in context.Wallets)
                    {
                        Console.WriteLine(a.WalletId);
                    }

                    Console.WriteLine(context.User);

                    List<Operation> operations = new List<Operation>
                {
                    new Operation(context.User.UserId, DateTime.Now.ToString("d"), true, 10, context.Wallets[0].WalletId, context.Categories[0].Name, "qq" ),
                    new Operation(context.User.UserId, DateTime.Now.ToString("d"), true, 10, context.Wallets[1].WalletId, context.Categories[1].Name, "qq" ),
                    new Operation(context.User.UserId, DateTime.Now.ToString("d"), true, 10, context.Wallets[1].WalletId, context.Categories[0].Name, "qq" ),
                };


                    context.SetOperationsCollection(await OperationRepository.GetOperations(context.User.UserId));

                    await Navigation.PushAsync(new ListPage(DateTime.Now, context));
                }
                else BadRequestLabel.IsVisible = true;
            }
            catch
            {
                BadRequestLabel.IsVisible = true;
            }
            finally
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
        }

        private void entryEmail_Focused(object sender, FocusEventArgs e) => CheckImage.IsVisible = false;

        private void entryEmail_Unfocused(object sender, FocusEventArgs e)
        {
            if (regex.IsMatch(entryEmail.Text) && entryEmail.Text.Length <= 40)
            {
                CheckImage.Source = ImageSource.FromResource(Icons.Iconspath[15]);
            }
            else
            {
                CheckImage.Source = ImageSource.FromResource(Icons.Iconspath[16]);
            }
        }
    }
}