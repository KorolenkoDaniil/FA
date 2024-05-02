using FinanceApp.classes;
using FinanceApp.classes.Wallets;
using FinanceApplication.icons;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCardPage : ContentPage
    {
        Context context;

        decimal sum = 0;
        public NewCardPage(Context context)
        {
            InitializeComponent();
            this.context = context;

            NavigationPage.SetHasNavigationBar(this, false);

            sumImage.Source = ImageSource.FromResource(Icons.Iconspath[11]);
            walletImage.Source = ImageSource.FromResource(Icons.Iconspath[2]);
            cathegoryImage.Source = ImageSource.FromResource(Icons.Iconspath[3]);
            descriptionImage.Source = ImageSource.FromResource(Icons.Iconspath[5]);
            xmark1.Source = ImageSource.FromResource(Icons.Iconspath[16]);
            xmark2.Source = ImageSource.FromResource(Icons.Iconspath[16]);
            xmark3.Source = ImageSource.FromResource(Icons.Iconspath[16]);
            //dateImage.Source = ImageSource.FromResource(Icons.Iconspath[11]);
            xmark1.IsVisible = false;
            xmark2.IsVisible = false;
            xmark3.IsVisible = false;

            PickerType.ItemsSource = context.WalletTypes;
            PickerType.SelectedItem = context.WalletTypes[0];
        }

        private async void Cancel_Clicked(object sender, EventArgs e) => await Navigation.PopAsync();

        private async void Create_Clicked(object sender, EventArgs e)
        {
            if (!Validator.ValidateString(EntryName.Text, 15)) return;
            if (PickerType.SelectedItem == null)
            {
                xmark3.IsVisible = true;
                return;
            }

            if (!decimal.TryParse(EntrySum.Text, out sum)) return;
            if (sum > 10000) return;

            Random random = new Random();

            Wallet newWallet = new Wallet(
                context.User.UserId, EntryName.Text, context.WalletTypes[PickerType.SelectedIndex], sum, random.Next(0, 10), CheckboxOfInclude.IsChecked);

            Wallet isSend = await WalletRepository.SaveWallet(newWallet);

            if (isSend != null)
            {
                context.Wallets.Add(isSend);
                await Navigation.PushAsync(new CardPage(context));
            }
        }

        private void EntryName_Focused(object sender, FocusEventArgs e) => xmark1.IsVisible = false;
        private void EntryName_Unfocused(object sender, FocusEventArgs e) => xmark1.IsVisible = EntryName.Text.Length > 15;
        private void EntrySum_Focused(object sender, FocusEventArgs e) => xmark2.IsVisible = false;
        private void EntrySum_Unfocused(object sender, FocusEventArgs e) 
        {
            xmark2.IsVisible = !decimal.TryParse(EntrySum.Text, out sum);
            xmark2.IsVisible = sum > 10000;  
        }
        private void PickerType_Focused(object sender, FocusEventArgs e) => xmark3.IsVisible = false;
       
    }
}