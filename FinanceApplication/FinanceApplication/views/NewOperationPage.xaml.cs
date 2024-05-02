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
        decimal sum = 0;

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

            xmarkConsume0.Source = xmarkConsume1.Source = xmarkConsume2.Source = xmarkConsume3.Source = ImageSource.FromResource(Icons.Iconspath[16]);
            xmarkConsume0.IsVisible = xmarkConsume1.IsVisible = xmarkConsume2.IsVisible = xmarkConsume3.IsVisible = false;

            xmarkIncome0.Source = xmarkIncome1.Source = xmarkIncome2.Source = xmarkIncome3.Source = ImageSource.FromResource(Icons.Iconspath[16]);
            xmarkIncome0.IsVisible = xmarkIncome1.IsVisible = xmarkIncome2.IsVisible = xmarkIncome3.IsVisible = false;

            List<string> walletsNames = new List<string>();
            foreach (Wallet wallet in context.Wallets)
                walletsNames.Add(wallet.Name);


            WalletPicker.ItemsSource = walletsNames;
            WalletPickerС.ItemsSource = walletsNames;
            WalletPicker.SelectedItem = walletsNames[0];
            WalletPickerС.SelectedItem = walletsNames[0];

            List<string> CategoriesNames = new List<string>();
            foreach (Category category in context.Categories)
                CategoriesNames.Add(category.Name);


            CathegoryPicker.ItemsSource = CategoriesNames;
            CathegoryPickerС.ItemsSource = CategoriesNames;
            CathegoryPicker.SelectedItem = CategoriesNames[0];
            CathegoryPickerС.SelectedItem = CategoriesNames[0];
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


        private void Create_Clicked(object sender, EventArgs e)
        {

            if (WalletPicker.SelectedItem == null || CathegoryPicker.SelectedItem == null)
                return;

            if (!decimal.TryParse(EntrySum.Text, out sum)) return;


            CreateOperation(true, sum);
        }

        private void Create_ClickedС(object sender, EventArgs e)
        {
            if (WalletPicker.SelectedItem == null || CathegoryPicker.SelectedItem == null)
                return;

            Console.WriteLine("-----1");
            if (!decimal.TryParse(EntrySum.Text, out sum)) return;

            CreateOperation(false, sum);
        }

        private async void CreateOperation(bool include, decimal sum)
        {
            DateTime date = Datepicker.Date;
            Console.WriteLine("-----2");
            Operation newOperation = new Operation(
                context.User.UserId, date.ToString("d"), include, sum, context.Wallets[WalletPicker.SelectedIndex].WalletId, CathegoryPicker.SelectedItem.ToString(), EntryDescription.Text);

            Operation isSend = await OperationRepository.SaveOperation(newOperation);
            if (isSend != null)
            {
                Console.WriteLine("-----3");
                context.Operations.Add(isSend);
                await Navigation.PushAsync(new ListPage(DateTime.Now, context));
            }
        }


        private void EntrySumС_Focused(object sender, FocusEventArgs e) => xmarkConsume0.IsVisible = false;
        private void EntrySumС_Unfocused(object sender, FocusEventArgs e)
        {
            xmarkConsume0.IsVisible = !decimal.TryParse(EntrySumС.Text, out sum);
            xmarkConsume0.IsVisible = sum > 10000;
        }

        private void WalletPickerС_Focused(object sender, FocusEventArgs e) => xmarkConsume1.IsVisible = false;
        private void WalletPickerС_Unfocused(object sender, FocusEventArgs e) => xmarkConsume1.IsVisible = WalletPickerС.SelectedItem == null;
        private void CathegoryPickerС_Focused(object sender, FocusEventArgs e) => xmarkConsume2.IsVisible = false;
        private void CathegoryPickerС_Unfocused(object sender, FocusEventArgs e) => xmarkConsume2.IsVisible = CathegoryPickerС.SelectedItem == null;
        private void EntryDescriptionС_Focused(object sender, FocusEventArgs e) => xmarkConsume3.IsVisible = false;
        private void EntryDescriptionС_Unfocused(object sender, FocusEventArgs e) => xmarkConsume3.IsVisible = EntryDescriptionС.Text.Length > 35;


        private void EntrySum_Focused(object sender, FocusEventArgs e) => xmarkIncome0.IsVisible = false;
        private void EntrySum_Unfocused(object sender, FocusEventArgs e)
        {
            xmarkIncome0.IsVisible = !decimal.TryParse(EntrySum.Text, out sum);
            xmarkIncome0.IsVisible = sum > 10000;
        }
        private void WalletPicker_Focused(object sender, FocusEventArgs e) => xmarkIncome1.IsVisible = false;
        private void WalletPicker_Unfocused(object sender, FocusEventArgs e) => xmarkIncome1.IsVisible = WalletPicker.SelectedItem == null;
        private void CathegoryPicker_Focused(object sender, FocusEventArgs e) => xmarkIncome2.IsVisible = false;
        private void CathegoryPicker_Unfocused(object sender, FocusEventArgs e) => xmarkIncome2.IsVisible = CathegoryPicker.SelectedItem == null;
        private void EntryDescription_Focused(object sender, FocusEventArgs e) => xmarkIncome3.IsVisible = false;
        private void EntryDescription_Unfocused(object sender, FocusEventArgs e)
        {
            try {
                if (string.IsNullOrEmpty(EntryDescription.Text) || EntryDescription.Text.Length > 35)
                    xmarkIncome3.IsVisible = true;
            }
            catch {
}
        }
    }
}