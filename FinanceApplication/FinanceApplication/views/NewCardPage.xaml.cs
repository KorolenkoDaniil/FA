using FinanceApp.classes;
using FinanceApp.classes.Wallets;
using FinanceApplication.core;
using FinanceApplication.icons;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCardPage : ContentPage
    {
        Context context;
        ExtendedWallet wallet;
        Random random = new Random();

        decimal sum = 0;
        public NewCardPage(Context context)
        {
            InitializeComponent();
            this.context = context;
            PickerType.ItemsSource = context.WalletTypes;
            CodeFromConstructions();
            Create.Text = "Создать";
            wallet = new ExtendedWallet();
            wallet.UserId = context.User.UserId;
            wallet.ColorId = random.Next(0, context.Colors.Count - 1);
            WalletImage1.BackgroundColor = Color.FromHex(context.Colors.FirstOrDefault(color => color.ColorId == wallet.ColorId).LightMode);
            PickerType.ItemsSource = context.WalletTypes;
            PickerType.SelectedItem = context.WalletTypes[0];
        }

        public NewCardPage(Context context, ExtendedWallet wallet)
        {
            InitializeComponent();
            PickerType.ItemsSource = context.WalletTypes;
            this.context = context;
            this.wallet = wallet;
            CodeFromConstructions();
            Create.Text = "Сохранить";
            EntryName.Text = wallet.Name;
            int index = context.WalletTypes.IndexOf(wallet.Type);
          
            WalletImage1.BackgroundColor = Color.FromHex(wallet.LightMode);
        }

        public void CodeFromConstructions()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            sumImage.Source = ImageSource.FromResource(Icons.Iconspath[11]);
            walletImage.Source = ImageSource.FromResource(Icons.Iconspath[2]);
            cathegoryImage.Source = ImageSource.FromResource(Icons.Iconspath[3]);
            descriptionImage.Source = ImageSource.FromResource(Icons.Iconspath[5]);
            xmark1.Source = ImageSource.FromResource(Icons.Iconspath[16]);
            xmark2.Source = ImageSource.FromResource(Icons.Iconspath[16]);
            xmark3.Source = ImageSource.FromResource(Icons.Iconspath[16]);
            xmark1.IsVisible = false;
            xmark2.IsVisible = false;
            xmark3.IsVisible = false;
        }


        private async void Cancel_Clicked(object sender, EventArgs e) { }
        private void EntryName_Focused(object sender, FocusEventArgs e) { }
        private void PickerType_Focused(object sender, FocusEventArgs e) { }
        private void IconButton_Clicked(object sender, EventArgs e) { }
        private async void ColorButton_Clicked(object sender, EventArgs e) { }
        private void EntryName_TextChanged(object sender, TextChangedEventArgs e) { }
        private void EntrySum_TextChanged(object sender, TextChangedEventArgs e) { }
        private void EntryName_Unfocused(object sender, FocusEventArgs e) { }
        private void EntrySum_Focused(object sender, FocusEventArgs e) { }
        private void EntrySum_Unfocused(object sender, FocusEventArgs e) { }
        private void Create_Clicked(object sender, EventArgs e) {}
    }
}