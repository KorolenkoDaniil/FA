﻿using FinanceApp.classes;
using FinanceApp.classes.Wallets;
using System;
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
            ShowCards();
            BindingContext = this;
        }

        public void ShowCards()
        {
            Console.WriteLine("----------- новая таблица карт и цвета");
            foreach (Wallet w in Context.Wallets)
            {
                Console.WriteLine(w.Name);
            }
            var walletsWithColors = from wallet in Context.Wallets
                              join color in Context.Colors on wallet.ColorId equals color.ColorId
                           
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
            await Navigation.PushAsync(new CardPage());
        }
    }
}