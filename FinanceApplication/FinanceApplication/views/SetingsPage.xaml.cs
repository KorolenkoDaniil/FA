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
        public SetingsPage()
        {
            InitializeComponent();
            //fileExist.IsChecked = File.Exists(path2);
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
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

    
        private static object fileLock = new object();

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^1"); 
            if (sender is CheckBox checkbox)
            {
                Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^2" + checkbox.IsChecked);

                if (checkbox.IsChecked)
                {
                    AutorisationJson data = new AutorisationJson();
                    data.code = "1234";
                    data.userEmail = Context.User.Email;
                    data.password = Context.User.Password;

                    string userData = JsonConvert.SerializeObject(data);

                    lock (fileLock)
                    {
                        File.WriteAllText(path2, userData);
                    }

                    Console.WriteLine("ФАЙЛ СОЗДАН");
                    Console.WriteLine(File.ReadAllText(path2));
                }
                else
                {
                    lock (fileLock)
                    {
                        if (File.Exists(path2))
                        {
                            File.Delete(path2);
                            Console.WriteLine("ФАЙЛ УДАЛЕН");
                        }
                    }
                }
            }
        }

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

        }

        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (switchMode.IsToggled)
            {
                Context.User.AppModeColor = "#5e5e6b";
                back.BackgroundColor = Color.FromHex("#5e5e6b");
                await Navigation.PushAsync(new ListPage());
            }
            else
            {
                Context.User.AppModeColor = "#F5F5F5";
                back.BackgroundColor = Color.FromHex("#F5F5F5");
                await Navigation.PushAsync(new ListPage());

            }

        }
    }
}