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
        public RegistrationPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = this;
            ErrorLabel.IsVisible = false;
            BadRequestLabel.IsVisible = false;
        }

        private async void CancelClicked(object sender, EventArgs e) => await Navigation.PopAsync();
        
        private async void CreateClicked(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"@gmail.com");

            Console.WriteLine("точка 1");

            if (string.IsNullOrEmpty(entryEmail.Text) || string.IsNullOrEmpty(entryNickname.Text) ||
                string.IsNullOrEmpty(entryPass1.Text) || string.IsNullOrEmpty(entryPass2.Text)) { ErrorLabel.IsVisible = true; return; }
           
            else if (!string.Equals(entryPass1.Text, entryPass2.Text)) { ErrorLabel.IsVisible = true; return; }
            else if (!regex.IsMatch(entryEmail.Text)) { ErrorLabel.IsVisible = true; return; }

            else
            {
                Context.ChangeUser(await UserRepository.SaveUser(new User(entryNickname.Text, entryEmail.Text, entryPass1.Text, 1)));
                Context.ChangeTheme(await ColorRepository.GetColor(1));
            }

            Console.WriteLine("точка 2");


            if (Context.User != null)
            {
                List<Wallet> wallets = new List<Wallet>
                {
                    new Wallet(Context.User.UserId, "кошелек 1", "денежные средства", 0, Context.User.UserId % 20, true),
                    new Wallet(Context.User.UserId, "кошелек 2", "сберегательный счет", 0, Context.User.UserId % 20, true)
                };

                Console.WriteLine("точка 3");

                List<Task<bool>> saveTasks = wallets.Select(wallet => WalletRepository.SaveWallet(wallet)).ToList();

                bool[] results = await Task.WhenAll(saveTasks);

                if (results.All(result => result)) Console.WriteLine("Все кошельки успешно сохранены.");
                else { Console.WriteLine("Не все кошельки были успешно сохранены."); return; }
                
                
                Console.WriteLine("точка 4");


                Context.SetWalletsCollection(wallets);


                List<Category> categories = new List<Category>
                {
                    new Category("категория 1", Context.User.UserId, 2),
                    new Category("категория 2", Context.User.UserId, 3),
                    new Category("категория 3", Context.User.UserId, 4),
                    new Category("категория 4", Context.User.UserId, 5),
                    new Category("категория 5", Context.User.UserId, 6),
                };

                Context.SetCategoryCollection(categories);


                List<Task<bool>> saveTasksC = categories.Select(category => CategoryRepository.SaveCategory(category)).ToList();

                Console.WriteLine("точка 5");

                bool[] resultsC = await Task.WhenAll(saveTasks);

                if (resultsC.All(result => result)) Console.WriteLine("Все  успешно сохранены.");
                else { Console.WriteLine("Не все категории были успешно сохранены."); return; }




                List<Operation> operations = new List<Operation>
                {
                    new Operation(Context.User.UserId, DateTime.Now.Day, DateTime.Now.ToString("MMMM"), DateTime.Now.Year, true, 10, Context.Wallets[0].WalletId + 1, Context.Categories[0].Name, "qq" ),
                    new Operation(Context.User.UserId, DateTime.Now.Day, DateTime.Now.ToString("MMMM"), DateTime.Now.Year, true, 10, Context.Wallets[0].WalletId + 1, Context.Categories[0].Name, "qq" ),
                    new Operation(Context.User.UserId, DateTime.Now.Day, DateTime.Now.ToString("MMMM"), DateTime.Now.Year, true, 10, Context.Wallets[0].WalletId + 1, Context.Categories[0].Name, "qq" ),
                };

                Console.WriteLine("точка 6");

                List<Task<bool>> saveTasks1 = operations.Select(o => OperationRepository.SaveOperation(o)).ToList();

                bool[] results1 = await Task.WhenAll(saveTasks1);

                if (results1.All(result => result)) Console.WriteLine("Все  успешно сохранены.");
                else { Console.WriteLine("Не все категории были успешно сохранены."); return; }

                Console.WriteLine("точка 7");

                Context.SetOperationsCollection(operations);


                await Navigation.PushAsync(new ListPage(DateTime.Now));
            }
            else BadRequestLabel.IsVisible = true; return; 
           
        }
    }
}