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
    public partial class ListPage : ContentPage
    {
        public decimal totalBalance = 0;
        List<OperationsDays> days = new List<OperationsDays>();

        public ListPage(DateTime newPeriod)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = this;
            NoOperations.IsVisible = false;

            imageCard.Source = ImageSource.FromResource(Icons.Iconspath[2]);
            imageCathegory.Source = ImageSource.FromResource(Icons.Iconspath[3]);
            imageList.Source = ImageSource.FromResource(Icons.Iconspath[8]);
            imageDiagram.Source = ImageSource.FromResource(Icons.Iconspath[6]);
            imageConverter.Source = ImageSource.FromResource(Icons.Iconspath[4]);
            Settings.Source = ImageSource.FromResource("FinanceApplication.icons.settings.png");
            date.Text = newPeriod.ToString("d");
            ShowOperations(newPeriod);
            PlusButton.BackgroundColor = Color.FromHex(Context.Color.DarkMode);
        }


        private void ShowOperations(DateTime newPeriod)
        {

            List<OperationResult> ListOperations = (from operation in Context.Operations
                                                    join cathegory in Context.Categories on operation.Cathegory equals cathegory.Name
                                                    join wallet in Context.Wallets on operation.WalletId equals wallet.WalletId
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
            totalBalance = ListOperations.Sum(operation => operation.Sum) - ListOperations.Where(operation => !operation.Profit).Sum(operation => operation.Sum);



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

            total.Text = $"$ {totalBalance}";

            if (days.Count == 0) NoOperations.IsVisible = true;
            OperationsCollection.ItemsSource = days.OrderByDescending(day => day.date);
        }
    

        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as OperationsDays;

            if (selectedItem != null)
            {
                await Navigation.PushAsync(new OperationsPerDay(selectedItem));
            }

            OperationsCollection.SelectedItem = null;
        }

        private async void ToDatePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DatePage());
        }

        private async void ToNewOperationPage(object sender, EventArgs e) => await Navigation.PushAsync(new NewOperationPage());
        private async void ToCardPage(object sender, EventArgs e) => await Navigation.PushAsync(new CardPage());
        private async void ToCategoriesPage(object sender, EventArgs e) => await Navigation.PushAsync(new CategoriesPage());
        private async void ToListPage(object sender, EventArgs e) => await Navigation.PushAsync(new ListPage(DateTime.Now));
        private async void ToDiagramPage(object sender, EventArgs e) => await Navigation.PushAsync(new DiagramPage());
        private async void ToConverterPage(object sender, EventArgs e)
        {
            Currency currencyRates = await CurrencyRepository.GetCurrency();
            await Navigation.PushAsync(new ConverterPage(currencyRates));
        }
        private async void ToSettingsPage(object sender, EventArgs e) => await Navigation.PushAsync(new SettingsPage());
    }
}