using FinanceApp.classes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOperationPage : ContentPage
    {
        Context context = new Context();
        public NewOperationPage(Context context)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.context = context;
            IncomePage.IsVisible = false;
            ConsumptionPage.IsVisible = false;
            TransferPage.IsVisible = false;

            WalletPicker.ItemsSource = context.Wallets;

        }

        private void buttonTochangePage(object sender, EventArgs e)
        {
            SelectionPage.IsVisible = false;
            TransferPage.IsVisible = true;
        }

        private void buttonToConsumePage(object sender, EventArgs e)
        {
            SelectionPage.IsVisible = false;
            ConsumptionPage.IsVisible = true;
        }

        private void buttonToIncomePage(object sender, EventArgs e)
        {
            SelectionPage.IsVisible = false;
            IncomePage.IsVisible = true;
            EntrySum.Focus();

        }

        private async void ToCardPage(object sender, EventArgs e) =>
         await Navigation.PushAsync(new CardPage(context));

        private async void ToListPage(object sender, EventArgs e) =>
            await Navigation.PushAsync(new ListPage(DateTime.Now, context));

    }
}