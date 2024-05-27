using FinanceApp.classes;
using FinanceApplication.core.Currency;
using FinanceApplication.icons;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatePage : ContentPage
    {

        public DatePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            imageCard.Source = ImageSource.FromResource(Icons.Iconspath[2]);
            imageCathegory.Source = ImageSource.FromResource(Icons.Iconspath[3]);
            imageList.Source = ImageSource.FromResource(Icons.Iconspath[8]);
            imageDiagram.Source = ImageSource.FromResource(Icons.Iconspath[6]);
            imageConverter.Source = ImageSource.FromResource(Icons.Iconspath[4]);
            LRow2.Source = ImageSource.FromResource(Icons.Iconspath[11]);
            LRow1.Source = ImageSource.FromResource(Icons.Iconspath[9]);
            YearLabel.Text = DateTime.Now.ToString("yyyy");
            DateOnButton.Text = DateTime.Now.ToString("d");
        }


        private void SubstractionYear(object sender, EventArgs e)
        {
            int year = int.Parse(YearLabel.Text);
            YearLabel.Text = (--year).ToString();

            DateTime DateFromButton = DateTime.Parse(DateOnButton.Text);
            DateFromButton = DateFromButton.AddYears(-1);
            DateOnButton.Text = DateFromButton.ToString();
        }

        private void AdditionYear(object sender, EventArgs e)
        {
            int year = int.Parse(YearLabel.Text);
            YearLabel.Text = (++year).ToString();

            DateTime DateFromButton = DateTime.Parse(DateOnButton.Text);
            DateFromButton = DateFromButton.AddYears(1);
            DateOnButton.Text = DateFromButton.ToString();
        }

   
        public static int ConvertMonthNameToNumber(string monthName)
        {
            Dictionary<string, int> months = new Dictionary<string, int>
            {
                {"янв", 1},
                {"фев", 2},
                {"мар", 3},
                {"апр", 4},
                {"май", 5},
                {"июн", 6},
                {"июл", 7},
                {"авг", 8},
                {"сен", 9},
                {"окт", 10},
                {"ноя", 11},
                {"дек", 12}
        };

            if (months.TryGetValue(monthName.ToLower(), out int monthNumber))
            {
                return monthNumber;
            }
            else
            {
                throw new ArgumentException("Недопустимое название месяца");
            }
        }

        private async void NewPeriod(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                DateTime newPeriod = new DateTime(int.Parse(YearLabel.Text), ConvertMonthNameToNumber(button.Text), 1);
                await Navigation.PushAsync(new ListPage(newPeriod));
            }
        }

        private void monthTrue(object sender, EventArgs e) => Context.monthPeriod = true;
            
  
        private async void monthFalse(object sender, EventArgs e)
        {
            Context.monthPeriod = false;
            await Navigation.PushAsync(new ListPage(DateTime.Now));
        }

        private async void ToCardPage(object sender, EventArgs e) => await Navigation.PushAsync(new CardPage());
        private async void ToCategoriesPage(object sender, EventArgs e) => await Navigation.PushAsync(new CategoriesPage());
        private async void ToListPage(object sender, EventArgs e) => await Navigation.PushAsync(new ListPage(DateTime.Now));
        private async void ToDiagramPage(object sender, EventArgs e) => await Navigation.PushAsync(new DiagramPage());
        private async void ToConverterPage(object sender, EventArgs e)
        {
            Currency currencyRates = await CurrencyRepository.GetCurrency();
            await Navigation.PushAsync(new ConverterPage(currencyRates));
        }

    }
}