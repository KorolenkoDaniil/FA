using FinanceApp.classes;
using FinanceApp.classes.Wallets;
using FinanceApplication.core;
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
            PlusButton.BackgroundColor = Color.FromHex(context.Color.LightMode);

        }

        public void ShowCards()
        {
            Console.WriteLine("----------- новая таблица карт и цвета");
            foreach (Wallet w in context.Wallets)
            {
                Console.WriteLine(w.Name);
            }
            List<ExtendedWallet> walletsWithColors = (from wallet in context.Wallets
                              join color in context.Colors on wallet.ColorId equals color.ColorId
                              select new ExtendedWallet
                              {
                                  WalletId = wallet.WalletId,
                                  UserId = wallet.UserId,
                                  Name = wallet.Name,
                                  Type = wallet.Type,
                                  Amount = wallet.Amount,
                                  DarkMode = color.DarkMode,
                                  LightMode = color.LightMode,
                                  DarkText = color.DarkText,
                                  LightText = color.LightText
                              }).ToList();

            foreach (var wallet in walletsWithColors)
            {
                Console.WriteLine($"{wallet.WalletId} {wallet.UserId}  {wallet.Type} {wallet.Amount} {wallet.DarkMode} {wallet.LightMode} {wallet.DarkText} {wallet.LightText}");
            }
            Console.WriteLine("----------- новая таблица карт и цвета");

            CardsCollection.ItemsSource = walletsWithColors;
        }

        private async void ToCardPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CardPage(context));
        }


        private async void ToNewCardPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewCardPage(context));
        }

        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as ExtendedWallet;

            if (selectedItem != null)
            {
                await Navigation.PushAsync(new OneCardPage(selectedItem, context));
            }

            CardsCollection.SelectedItem = null;
        }
    }
}