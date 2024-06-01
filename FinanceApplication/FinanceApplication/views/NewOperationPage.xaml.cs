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
        bool income = true;
        decimal sum = 0;

        public NewOperationPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            IncomePage.IsVisible = false;
            ConsumptionPage.IsVisible = false;
            TransferPage.IsVisible = false;

            sumImage.Source = ImageSource.FromResource(Icons.Iconspath[14]);
            walletImage.Source = ImageSource.FromResource(Icons.Iconspath[2]);
            cathegoryImage.Source = ImageSource.FromResource(Icons.Iconspath[3]);
            descriptionImage.Source = ImageSource.FromResource(Icons.Iconspath[5]);
            dateImage.Source = ImageSource.FromResource(Icons.Iconspath[1]);

            sumImageС.Source = ImageSource.FromResource(Icons.Iconspath[7]);
            walletImageС.Source = ImageSource.FromResource(Icons.Iconspath[2]);
            cathegoryImageС.Source = ImageSource.FromResource(Icons.Iconspath[3]);
            descriptionImageС.Source = ImageSource.FromResource(Icons.Iconspath[5]);
            dateImageС.Source = ImageSource.FromResource(Icons.Iconspath[1]);

            xmarkConsume0.Source = xmarkConsume1.Source = xmarkConsume2.Source = xmarkConsume3.Source = ImageSource.FromResource(Icons.Iconspath[16]);
            xmarkConsume0.IsVisible = xmarkConsume1.IsVisible = xmarkConsume2.IsVisible = xmarkConsume3.IsVisible = false;

            xmarkIncome0.Source = xmarkIncome1.Source = xmarkIncome2.Source = xmarkIncome3.Source = ImageSource.FromResource(Icons.Iconspath[16]);
            xmarkIncome0.IsVisible = xmarkIncome1.IsVisible = xmarkIncome2.IsVisible = xmarkIncome3.IsVisible = false;

            List<string> walletsNames = new List<string>();
            foreach (Wallet wallet in Context.Wallets)
                walletsNames.Add(wallet.Name);


            WalletPicker.ItemsSource = walletsNames;
            WalletPickerС.ItemsSource = walletsNames;
            WalletPicker.SelectedItem = walletsNames[0];
            WalletPickerС.SelectedItem = walletsNames[0];

            List<string> CategoriesNames = new List<string>();
            foreach (Category category in Context.Categories)
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
         await Navigation.PushAsync(new CardPage());

        private async void ToListPage(object sender, EventArgs e) =>
            await Navigation.PushAsync(new ListPage());

        private async void Cancel_Clicked(object sender, EventArgs e) =>
            await Navigation.PushAsync(new ListPage());

        private bool Validation()
        {
            if (WalletPicker.SelectedItem == null || CathegoryPicker.SelectedItem == null)  return false;
            if (!decimal.TryParse(EntrySum.Text, out sum) || sum < 0 || sum > 10000 )  return false;
            if (!string.IsNullOrEmpty(EntryDescription.Text))
            {
                if (EntryDescription.Text.Length > 30) return false;
            }
            
            return true;
        }

        private bool ValidationC()
        {
            if (WalletPickerС.SelectedItem == null || CathegoryPickerС.SelectedItem == null)
                return false;
            if (!decimal.TryParse(EntrySumС.Text, out sum) || sum < 0 || sum > 10000) return false;
            if (EntryDescriptionС.Text.Length > 30) return false;

            return true;
        }

        private void Create_Clicked(object sender, EventArgs e)
        {
            if (Validation())
            {
                DateTime date = Datepicker.Date;
                CreateOperation(true, sum, Context.Wallets[WalletPicker.SelectedIndex].WalletId, CathegoryPicker.SelectedItem.ToString(), EntryDescription.Text, date.ToString("d"));
            }
            else
            {
                IncorrectData();
            }

        }

        private void Create_ClickedС(object sender, EventArgs e)
        {
            if (ValidationC())
            {
                DateTime date = DatepickerС.Date;
                CreateOperation(false, sum, Context.Wallets[WalletPickerС.SelectedIndex].WalletId, CathegoryPickerС.SelectedItem.ToString(), EntryDescriptionС.Text, date.ToString("d"));
            }
            else
            {
                IncorrectData();
            }

           
        }

        private async void CreateOperation(bool include, decimal sum, int walletpickerIndex, string selectedCategory, string description, string stringdate)
        {
            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                Cancel.IsEnabled = false;
                Create.IsEnabled = false;
                CreateС.IsEnabled = false;
                CancelС.IsEnabled = false;
                return false;
            });

            Operation newOperation = new Operation(
                Context.User.UserId, stringdate, include, sum, walletpickerIndex, selectedCategory, description);

            Operation isSend = await OperationRepository.SaveOperation(newOperation);
            if (isSend != null)
            {
                Context.Operations.Add(isSend);
                await Navigation.PushAsync(new ListPage());
            }
        }

        private void EntrySumС_Focused(object sender, FocusEventArgs e) =>
            xmarkConsume0.IsVisible = false;

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
        private void EntryDescriptionС_Unfocused(object sender, FocusEventArgs e) {
            if (string.IsNullOrEmpty(EntryDescriptionС.Text))
                return;
                xmarkConsume3.IsVisible = EntryDescriptionС.Text.Length > 20;
        }


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
                if (string.IsNullOrEmpty(EntryDescription.Text) || EntryDescription.Text.Length > 25)
                    xmarkIncome3.IsVisible = true;
            }
            catch {
            }
        }

        private async void IncorrectData() =>
         await DisplayAlert("Неправвильные данные", "проверьте введенные данные", "ОK");
    }
}