using FinanceApp.classes;
using FinanceApplication.core;
using FinanceApplication.core.Colors;
using FinanceApplication.views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace FinanceApplication
{
    public partial class MainPage : ContentPage
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Colors");
        string path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "AuntificationCode");

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            if (File.Exists(path))
            {
                GetColorsFromFile();
                Console.WriteLine("цвета получили из файла");
            }
            else
            {
                GetColors();
                Console.WriteLine("цвета получили с сервера");
            }
            

            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$  1");
            //File.Delete(path2);
            Console.WriteLine(File.Exists(path2));
            if (File.Exists(path2))
            {
                ToPasswordPage();
            }
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$  2");

        }

        public async void  ToPasswordPage()
        {
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$  3");
            await Navigation.PushAsync(new PasswordPage(path2));
        }


        private async void GetColors()
        {
            try
            {
                Context.SetColorsCollection(await ColorRepository.GetColors());
                SaveColorsToFile(Context.Colors);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SaveColorsToFile(List<Colorss> colors)
        {
            string json = JsonConvert.SerializeObject(colors);
            File.WriteAllText(path, json);
        }


        private void GetColorsFromFile()
        {
          
            string ColorsFroFile = File.ReadAllText(path);
            Context.SetColorsCollection(JsonConvert.DeserializeObject<List<Colorss>>(ColorsFroFile));

            if (Context.Colors.Count == 0)
            {
                Console.WriteLine("пусто");
            }


            foreach (var item in Context.Colors)
            {
                Console.WriteLine(item);
            }

        }

        private async void ToSignUpPage(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new RegistrationPage());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void ToSignInPage(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            await Navigation.PushAsync(new AuthorisationPage());
        }
    }
}
