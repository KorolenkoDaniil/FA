using FinanceApp.classes;
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
        Context context = new Context();
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Colors");


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
        }

        private async void GetColors()
        {
            try
            {
                context.SetColorsCollection(await ColorRepository.GetColors());
                SaveColorsToFile(context.Colors);
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
            context.SetColorsCollection(JsonConvert.DeserializeObject<List<Colorss>>(ColorsFroFile));

            if (context.Colors.Count == 0)
            {
                Console.WriteLine("пусто");
            }


            foreach (var item in context.Colors)
            {
                Console.WriteLine(item);
            }

        }

        private async void ToSignUpPage(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new RegistrationPage(context));
                //await ColorRepository.GetColor(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void ToSignInPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AuthorisationPage(context));
        }
    }
}
