using FinanceApp.classes;
using FinanceApp.classes.Wallets;
using FinanceApplication.core.Category;
using FinanceApplication.core.Operations;
using FinanceApplication.icons;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOperationPage : ContentPage
    {
        Context context = new Context();
        bool income = true;

        public NewOperationPage(Context context)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.context = context;
            IncomePage.IsVisible = false;
            ConsumptionPage.IsVisible = false;
            TransferPage.IsVisible = false;

            sumImage.Source = ImageSource.FromResource(Icons.Iconspath[11]);
            walletImage.Source = ImageSource.FromResource(Icons.Iconspath[2]);
            cathegoryImage.Source = ImageSource.FromResource(Icons.Iconspath[3]);
            descriptionImage.Source = ImageSource.FromResource(Icons.Iconspath[5]);
            dateImage.Source = ImageSource.FromResource(Icons.Iconspath[11]);

            sumImageС.Source = ImageSource.FromResource(Icons.Iconspath[11]);
            walletImageС.Source = ImageSource.FromResource(Icons.Iconspath[2]);
            cathegoryImageС.Source = ImageSource.FromResource(Icons.Iconspath[3]);
            descriptionImageС.Source = ImageSource.FromResource(Icons.Iconspath[5]);
            dateImageС.Source = ImageSource.FromResource(Icons.Iconspath[11]);




            List<string> walletsNames = new List<string>();
            foreach (Wallet wallet in context.Wallets)
                walletsNames.Add(wallet.Name);


            WalletPicker.ItemsSource = walletsNames;

            List<string> CategoriesNames = new List<string>();
            foreach (Category category in context.Categories)
                CategoriesNames.Add(category.Name);


            CathegoryPicker.ItemsSource = CategoriesNames;

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
            income = true;
        }

        private void buttonToIncomePage(object sender, EventArgs e)
        {
            SelectionPage.IsVisible = false;
            IncomePage.IsVisible = true;
            EntrySum.Focus();
            income = false;
        }

        private async void ToCardPage(object sender, EventArgs e) =>
         await Navigation.PushAsync(new CardPage(context));

        private async void ToListPage(object sender, EventArgs e) =>
            await Navigation.PushAsync(new ListPage(DateTime.Now, context));

        private async void Cancel_Clicked(object sender, EventArgs e) => await Navigation.PopAsync();
        

        private async void Create_Clicked(object sender, EventArgs e)
        {

            if (WalletPicker.SelectedItem == null || CathegoryPicker.SelectedItem == null)
                return;

            decimal sum = 0;

            if (!decimal.TryParse(EntrySum.Text, out sum)) return;


            CreateOperation(true, sum);
        }

        private async void Create_ClickedС(object sender, EventArgs e)
        {

            if (WalletPicker.SelectedItem == null || CathegoryPicker.SelectedItem == null)
                return;

            decimal sum = 0;

            if (!decimal.TryParse(EntrySum.Text, out sum)) return;

            CreateOperation(false, sum);
        }

        private async void CreateOperation(bool include, decimal sum)
        {
            DateTime date = Datepicker.Date;

            Operation newOperation = new Operation(
                context.User.UserId, date.ToString("d"), include, sum, context.Wallets[WalletPicker.SelectedIndex].WalletId, CathegoryPicker.SelectedItem.ToString(), EntryDescription.Text);

            Operation isSend = await OperationRepository.SaveOperation(newOperation);
            if (isSend != null)
            {
                context.Operations.Add(isSend);
                await Navigation.PushAsync(new ListPage(DateTime.Now, context));
            }
        }
    }
}