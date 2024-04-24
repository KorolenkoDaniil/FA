using FinanceApp.classes;
using FinanceApp.classes.Wallets;
using FinanceApplication.core;
using FinanceApplication.core.Operations;
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

            sumImage.Source = ImageSource.FromResource("FinanceApplication.icons.URow.png");
            walletImage.Source = ImageSource.FromResource("FinanceApplication.icons.card.png");
            cathegoryImage.Source = ImageSource.FromResource("FinanceApplication.icons.categories.png");
            descriptionImage.Source = ImageSource.FromResource("FinanceApplication.icons.Description.png");
            //dateImage.Source = ImageSource.FromResource("FinanceApplication.icons.URow.png");


            PickerType.ItemsSource = context.WalletTypes;
        }


        private async void Cancel_Clicked(object sender, EventArgs e) => await Navigation.PopAsync();


        private async void Create_Clicked(object sender, EventArgs e)
        {
            //if (!Validator.ValidateSum(decimal.Parse(EntrySum.Text))) return;
            //if (!Validator.ValidateName(WalletPicker.SelectedItem.ToString(), 40)) return;
            //if (!Validator.ValidateName(CathegoryPicker.SelectedItem.ToString(), 40)) return;

            //DateTime date = Datepicker.Date;

            //int userid, string name, string type, decimal amount, int colorID, bool include

            Random random = new Random();

            Wallet newWallet = new Wallet(
                context.User.UserId, EntryName.Text, context.WalletTypes[PickerType.SelectedIndex], decimal.Parse(EntrySum.Text), random.Next(0, 10), CheckboxOfInclude.IsChecked);

            Wallet isSend = await WalletRepository.SaveWallet(newWallet);
            Console.WriteLine("-------------------------------новый кошелек");
            Console.WriteLine(isSend);
            Console.WriteLine("-------------------------------новый кошелек");

            if (isSend != null)
            {
                context.Wallets.Add(isSend);
                await Navigation.PushAsync(new CardPage(context));
            }
        }

    }
}