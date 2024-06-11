using FinanceApp.classes;
using FinanceApplication.core;
using FinanceApplication.icons;
using Newtonsoft.Json;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetingsPage : ContentPage
    {
        string path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "AuntificationCode");
        int f = 0;
        public SetingsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            reminder.Source = ImageSource.FromResource(Icons.Iconspath[32]);
            currency.Source = ImageSource.FromResource(Icons.Iconspath[30]);
            pincode.Source = ImageSource.FromResource(Icons.Iconspath[31]);
            pass.Source = ImageSource.FromResource(Icons.Iconspath[23]);
            color.Source = ImageSource.FromResource(Icons.Iconspath[29]);
            mode.Source = ImageSource.FromResource(Icons.Iconspath[28]);
            i.Source = ImageSource.FromResource(Icons.Iconspath[27]);
            comment.Source = ImageSource.FromResource(Icons.Iconspath[26]);
            defender.Source = ImageSource.FromResource(Icons.Iconspath[25]);
            Logo.Source = ImageSource.FromResource(Icons.Iconspath[24]);
            back.BackgroundColor = Color.FromHex(Context.User.AppModeColor);
            if (Context.User.AppModeColor.Equals("#F5F5F5"))
                switchMode.IsToggled = false;
            else
                switchMode.IsToggled = true;
            PinCodeInput.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private static object fileLock = new object();

        private async void ToPageOfChoisingCurrency(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CurrencySelectionPage());
        }

        private async void ChangePasswordAndPin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage(false));
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            if (f % 2 == 0)
            {
                if (File.Exists(path2))
                {
                    pinCodeRow.Height = 230;
                    but2.IsVisible = true;
                }
                else
                {
                    pinCodeRow.Height = 180;
                    but2.IsVisible = false;
                }
                PinCodeInput.IsVisible = true;
            }
            else
            {
                pinCodeRow.Height = 50;
                PinCodeInput.IsVisible = false;
            }
            f++;
        }

        private void TapGestureRecognizer_Tapped_3()
        {
            if (f % 2 == 0)
            {
                if (File.Exists(path2))
                {
                    pinCodeRow.Height = 230;
                    but2.IsVisible = true;
                }
                else
                {
                    pinCodeRow.Height = 180;
                    but2.IsVisible = false;
                }
                PinCodeInput.IsVisible = true;
            }
            else
            {
                pinCodeRow.Height = 50;
                PinCodeInput.IsVisible = false;
            }
            f++;
        }

        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (switchMode.IsToggled)
            {
                Context.User.AppModeColor = "#5e5e6b";
                back.BackgroundColor = Color.FromHex("#5e5e6b");
            }
            else
            {
                Context.User.AppModeColor = "#F5F5F5";
                back.BackgroundColor = Color.FromHex("#F5F5F5");
            }
            await Navigation.PushAsync(new ListPage());
        }

        private async void CreateFile(object sender, EventArgs e)
        {
            if (!code1.Text.Equals(code2.Text) || code1.Text.Length != 4 || code2.Text.Length != 4)
            {
                code2.TextColor = Color.Red;
            }
            else
            {
                AutorisationJson data = new AutorisationJson();
                data.code = code1.Text;
                data.userEmail = Context.User.Email;
                data.password = Context.User.Password;

                string userData = JsonConvert.SerializeObject(data);

                lock (fileLock)
                {
                    File.WriteAllText(path2, userData);
                }

                Console.WriteLine("ФАЙЛ СОЗДАН");
                Console.WriteLine(File.ReadAllText(path2));
                TapGestureRecognizer_Tapped_3();
                code1.Text = "";
                code2.Text = "";
                await Navigation.PushAsync(new ListPage());
            }
        }

        private async void DeleteFile(object sender, EventArgs e)
        {
            if (File.Exists(path2))
            {
                File.Delete(path2);
                Console.WriteLine("ФАЙЛ УДАЛЕН");
                await Navigation.PushAsync(new ListPage());
            }
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(code1.Text)) return;
            if (code1.Text.Length > 4) return;
        }

        private void Entry_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(code2.Text)) return;
            if (code2.Text.Length > 4) return;
        }

        private void code2_Focused(object sender, FocusEventArgs e)
        {
            code2.TextColor = Color.Black;
        }

        private async void InformationAlert(object sender, EventArgs e) =>
           await DisplayAlert("", "Название: Мои финансы;\r\nВерсия: 0.1v;\r\nАвтор: Короленко Данила Алексеевич Т-191;\r\nДата релиза: 11.06.2024;\r\nКраткая информация: \"Мои финансы\" - это мобильное приложение, которое предназначено для частичной автоматизации личной бухгалетрии, с возможностью категоризировать свои финансовые операции. С помощью наглядных диаграмм пользователь имеет возможность анализировать свои дохожы и расходы.\r\nCreated with Dr.Explain - Free restricted license", "ОK");

    }
}
