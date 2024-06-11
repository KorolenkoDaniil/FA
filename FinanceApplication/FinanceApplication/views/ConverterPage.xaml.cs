using FinanceApp.classes;
using FinanceApplication.core.Currency;
using FinanceApplication.icons;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Math;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConverterPage : ContentPage
    {
        private Currency currencyRates;
        private bool updateAllowed = false;

        public ConverterPage(Currency currency)
        {
            InitializeComponent();
            currencyRates = currency;
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeIcons();
            back.BackgroundColor = Color.FromHex(Context.User.AppModeColor);

            EntryUSD.Text = "1";
            AllToUSD();
        }
        private void EntryUSD_TextChanged(object sender, FocusEventArgs e)
        {
            AllToUSD();
        }

        private void EntryEUR_TextChanged(object sender, FocusEventArgs e)
        {
            AllToEUR();
        }

        private void EntryBYN_TextChanged(object sender, FocusEventArgs e)
        {
            AllToBYN();
        }

        private void EntryRUB_TextChanged(object sender, FocusEventArgs e)
        {
            AllToRUB();
        }

        private void EntryPLN_TextChanged(object sender, FocusEventArgs e)
        {
            AllToPLN();
        }

        private void EntryCNY_TextChanged(object sender, FocusEventArgs e)
        {
            AllToCNY();
        }

        private void AllToUSD()
        {
            if (!string.IsNullOrEmpty(EntryUSD.Text))
            {
                EntryUSD.Text = Round(currencyRates.ToUSD(1, decimal.Parse(EntryUSD.Text)), 3).ToString();
                EntryEUR.Text = Round(currencyRates.ToUSD(2, decimal.Parse(EntryUSD.Text)), 3).ToString();
                EntryRUB.Text = Round(currencyRates.ToUSD(3, decimal.Parse(EntryUSD.Text)), 3).ToString();
                EntryPLN.Text = Round(currencyRates.ToUSD(4, decimal.Parse(EntryUSD.Text)), 3).ToString();
                EntryCNY.Text = Round(currencyRates.ToUSD(5, decimal.Parse(EntryUSD.Text)), 3).ToString();
                EntryBYN.Text = Round(currencyRates.ToUSD(6, decimal.Parse(EntryUSD.Text)), 3).ToString();
            }
        }

        private void AllToEUR()
        {
            if (!string.IsNullOrEmpty(EntryEUR.Text))
            {
                EntryUSD.Text = Round(currencyRates.ToEUR(1, decimal.Parse(EntryEUR.Text)), 3).ToString();
                EntryEUR.Text = Round(currencyRates.ToEUR(2, decimal.Parse(EntryEUR.Text)), 3).ToString();
                EntryRUB.Text = Round(currencyRates.ToEUR(3, decimal.Parse(EntryEUR.Text)), 3).ToString();
                EntryPLN.Text = Round(currencyRates.ToEUR(4, decimal.Parse(EntryEUR.Text)), 3).ToString();
                EntryCNY.Text = Round(currencyRates.ToEUR(5, decimal.Parse(EntryEUR.Text)), 3).ToString();
                EntryBYN.Text = Round(currencyRates.ToEUR(6, decimal.Parse(EntryEUR.Text)), 3).ToString();
            }
        }

        private void AllToRUB()
        {
            if (!string.IsNullOrEmpty(EntryRUB.Text))
            {
                EntryUSD.Text = Round(currencyRates.ToRUB(1, decimal.Parse(EntryRUB.Text)), 3).ToString();
                EntryEUR.Text = Round(currencyRates.ToRUB(2, decimal.Parse(EntryRUB.Text)), 3).ToString();
                EntryRUB.Text = Round(currencyRates.ToRUB(3, decimal.Parse(EntryRUB.Text)), 3).ToString();
                EntryPLN.Text = Round(currencyRates.ToRUB(4, decimal.Parse(EntryRUB.Text)), 3).ToString();
                EntryCNY.Text = Round(currencyRates.ToRUB(5, decimal.Parse(EntryRUB.Text)), 3).ToString();
                EntryBYN.Text = Round(currencyRates.ToRUB(6, decimal.Parse(EntryRUB.Text)), 3).ToString();
            }
        }

        private void AllToPLN()
        {
            if (!string.IsNullOrEmpty(EntryPLN.Text))
            {
                EntryUSD.Text = Round(currencyRates.ToPLN(1, decimal.Parse(EntryPLN.Text)), 3).ToString();
                EntryEUR.Text = Round(currencyRates.ToPLN(2, decimal.Parse(EntryPLN.Text)), 3).ToString();
                EntryRUB.Text = Round(currencyRates.ToPLN(3, decimal.Parse(EntryPLN.Text)), 3).ToString();
                EntryPLN.Text = Round(currencyRates.ToPLN(4, decimal.Parse(EntryPLN.Text)), 3).ToString();
                EntryCNY.Text = Round(currencyRates.ToPLN(5, decimal.Parse(EntryPLN.Text)), 3).ToString();
                EntryBYN.Text = Round(currencyRates.ToPLN(6, decimal.Parse(EntryPLN.Text)), 3).ToString();
            }
        }

        private void AllToCNY()
        {
            if (!string.IsNullOrEmpty(EntryCNY.Text))
            {
                EntryUSD.Text = Round(currencyRates.ToCNY(1, decimal.Parse(EntryCNY.Text)), 3).ToString();
                EntryEUR.Text = Round(currencyRates.ToCNY(2, decimal.Parse(EntryCNY.Text)), 3).ToString();
                EntryRUB.Text = Round(currencyRates.ToCNY(3, decimal.Parse(EntryCNY.Text)), 3).ToString();
                EntryPLN.Text = Round(currencyRates.ToCNY(4, decimal.Parse(EntryCNY.Text)), 3).ToString();
                EntryCNY.Text = Round(currencyRates.ToCNY(5, decimal.Parse(EntryCNY.Text)), 3).ToString();
                EntryBYN.Text = Round(currencyRates.ToCNY(6, decimal.Parse(EntryCNY.Text)), 3).ToString();
            }
        }

        private void AllToBYN()
        {
            if (!string.IsNullOrEmpty(EntryBYN.Text))
            {
                EntryUSD.Text = Round(currencyRates.ToCNY(1, decimal.Parse(EntryBYN.Text)), 3).ToString();
                EntryEUR.Text = Round(currencyRates.ToCNY(2, decimal.Parse(EntryBYN.Text)), 3).ToString();
                EntryRUB.Text = Round(currencyRates.ToCNY(3, decimal.Parse(EntryBYN.Text)), 3).ToString();
                EntryPLN.Text = Round(currencyRates.ToCNY(4, decimal.Parse(EntryBYN.Text)), 3).ToString();
                EntryCNY.Text = Round(currencyRates.ToCNY(5, decimal.Parse(EntryBYN.Text)), 3).ToString();
                EntryBYN.Text = Round(currencyRates.ToCNY(6, decimal.Parse(EntryBYN.Text)), 3).ToString();
            }
        }



        private void InitializeIcons()
        {
            imageCard.Source = ImageSource.FromResource(Icons.Iconspath[2]);
            imageCathegory.Source = ImageSource.FromResource(Icons.Iconspath[3]);
            imageList.Source = ImageSource.FromResource(Icons.Iconspath[8]);
            imageDiagram.Source = ImageSource.FromResource(Icons.Iconspath[6]);
            imageConverter.Source = ImageSource.FromResource(Icons.Iconspath[4]);
        }
        private async void ToNewCategoryPage(object sender, EventArgs e) => await Navigation.PushAsync(new NewOperationPage());
        private async void ToCardPage(object sender, EventArgs e) => await Navigation.PushAsync(new CardPage());
        private async void ToCategoriesPage(object sender, EventArgs e) => await Navigation.PushAsync(new CategoriesPage());
        private async void ToListPage(object sender, EventArgs e) => await Navigation.PushAsync(new ListPage());
        private async void ToDiagramPage(object sender, EventArgs e) => await Navigation.PushAsync(new DiagramPage());
        private async void ToSettingsPage(object sender, EventArgs e) => await Navigation.PushAsync(new SetingsPage());
    }

}
