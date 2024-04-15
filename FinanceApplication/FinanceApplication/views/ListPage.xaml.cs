using FinanceApp.classes;
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

        public ListPage (DateTime newPeriod, Context context)
		{
			InitializeComponent ();
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
            Console.WriteLine("---------- новая таблица");


            string month = ConvertFromIntToStringMonth(newPeriod.Month);
            int year = newPeriod.Year;

            if (context.monthPeriod) MonthSelection(month, year);
            else YearSelection(year);

        }

        public void MonthSelection(string month, int year)
        {
            var operations1 = from operation in context.Operations
                              join cathegory in context.Categories on operation.Cathegory equals cathegory.Name
                              join wallet in context.Wallets on operation.WalletId equals wallet.WalletId
                              where operation.Month == month && operation.Year == year
                              select new
                              {
                                  Id = operation.Id,
                                  UserId = cathegory.UserId,
                                  Day = operation.Day,
                                  Month = operation.Month,
                                  Year = operation.Year,
                                  Profit = operation.Profit,
                                  Sum = operation.Sum,
                                  WalletId = operation.WalletId,
                                  Cathegory = cathegory.Name,
                                  Description = operation.Description,
                                  WalletName = wallet.Name,
                                  WalletType = wallet.Type,
                              };

            totalBalance = operations1.Sum(op => op.Sum);

            Console.WriteLine("----------- новая таблица");
            foreach (var op in operations1)
            {
                Console.WriteLine($"{op.Id} {op.UserId} {op.Day} {op.Month} {op.Year} {op.Profit} {op.Sum} {op.WalletId} {op.Cathegory} {op.Description} {op.WalletName} {op.WalletType}");
            }
            Console.WriteLine("----------- сумма");
            Console.WriteLine(totalBalance);

            OperationsCollection.ItemsSource = operations1;
        }

        public void YearSelection(int year)
        {
           var operations1 = from operation in context.Operations
                          join cathegory in context.Categories on operation.Cathegory equals cathegory.Name
                          join wallet in context.Wallets on operation.WalletId equals wallet.WalletId
                          where operation.Year == year
                          select new
                          {
                              Id = operation.Id,
                              UserId = cathegory.UserId,
                              Day = operation.Day,
                              Month = operation.Month,
                              Year = operation.Year,
                              Profit = operation.Profit,
                              Sum = operation.Sum,
                              WalletId = operation.WalletId,
                              Cathegory = cathegory.Name,
                              Description = operation.Description,
                              WalletName = wallet.Name,
                              WalletType = wallet.Type,
                          };
            foreach (var op in operations1)
            {
                Console.WriteLine($"{op.Id} {op.UserId} {op.Day} {op.Month} {op.Year} {op.Profit} {op.Sum} {op.WalletId} {op.Cathegory} {op.Description} {op.WalletName} {op.WalletType}");
                totalBalance += op.Sum;
            }
            Console.WriteLine("----------- новая таблица");
            Console.WriteLine("----------- сумма");
            Console.WriteLine(totalBalance);
            Console.WriteLine("----------- сумма");


            OperationsCollection.ItemsSource = operations1;
        }



        private async void ToCardPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CardPage(context));
        }

        private void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void ToDatePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DatePage(context));
        }


       private string ConvertFromIntToStringMonth(int monthNumber)
        {

            Dictionary<int, string> months = new Dictionary<int, string>
            {
                {1, "январь"},
                {2, "февраль"},
                {3, "март"},
                {4, "апрель"},
                {5, "май"},
                {6, "июнь"},
                {7, "июль"},
                {8, "август"},
                {9, "сентябрь"},
                {10, "октябрь"},
                {11, "ноябрь"},
                {12, "декабрь"},
        };

            if (months.TryGetValue(monthNumber, out string monthName))
            {
                return monthName;
            }
            else { return null; }
        }

        private async void ToNewOperationPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewOperationPage(context));
        }
    }
}