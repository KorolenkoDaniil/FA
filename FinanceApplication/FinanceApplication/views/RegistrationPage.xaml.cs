using FinanceApp.classes;
using FinanceApp.classes.Users;
using FinanceApp.classes.Wallets;
using FinanceApplication.core.Category;
using FinanceApplication.core.Colors;
using FinanceApplication.core.Operations;
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

        public RegistrationPage(Context context)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.context = context;
            BindingContext = this;
            ErrorLabel.IsVisible = false;
            BadRequestLabel.IsVisible = false;
        }

        private async void CancelClicked(object sender, EventArgs e) => await Navigation.PopAsync();
        
        private async void CreateClicked(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"@gmail.com");

            if (string.IsNullOrEmpty(entryEmail.Text) || string.IsNullOrEmpty(entryNickname.Text) ||
                string.IsNullOrEmpty(entryPass1.Text) || string.IsNullOrEmpty(entryPass2.Text)) { ErrorLabel.IsVisible = true; return; }
           
            else if (!string.Equals(entryPass1.Text, entryPass2.Text)) { ErrorLabel.IsVisible = true; return; }
            else if (!regex.IsMatch(entryEmail.Text)) { ErrorLabel.IsVisible = true; return; }

            else
            {
                context.ChangeUser(await UserRepository.SaveUser(new User(entryNickname.Text, entryEmail.Text, entryPass1.Text, 1)));
                context.ChangeTheme(await ColorRepository.GetColor(1));
            }

            if (context.User != null)
            {
                List<Wallet> wallets = new List<Wallet>
                {
                    new Wallet(context.User.UserId, "кошелек 1", "денежные средства", 0, context.User.UserId % 20, true),
                    new Wallet(context.User.UserId, "кошелек 2", "сберегательный счет", 0, context.User.UserId % 20, true)
                };

                List<Task<bool>> saveTasks = wallets.Select(wallet => WalletRepository.SaveWallet(wallet)).ToList();

                bool[] results = await Task.WhenAll(saveTasks);

                if (results.All(result => result)) Console.WriteLine("Все кошельки успешно сохранены.");
                else { Console.WriteLine("Не все кошельки были успешно сохранены."); return; }


                List<Category> categories = new List<Category>
                {
                    new Category("категория 1", context.User.UserId, 2),
                    new Category("категория 2", context.User.UserId, 3),
                    new Category("категория 3", context.User.UserId, 4),
                    new Category("категория 4", context.User.UserId, 5),
                    new Category("категория 5", context.User.UserId, 6),
                };

                List<Task<bool>> saveTasksC = categories.Select(category => CategoryRepository.SaveCategory(category)).ToList();

                bool[] resultsC = await Task.WhenAll(saveTasks);

                if (resultsC.All(result => result)) Console.WriteLine("Все  успешно сохранены.");
                else { Console.WriteLine("Не все категории были успешно сохранены."); return; }




                List<Operation> operations = new List<Operation>
                {
                    new Operation(2, context.User.UserId, 1, DateTime.Now, "sdf", 1),
                    new Operation(2, context.User.UserId, 1, DateTime.Now, "sdf", 1),
                    new Operation(2, context.User.UserId, 1, DateTime.Now, "sdf", 1),
                };

                List<Task<bool>> saveTasks1 = operations.Select(o => OperationRepository.SaveOperation(o)).ToList();

                bool[] results1 = await Task.WhenAll(saveTasks1);

                if (results1.All(result => result)) Console.WriteLine("Все  успешно сохранены.");
                else { Console.WriteLine("Не все категории были успешно сохранены."); return; }

                context.SetOperationsCollection (await OperationRepository.GetOperations(context.User.UserId));


                await Navigation.PushAsync(new ListPage(context));
            }
            else BadRequestLabel.IsVisible = true; return; 
           
        }
    }
}