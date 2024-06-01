using FinanceApp.classes;
using FinanceApplication.core;
using Newtonsoft.Json;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        string path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "AuntificationCode");
        public SettingsPage()
        {
            InitializeComponent();
            fileExist.IsChecked = File.Exists(path2);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void ChangeMode(object sender, EventArgs e) => 
            Context.User.AppModeWhite = !Context.User.AppModeWhite;



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
    }
}