using FinanceApp.classes;
using FinanceApplication.core;
using FinanceApplication.core.Currency;
using FinanceApplication.icons;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardPage : ContentPage
    {
        public CardPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            for (int i = 0; i < Context.Wallets.Count; i++)
            {
                Console.WriteLine(Context.Wallets[i]);
            }
            back.BackgroundColor = Color.FromHex(Context.User.AppModeColor);
            imageCard.Source = ImageSource.FromResource(Icons.Iconspath[2]);
            imageCathegory.Source = ImageSource.FromResource(Icons.Iconspath[3]);
            imageList.Source = ImageSource.FromResource(Icons.Iconspath[8]);
            imageDiagram.Source = ImageSource.FromResource(Icons.Iconspath[6]);
            imageConverter.Source = ImageSource.FromResource(Icons.Iconspath[4]);
            ShowCards();
            BindingContext = this;
            PlusButton.BackgroundColor = Color.FromHex(Context.Color.DarkMode);
        }

        public void ShowCards()
        {

            List<ExtendedWallet> walletsWithColors = (from wallet in Context.Wallets
                                                      join color in Context.Colors on wallet.ColorId equals color.ColorId
                                                      select new ExtendedWallet
                                                      {
                                                          WalletId = wallet.WalletId,
                                                          Include = wallet.Include,
                                                          UserId = wallet.UserId,
                                                          Name = wallet.Name,
                                                          Type = wallet.Type,
                                                          DarkMode = color.DarkMode,
                                                          IconId = wallet.IconId,
                                                          ColorId = wallet.ColorId,
                                                          WalletIconPath = ImageSource.FromResource(Icons.WalletsIcons[wallet.IconId])
                                                      }).ToList();

            CardsSum.Text = "$" + walletsWithColors.Where(wallet => wallet.Include).Sum(wa => wa.Amount);
            CardsCollection.ItemsSource = walletsWithColors;
        }


        private async void ToNewCardPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewCardPage());
        }

        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as ExtendedWallet;

            if (selectedItem != null)
            {
                await Navigation.PushAsync(new NewCardPage(selectedItem));
            }

            CardsCollection.SelectedItem = null;
        }


        private async void ToCardPage(object sender, EventArgs e) => await Navigation.PushAsync(new CardPage());
        private async void ToCategoriesPage(object sender, EventArgs e) => await Navigation.PushAsync(new CategoriesPage());
        private async void ToListPage(object sender, EventArgs e) => await Navigation.PushAsync(new ListPage());
        private async void ToDiagramPage(object sender, EventArgs e) => await Navigation.PushAsync(new DiagramPage());
        private async void ToConverterPage(object sender, EventArgs e)
        {
            Currency currencyRates = await CurrencyRepository.GetCurrency();
            await Navigation.PushAsync(new ConverterPage(currencyRates));
        }
    }
}
