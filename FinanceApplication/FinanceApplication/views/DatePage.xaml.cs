using FinanceApp.classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatePage : ContentPage
    {
        Context context = new Context();

        public DatePage(Context context)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.context = context;
            imageCard.Source = ImageSource.FromResource("FinanceApplication.icons.card.png");
            imageCathegory.Source = ImageSource.FromResource("FinanceApplication.icons.categories.png");
            imageList.Source = ImageSource.FromResource("FinanceApplication.icons.list.png");
            imageDiagram.Source = ImageSource.FromResource("FinanceApplication.icons.diagram.png");
            imageConverter.Source = ImageSource.FromResource("FinanceApplication.icons.converter.png");
            LRow2.Source = ImageSource.FromResource("FinanceApplication.icons.Rrow.png");
            LRow1.Source = ImageSource.FromResource("FinanceApplication.icons.LRow.png");
            YearLabel.Text = DateTime.Now.ToString("yyyy");
            DateOnButton.Text = DateTime.Now.ToString("d");
        }


        private void SubstractionYear(object sender, EventArgs e)
        {
            int year = int.Parse(YearLabel.Text);
            YearLabel.Text = (--year).ToString();

            DateTime DateFromButton = DateTime.Parse(DateOnButton.Text);
            Console.WriteLine(DateFromButton);
            DateFromButton = DateFromButton.AddYears(-1);
            DateOnButton.Text = DateFromButton.ToString();
        }

        private void AdditionYear(object sender, EventArgs e)
        {
            int year = int.Parse(YearLabel.Text);
            YearLabel.Text = (++year).ToString();

            DateTime DateFromButton = DateTime.Parse(DateOnButton.Text);
            Console.WriteLine(DateFromButton);
            DateFromButton = DateFromButton.AddYears(1);
            DateOnButton.Text = DateFromButton.ToString();
        }

        private async void ToCardPage(object sender, EventArgs e) =>
            await Navigation.PushAsync(new CardPage(context));

        private async void ToListPage(object sender, EventArgs e) =>
            await Navigation.PushAsync(new ListPage(DateTime.Now, context));

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
                await Navigation.PushAsync(new ListPage(newPeriod, context));
            }
        }

        private void monthTrue(object sender, EventArgs e) => context.monthPeriod = true;
            
  
        private async void monthFalse(object sender, EventArgs e)
        {
            context.monthPeriod = false;
            await Navigation.PushAsync(new ListPage(DateTime.Now, context));
        }

    }
}