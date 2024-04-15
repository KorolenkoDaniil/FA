using FinanceApp.classes;
using FinanceApplication.core.Colors;
using FinanceApplication.views;
using System;
using Xamarin.Forms;

namespace FinanceApplication
{
    public partial class MainPage : ContentPage
    {
        Context context = new Context();
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            GetColors();

        }

        private async void GetColors() => context.SetColorsCollection(await ColorRepository.GetColors());
        

        private async void ToSignUpPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage(context));
            await ColorRepository.GetColor(1);
        }

        private async void ToSignInPage(object sender, EventArgs e)
        {
            await ColorRepository.GetColor(1);
            await Navigation.PushAsync(new AuthorisationPage(context));
        }
    }
}
