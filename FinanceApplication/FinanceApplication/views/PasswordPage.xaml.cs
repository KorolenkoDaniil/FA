using FinanceApp.classes;
using FinanceApp.classes.Users;
using FinanceApp.classes.Wallets;
using FinanceApplication.core;
using FinanceApplication.core.Category;
using FinanceApplication.core.Colors;
using FinanceApplication.core.Operations;
using FinanceApplication.icons;
using Newtonsoft.Json;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordPage : ContentPage
    {
        string enteredChar = "";
        Button[] buttons = new Button[4];
        AutorisationJson userdata;

        public PasswordPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            string userData = File.ReadAllText(Context.codePath);
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$  4");
            Console.WriteLine(userData);
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$  4");
            userdata = JsonConvert.DeserializeObject<AutorisationJson>(userData);

            Console.WriteLine($"{userdata.userEmail} {userdata.password} {userdata.code}");
            Arase.Source = ImageSource.FromResource(Icons.Iconspath[19]);
            buttons[0] = circle1;
            buttons[1] = circle2;
            buttons[2] = circle3;
            buttons[3] = circle4;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$  5");

            Loading.IsVisible = false; // Добавьте эту строку
            b0.IsEnabled = true;
            b1.IsEnabled = true;
            b2.IsEnabled = true;
            b3.IsEnabled = true;
            b4.IsEnabled = true;
            b5.IsEnabled = true;
            b6.IsEnabled = true;
            b7.IsEnabled = true;
            b8.IsEnabled = true;
            b9.IsEnabled = true;
            Arase.IsEnabled = true;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button && enteredChar.Length >= 0 && enteredChar.Length < 4)
            {
                enteredChar += button.Text;
                buttons[enteredChar.Length - 1].BackgroundColor = Color.Black;
                Console.WriteLine(enteredChar + " " + enteredChar.Length + "         " + (enteredChar.Length - 1));
                if (enteredChar.Length == 4)
                {
                    if (userdata.code.Equals(enteredChar))
                    {
                        DisableButtons();
                        Context.ChangeUser(await UserRepository.AuthoriseUser(userdata.userEmail, userdata.password));
                        if (Context.User != null)
                        {
                            Context.ChangeTheme(await ColorRepository.GetColor(Context.User.ColorId));
                            Context.SetWalletsCollection(await WalletRepository.GetWallets(Context.User.UserId));
                            Context.SetCategoryCollection(await CategoryRepository.GetCategories(Context.User.UserId));
                            Context.SetOperationsCollection(await OperationRepository.GetOperations(Context.User.UserId));
                            await Navigation.PushAsync(new ListPage());
                            SetDefaulyColor();
                        }
                    }
                    else
                    {
                        SetDefaulyColor();
                    }
                    EnableButtons();
                }
            }
        }

        private void SetDefaulyColor()
        {
            enteredChar = "";
            foreach (var buttonn in buttons)
            {
                buttonn.BackgroundColor = Color.Transparent;
            }
        }

        private void DisableButtons()
        {
            Loading.IsVisible = true;
            b0.IsEnabled = false;
            b1.IsEnabled = false;
            b2.IsEnabled = false;
            b3.IsEnabled = false;
            b4.IsEnabled = false;
            b5.IsEnabled = false;
            b6.IsEnabled = false;
            b7.IsEnabled = false;
            b8.IsEnabled = false;
            b9.IsEnabled = false;
            Arase.IsEnabled = false;
        }
        private void EnableButtons()
        {
            Loading.IsVisible = false;
            b0.IsEnabled = true;
            b1.IsEnabled = true;
            b2.IsEnabled = true;
            b3.IsEnabled = true;
            b4.IsEnabled = true;
            b5.IsEnabled = true;
            b6.IsEnabled = true;
            b7.IsEnabled = true;
            b8.IsEnabled = true;
            b9.IsEnabled = true;
            Arase.IsEnabled = true;
        }


        private void Arase_Clicked(object sender, EventArgs e)
        {
            if (enteredChar.Length > 0 && enteredChar.Length <= 4)
            {
                enteredChar = enteredChar.Remove(enteredChar.Length - 1);
                buttons[enteredChar.Length].BackgroundColor = Color.Transparent;
                Console.WriteLine(enteredChar + " " + enteredChar.Length + "         " + (enteredChar.Length - 1));
            }
        }

        private async void ToMainPage(object sender, EventArgs e) => await Navigation.PushAsync(new MainPage());

    }
}
