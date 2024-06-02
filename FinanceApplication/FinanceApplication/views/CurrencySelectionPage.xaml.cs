using FinanceApp.classes;
using FinanceApp.classes.Users;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrencySelectionPage : ContentPage
    {
        public CurrencySelectionPage()
        {
            InitializeComponent();
            back.BackgroundColor = Color.FromHex(Context.User.AppModeColor);
        }

        private async void Change(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Context.User.SelectedCurrency = button.Text;
                await UserRepository.SaveUser(Context.User);
                await Navigation.PushAsync(new ListPage());
            }
        }
    
    }
}