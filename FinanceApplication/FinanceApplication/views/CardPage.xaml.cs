using FinanceApp.classes;
using FinanceApp.classes.Wallets;
using FinanceApplication.core;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardPage : ContentPage
    {
        Context context = new Context();

        public CardPage(Context context)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.context = context;
            imageCard.Source = ImageSource.FromResource("FinanceApplication.icons.card.png");
            imageCathegory.Source = ImageSource.FromResource("FinanceApplication.icons.categories.png");
            imageList.Source = ImageSource.FromResource("FinanceApplication.icons.list.png");
            imageDiagram.Source = ImageSource.FromResource("FinanceApplication.icons.diagram.png");
            imageConverter.Source = ImageSource.FromResource("FinanceApplication.icons.converter.png");
            ShowCards();
            BindingContext = this;
        }

        public void ShowCards()
        {
            Console.WriteLine("----------- новая таблица карт и цвета");
            foreach (Wallet w in context.Wallets)
            {
                Console.WriteLine(w.Name);
            }
            var walletsWithColors = from wallet in context.Wallets
                              join color in context.Colors on wallet.ColorId equals color.ColorId
                              select new
                              {
                                  WalletId = wallet.WalletId,
                                  UserId = wallet.UserId,
                                  Name = wallet.Name,
                                  Type = wallet.Type,
                                  Amount = wallet.Amount,
                                  Include = wallet.Include,
                                  DarkMode = color.DarkMode,
                                  LightMode = color.LightMode,
                                  DarkText = color.DarkText,
                                  LightText = color.LightText
                              };

            foreach (var wallet in walletsWithColors)
            {
                Console.WriteLine($"{wallet.WalletId} {wallet.UserId}  {wallet.Type}" +
                    $" {wallet.Amount} {wallet.Include} {wallet.DarkMode} {wallet.LightMode} {wallet.DarkText} {wallet.LightText}");
            }
            Console.WriteLine("----------- новая таблица карт и цвета");
            CardsCollection.ItemsSource = walletsWithColors;
        }

        private async void ToCardPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CardPage(context));
        }

        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as Wallet;

            if (selectedItem != null)
            {
                await Navigation.PushAsync(new PageOf1Card(selectedItem, context));
            }

            CardsCollection.SelectedItem = null;
        }
    }
}