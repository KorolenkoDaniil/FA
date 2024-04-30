using FinanceApp.classes;
using FinanceApp.classes.Wallets;
using FinanceApplication.core;
using FinanceApplication.core.Operations;
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
		public NewCardPage (Context context)
		{
			InitializeComponent ();
			this.context = context;

            NavigationPage.SetHasNavigationBar(this, false);

            sumImage.Source = ImageSource.FromResource(Icons.Iconspath[11]);
            walletImage.Source = ImageSource.FromResource(Icons.Iconspath[2]);
            cathegoryImage.Source = ImageSource.FromResource(Icons.Iconspath[3]);
            descriptionImage.Source = ImageSource.FromResource(Icons.Iconspath[5]);
            //dateImage.Source = ImageSource.FromResource(Icons.Iconspath[11]);


            PickerType.ItemsSource = context.WalletTypes;
        }

        private async void Cancel_Clicked(object sender, EventArgs e) => await Navigation.PopAsync();

        private async void Create_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EntryName.Text)) return;
            if (PickerType.SelectedItem == null) return;

            decimal sum = 0;

            if (!decimal.TryParse(EntrySum.Text, out sum)) return; 



            Random random = new Random();

            Wallet newWallet = new Wallet(
                context.User.UserId, EntryName.Text, context.WalletTypes[PickerType.SelectedIndex], decimal.Parse(EntrySum.Text), random.Next(0, 10), CheckboxOfInclude.IsChecked);

            Wallet isSend = await WalletRepository.SaveWallet(newWallet);
           
            if (isSend != null)
            {
                context.Wallets.Add(isSend);
                await Navigation.PushAsync(new CardPage(context));
            }
        }

    }
}