using FinanceApp.classes;
using FinanceApplication.core;
using FinanceApplication.core.Colors;
using FinanceApplication.icons;
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

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Logo.Source = ImageSource.FromResource(Icons.Iconspath[24]);
            if (File.Exists(Context.colorsPath))
            {
                GetColorsFromFile();
                Console.WriteLine("цвета получили из файла");
            }
            else
            {
                GetColors();
                Console.WriteLine("цвета получили с сервера");
            }



            //File.Delete(path2);
            Console.WriteLine(File.Exists(Context.codePath));
            if (File.Exists(Context.codePath))
            {
                ToPasswordPage();
            }

        }

        public async void ToPasswordPage()
        {
            await Navigation.PushAsync(new PasswordPage());
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
            File.WriteAllText(Context.colorsPath, json);
        }


        private void GetColorsFromFile()
        {

            string ColorsFroFile = File.ReadAllText(Context.colorsPath);
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
