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
        List<OperationsDays> days = new List<OperationsDays>();

        public ListPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = this;
            NoOperations.IsVisible = false;
            back.BackgroundColor = Color.FromHex(Context.User.AppModeColor);
            imageCard.Source = ImageSource.FromResource(Icons.Iconspath[2]);
            imageCathegory.Source = ImageSource.FromResource(Icons.Iconspath[3]);
            imageList.Source = ImageSource.FromResource(Icons.Iconspath[8]);
            imageDiagram.Source = ImageSource.FromResource(Icons.Iconspath[6]);
            imageConverter.Source = ImageSource.FromResource(Icons.Iconspath[4]);
            Settings.Source = ImageSource.FromResource("FinanceApplication.icons.settings.png");
            ShowOperations(DateTime.Today, DateTime.Today);
            PlusButton.BackgroundColor = Color.FromHex(Context.Color.DarkMode);
            dayButton.BorderColor = Color.FromHex(Context.Color.DarkMode);
        }




        private void ShowOperations(DateTime start, DateTime end)
        {
            Console.WriteLine($"-----------------start {start} end {end}");

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
                                                    }).Where(oper => DateTime.Parse(oper.Date) >= start && DateTime.Parse(oper.Date) <= end).ToList();

            foreach (var item in ListOperations)
            {
                Console.WriteLine(item);
            }

            decimal increase = ListOperations.Where(oper => oper.Profit).Sum(operation => operation.Sum),
                    consume = ListOperations.Where(oper => !oper.Profit).Sum(operation => operation.Sum);

            totalIncrese.Text = Context.User.SelectedCurrency + " " + increase;
            totalConsume.Text = Context.User.SelectedCurrency + " " + consume;
            total.Text = Context.User.SelectedCurrency + " " + (increase - consume);


            List<string> uniqueDates = ListOperations.Select(o => o.Date).Distinct().ToList();

            days = new List<OperationsDays>();

            foreach (string date in uniqueDates)
            {
                OperationsDays day = new OperationsDays(
                    DateTime.Parse(date),
                    ListOperations.Where(operation => operation.Date == date).ToList()
                );
                days.Add(day);
            }

            if (days.Count == 0) NoOperations.IsVisible = true;
            else NoOperations.IsVisible = false;
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


        private async void ToNewOperationPage(object sender, EventArgs e) => await Navigation.PushAsync(new NewOperationPage());
        private async void ToCardPage(object sender, EventArgs e) => await Navigation.PushAsync(new CardPage());
        private async void ToCategoriesPage(object sender, EventArgs e) => await Navigation.PushAsync(new CategoriesPage());
        private async void ToListPage(object sender, EventArgs e) => await Navigation.PushAsync(new ListPage());
        private async void ToDiagramPage(object sender, EventArgs e) => await Navigation.PushAsync(new DiagramPage());
        private async void ToConverterPage(object sender, EventArgs e)
        {
            Currency currencyRates = await CurrencyRepository.GetCurrency();
            await Navigation.PushAsync(new ConverterPage(currencyRates));
        }
        private async void ToSettingsPage(object sender, EventArgs e) => await Navigation.PushAsync(new SetingsPage());

        private void DayButton(object sender, EventArgs e)
        {
            ChangeColor();
            if (sender is Button periodButton)
            {
                periodButton.BorderColor = Color.FromHex(Context.Color.DarkMode);
            }
            ShowOperations(DateTime.Today, DateTime.Today);
        }
        private void WeekButton(object sender, EventArgs e)
        {
            ChangeColor();
            if (sender is Button periodButton)
            {
                periodButton.BorderColor = Color.FromHex(Context.Color.DarkMode);
            }
            ShowOperations(DateTime.Today.AddDays(-7), DateTime.Today);
        }
        private void MonthButton(object sender, EventArgs e)
        {
            ChangeColor();
            if (sender is Button periodButton)
            {
                periodButton.BorderColor = Color.FromHex(Context.Color.DarkMode);
            }
            ShowOperations(DateTime.Today.AddMonths(-1), DateTime.Today);
        }
        private void YearButton(object sender, EventArgs e)
        {
            ChangeColor();
            if (sender is Button periodButton)
            {
                periodButton.BorderColor = Color.FromHex(Context.Color.DarkMode);
            }
            ShowOperations(DateTime.Today.AddYears(-1), DateTime.Today);
        }

        private void ChangeColor()
        {
            dayButton.BorderColor = Color.Black;
            weekButton.BorderColor = Color.Black;
            monthButton.BorderColor = Color.Black;
            yearButton.BorderColor = Color.Black;
        }
    }
}
