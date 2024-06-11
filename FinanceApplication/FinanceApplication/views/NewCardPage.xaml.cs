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
        ExtendedWallet wallet = new ExtendedWallet();
        Random random = new Random();
        bool delete;
        decimal sum = 0;
        public NewCardPage()
        {
            InitializeComponent();
            PickerType.ItemsSource = Context.WalletTypes;
            wallet = new ExtendedWallet();
            CodeFromConstructions();
            Create.Text = "Создать";
            Cancel.Text = "Отмена";
            delete = false;
            wallet.ColorId = random.Next(0, Context.Colors.Count - 1);
            int IconId = random.Next(0, Icons.WalletsIcons.Length - 1);
            WalletImage.BackgroundColor = Color.FromHex(Context.Colors.FirstOrDefault(color => color.ColorId == wallet.ColorId).DarkMode);
            PickerType.ItemsSource = Context.WalletTypes;
            PickerType.SelectedItem = Context.WalletTypes[0];
            wallet.IconId = IconId;

            wallet.UserId = Context.User.UserId;

            walletIcon.Source = ImageSource.FromResource(Icons.WalletsIcons[IconId]);
            back.BackgroundColor = Color.FromHex(Context.User.AppModeColor);

        }
        public NewCardPage(ExtendedWallet wallet)
        {
            Console.WriteLine(wallet + "&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
            InitializeComponent();
            PickerType.ItemsSource = Context.WalletTypes;
            this.wallet = wallet;
            CodeFromConstructions();
            Create.Text = "Сохранить";
            Cancel.Text = "Удалить";
            if (!string.IsNullOrEmpty(wallet.Name))
                EntryName.Text = wallet.Name;

            walletIcon.Source = wallet.WalletIconPath;

            int index = Context.WalletTypes.IndexOf(wallet.Type);
            PickerType.SelectedIndex = index;

            WalletImage.BackgroundColor = Color.FromHex(wallet.DarkMode);

            EntrySum.Text = wallet.Amount.ToString();

            delete = true;
            Top.Text = "";
            CheckboxOfInclude.IsChecked = wallet.Include;
            back.BackgroundColor = Color.FromHex(Context.User.AppModeColor);

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
            if (!delete) await Navigation.PushAsync(new CardPage());
            else
            {
                if (Context.Wallets.Count == 1)
                {
                    AlertButton_Clicked();
                    return;
                }
                Cancel.IsEnabled = false;
                Create.IsEnabled = false;
                int index = Context.Wallets.FindIndex(wal => wal.WalletId == wallet.WalletId);
                await WalletRepository.DeleteWallet(Context.Wallets[index]);
                Context.Wallets.Remove(Context.Wallets[index]);
                await Navigation.PushAsync(new CardPage());
            }
            Cancel.IsEnabled = true;
            Create.IsEnabled = true;
        }
        private void PickerType_Focused(object sender, FocusEventArgs e) { }


        private async void IconButton_Clicked(object sender, EventArgs e)
        {
            wallet.Amount = decimal.TryParse(EntrySum.Text, out sum) ? sum : 0;
            Console.WriteLine("1111");
            wallet.Type = Context.WalletTypes[PickerType.SelectedIndex];
            Console.WriteLine("2222");
            wallet.Name = EntryName.Text;
            Console.WriteLine("3333");
            wallet.Include = CheckboxOfInclude.IsChecked;
            Console.WriteLine("444");
            wallet.DarkMode = WalletImage.BackgroundColor.ToHex();
            Console.WriteLine("555");
            await Navigation.PushAsync(new IconPickerPage(wallet));
        }



        private async void ColorButton_Clicked(object sender, EventArgs e)
        {
            wallet.Amount = decimal.TryParse(EntrySum.Text, out sum) ? sum : 0;
            wallet.Type = Context.WalletTypes[PickerType.SelectedIndex];
            wallet.Name = EntryName.Text;
            wallet.Include = CheckboxOfInclude.IsChecked;
            await Navigation.PushAsync(new ColorPickerPage(wallet));
        }

        private void EntryName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EntryName.Text.Length > 25)
                xmark1.IsVisible = true;
            else
                xmark1.IsVisible = false;
        }
        private void EntrySum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!decimal.TryParse(EntrySum.Text, out sum) || string.IsNullOrEmpty(EntrySum.Text) || sum > 10000)
                xmark3.IsVisible = true;
            else
                xmark3.IsVisible = false;
        }
        private void EntryName_Focused(object sender, FocusEventArgs e)
        {
            xmark1.IsVisible = false;
        }
        private void EntrySum_Focused(object sender, FocusEventArgs e)
        {
            xmark3.IsVisible = false;
        }
        public void Resave(Category category)
        {

            int index = Context.Categories.IndexOf(category);
            if (index != -1)
            {
                Context.Categories[index] = category;
                return;
            }
            Context.Categories.Add(category);
        }
        private async void Create_Clicked(object sender, EventArgs e)
        {

            if (ValidationBeforeSaving())
            {
                Device.StartTimer(TimeSpan.FromSeconds(2), () =>
                {
                    EntrySum.IsEnabled = false;
                    ColorButton.IsEnabled = false;
                    IconButton.IsEnabled = false;
                    PickerType.IsEnabled = false;
                    EntryName.IsEnabled = false;
                    CheckboxOfInclude.IsEnabled = false;
                    return false;
                });
                Wallet isSend = await WalletRepository.SaveWallet(new Wallet(wallet.WalletId, Context.User.UserId, EntryName.Text, Context.WalletTypes[PickerType.SelectedIndex], sum, wallet.ColorId, CheckboxOfInclude.IsChecked, wallet.IconId));
                Resave(isSend);
                await Navigation.PushAsync(new CardPage());
            }
            else IncorrectData();
        }
        private bool ValidationBeforeSaving()
        {
            if (!Validator.ValidateString(EntryName.Text, 25))
            {
                xmark1.IsVisible = true;
                return false;
            }
            if (PickerType.SelectedItem == null)
            {
                xmark3.IsVisible = true;
                return false;
            }
            if (!decimal.TryParse(EntrySum.Text, out sum) || string.IsNullOrEmpty(EntrySum.Text) || sum > 10000)
            {
                xmark3.IsVisible = true;
                return false;
            }
            return true;
        }
        public void Resave(Wallet wallet)
        {
            int index = Context.Wallets.IndexOf(wallet);

            if (index != -1)
            {
                Context.Wallets[index] = wallet;
                return;
            }
            Context.Wallets.Add(wallet);

        }

        private async void AlertButton_Clicked()
        {
            await DisplayAlert("Последний кошелек", "кошелек не может быть удален,\nтк он последний", "ОK"); await Navigation.PushAsync(new CardPage());
        }
        private async void IncorrectData() =>
           await DisplayAlert("неправильные данные", "проверьте введенные данные", "ОK");
    }
}
