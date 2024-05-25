using Android.Service.QuickAccessWallet;
using FinanceApp.classes;
using FinanceApp.classes.Wallets;
using FinanceApplication.core;
using FinanceApplication.core.Category;
using FinanceApplication.icons;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCardPage : ContentPage
    {
        Context context;
        ExtendedWallet wallet; 
        Random random = new Random();
        bool delete;
        decimal sum = 0;
        public NewCardPage(Context context)
        {
            InitializeComponent(); 
            this.context = context;
            PickerType.ItemsSource = context.WalletTypes;
            wallet = new ExtendedWallet();
            CodeFromConstructions();
            Create.Text = "Создать"; 
            Cancel.Text = "Отмена";
            delete = false; 
            wallet.ColorId = random.Next(0, context.Colors.Count - 1);
            int IconId = random.Next(0, Icons.WalletsIcons.Length - 1);
            WalletImage.BackgroundColor = Color.FromHex(context.Colors.FirstOrDefault(color => color.ColorId == wallet.ColorId).DarkMode);
            PickerType.ItemsSource = context.WalletTypes;
            PickerType.SelectedItem = context.WalletTypes[0];
            wallet.IconId = IconId;

            wallet.UserId = context.User.UserId;

            Console.WriteLine("$$$$$$$$$$$$$$");
            Console.WriteLine(wallet);
            Console.WriteLine("$$$$$$$$$$$$$$");

            walletIcon.Source = ImageSource.FromResource(Icons.WalletsIcons[IconId]);

        }
        public NewCardPage(Context context, ExtendedWallet wallet)
        {
            InitializeComponent();
            PickerType.ItemsSource = context.WalletTypes;
            this.context = context; 
            this.wallet = wallet;
            CodeFromConstructions();
            Create.Text = "Сохранить"; 
            Cancel.Text = "Удалить";
            EntryName.Text = wallet.Name; 
            int index = context.WalletTypes.IndexOf(wallet.Type);
            PickerType.SelectedIndex = index; 
            WalletImage.BackgroundColor = Color.FromHex(wallet.DarkMode);
            delete = true;
        }
        public void CodeFromConstructions()
        {
            NavigationPage.SetHasNavigationBar(this, false); 
            sumImage.Source = ImageSource.FromResource(Icons.Iconspath[11]);
            walletImage.Source = ImageSource.FromResource(Icons.Iconspath[2]); 
            colorImage.Source = ImageSource.FromResource(Icons.Iconspath[17]);
            descriptionImage.Source = ImageSource.FromResource(Icons.Iconspath[5]);
            IconImage.Source = ImageSource.FromResource(Icons.Iconspath[18]);
            xmark1.Source = ImageSource.FromResource(Icons.Iconspath[16]);
            xmark2.Source = ImageSource.FromResource(Icons.Iconspath[16]); 
            xmark3.Source = ImageSource.FromResource(Icons.Iconspath[16]);
            xmark1.IsVisible = false; 
            xmark2.IsVisible = false;
            xmark3.IsVisible = false;
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            if (!delete) await Navigation.PushAsync(new CardPage(context));
            else
            {
                if (context.Wallets.Count == 1)
                {
                    AlertButton_Clicked();
                    return;
                }
                Cancel.IsEnabled = false;
                Create.IsEnabled = false; int index = context.Wallets.FindIndex(wal => wal.WalletId == wallet.WalletId);
                await WalletRepository.DeleteWallet(context.Wallets[index]); context.Wallets.Remove(context.Wallets[index]);
                await Navigation.PushAsync(new CardPage(context));
            }
            Cancel.IsEnabled = true; Create.IsEnabled = true;
        }
        private void EntryName_Focused(object sender, FocusEventArgs e) { }
        private void PickerType_Focused(object sender, FocusEventArgs e) { }
        private async void IconButton_Clicked(object sender, EventArgs e) =>
            await Navigation.PushAsync(new IconPickerPage(context, wallet));

        private async void ColorButton_Clicked(object sender, EventArgs e) =>
            await Navigation.PushAsync(new ColorPickerPage(context, wallet));

        private void EntryName_TextChanged(object sender, TextChangedEventArgs e) { }
        private void EntrySum_TextChanged(object sender, TextChangedEventArgs e) { }
        private void EntryName_Unfocused(object sender, FocusEventArgs e) { }
        private void EntrySum_Focused(object sender, FocusEventArgs e) { }
        private void EntrySum_Unfocused(object sender, FocusEventArgs e) { }
        public void Resave(Category category)
        {
            int index = context.Categories.IndexOf(category);
            if (index != -1)
            {
                context.Categories[index] = category; return;
            }
            context.Categories.Add(category);
        }
        private async void Create_Clicked(object sender, EventArgs e)
        {

            ValidationBeforeSaving();
            Device.StartTimer(TimeSpan.FromSeconds(2), () => {
                EntrySum.IsEnabled = false; 
                ColorButton.IsEnabled = false;
                IconButton.IsEnabled = false; 
                PickerType.IsEnabled = false;
                EntryName.IsEnabled = false; 
                CheckboxOfInclude.IsEnabled = false;
                return false;
            });
            Wallet isSend = await WalletRepository.SaveWallet(new Wallet(wallet.WalletId, context.User.UserId, EntryName.Text, context.WalletTypes[PickerType.SelectedIndex], sum, wallet.ColorId, CheckboxOfInclude.IsChecked, wallet.IconId));
            Console.WriteLine("%%%%%%%%%%%%%%%%%111");
            Console.WriteLine(isSend);
            Console.WriteLine("%%%%%%%%%%%%%%%%%111");
            Resave(isSend); 
            await Navigation.PushAsync(new CardPage(context));
        }
        private void ValidationBeforeSaving()
        {
            if (!Validator.ValidateString(EntryName.Text, 15)) return; if (PickerType.SelectedItem == null)
            {
                xmark3.IsVisible = true;
                return;
            }
            if (!decimal.TryParse(EntrySum.Text, out sum)) return;
            if (sum > 10000) return;
        }
        public void Resave(Wallet wallet)
        {
            int index = context.Wallets.IndexOf(wallet);
            Console.WriteLine("%%%%%%%%%%%%%%%%%");
            Console.WriteLine(wallet);
            Console.WriteLine("%%%%%%%%%%%%%%%%%");

            if (index != -1)
            {
                context.Wallets[index] = wallet; return;
            }
            context.Wallets.Add(wallet);
        }

        private async void AlertButton_Clicked()
        {
            await DisplayAlert("Последний кошелек", "кошелек не может быть удален,\nтк он последний", "ОK"); await Navigation.PushAsync(new CardPage(context));
        }
    }
}