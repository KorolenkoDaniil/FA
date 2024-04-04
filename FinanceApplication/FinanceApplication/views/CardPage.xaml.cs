using FinanceApp.classes;
using FinanceApp.classes.Wallets;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardPage : ContentPage
    {
        Context context = new Context();
        public CardPage(Context context)
        {
            InitializeComponent();
            this.context = context;
            ShowCards();
            BindingContext = this;
        }



        public void ShowCards()
        {
            foreach (Wallet wallet in context.Wallets)
            {
                Console.WriteLine(wallet);
            }
            CardsCollection.ItemsSource = context.Wallets;
        }

        private async void ToCardPage(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CardPage(context));
        }
    }
}