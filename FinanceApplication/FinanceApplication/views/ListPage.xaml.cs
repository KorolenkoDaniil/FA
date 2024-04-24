﻿using FinanceApp.classes;
using FinanceApplication.core;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        Context context = new Context();
        public decimal totalBalance = 0;
        List<OperationsDays> days = new List<OperationsDays>();


        public ListPage(DateTime newPeriod, Context context)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.context = context;
            BindingContext = this;
            NoOperations.IsVisible = false;
            imageCard.Source = ImageSource.FromResource("FinanceApplication.icons.card.png");
            imageCathegory.Source = ImageSource.FromResource("FinanceApplication.icons.categories.png");
            imageList.Source = ImageSource.FromResource("FinanceApplication.icons.list.png");
            imageDiagram.Source = ImageSource.FromResource("FinanceApplication.icons.diagram.png");
            imageConverter.Source = ImageSource.FromResource("FinanceApplication.icons.converter.png");
            date.Text = newPeriod.ToString("d");
            ShowOperations(newPeriod);
            total.Text = $"$ {totalBalance}";
            Console.WriteLine(context.Color.LightMode);
            PlusButton.BackgroundColor = Color.FromHex(context.Color.LightMode);
        }


        private void ShowOperations(DateTime newPeriod)
        {

            List<OperationResult> ListOperations = (from operation in context.Operations
                                                    join cathegory in context.Categories on operation.Cathegory equals cathegory.Name
                                                    join wallet in context.Wallets on operation.WalletId equals wallet.WalletId
                                                    select new OperationResult
                                                    {
                                                        Id = operation.Id,
                                                        UserId = cathegory.UserId,
                                                        Profit = operation.Profit,
                                                        Date = operation.Date,
                                                        Sum = operation.Sum,
                                                        WalletId = operation.WalletId,
                                                        Cathegory = cathegory.Name,
                                                        Description = operation.Description,
                                                        WalletName = wallet.Name,
                                                        WalletType = wallet.Type,
                                                    }).ToList();
            totalBalance = ListOperations.Where(operation => operation.Profit).Sum(operation => operation.Sum);
            Console.WriteLine(totalBalance);
            totalBalance -= ListOperations.Where(operation => !operation.Profit).Sum(operation => operation.Sum);
            Console.WriteLine(totalBalance);



            List<string> uniqueDates = ListOperations
                .Where(o => DateTime.Parse(o.Date).Month == DateTime.Now.Month)
                .Select(o => o.Date)
                .Distinct()
                .ToList();

            days = new List<OperationsDays>();


            foreach (string date in uniqueDates)
            {
                OperationsDays day = new OperationsDays(
                    DateTime.Parse(date),
                    ListOperations.Where(operation => operation.Date == date).ToList()
                );
                days.Add(day);
            }

            OperationsCollection.ItemsSource = days;
        }

             

        private async void ToCardPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CardPage(context));
        }

        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as OperationsDays;

            if (selectedItem != null)
            {
                await Navigation.PushAsync(new OperationsPerDay(selectedItem, context));
            }

            OperationsCollection.SelectedItem = null;
        }

        private async void ToDatePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DatePage(context));
        }

        private async void ToNewOperationPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewOperationPage(context));
        }
    }
}