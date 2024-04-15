using FinanceApp.classes;
using FinanceApp.classes.Wallets;
using FinanceApplication.core.Operations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

            sumImage.Source = ImageSource.FromResource("FinanceApplication.icons.URow.png");
            walletImage.Source = ImageSource.FromResource("FinanceApplication.icons.card.png");
            cathegoryImage.Source = ImageSource.FromResource("FinanceApplication.icons.categories.png");
            descriptionImage.Source = ImageSource.FromResource("FinanceApplication.icons.Description.png");
            dateImage.Source = ImageSource.FromResource("FinanceApplication.icons.URow.png");


            List<string> walletsNames = new List<string>();
            foreach (Wallet wallet in context.Wallets)
                walletsNames.Add(wallet.Name);


            WalletPicker.ItemsSource = walletsNames;

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

        private async void Cancel_Clicked(object sender, EventArgs e) => await Navigation.PopAsync();
        

        private async Task<bool> Create_Clicked(object sender, EventArgs e)
        {
            if (!Validator.ValidateSum(decimal.Parse(EntrySum.Text))) return false;
            if (!Validator.ValidateName(WalletPicker.SelectedItem.ToString(), 40)) return false;
            if (!Validator.ValidateName(CathegoryPicker.SelectedItem.ToString(), 40)) return false;

            Operation newOperation = new Operation(
                context.User.UserId, Datepicker.Date.Day, Datepicker.Date.Month.ToString("MMMM"), Datepicker.Date.Year,
                true, decimal.Parse(EntrySum.Text), WalletPicker.SelectedIndex + 1,  
                CathegoryPicker.SelectedItem.ToString(), EntryDescription.Text);

            bool isSend = await OperationRepository.SaveOperation(newOperation);
            if (isSend)
            {

                await Navigation.PopAsync();
                return true;
            }
            return false;
        }
    }
}