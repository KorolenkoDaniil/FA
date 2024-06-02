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
        Currency currencyRates;
        bool isUpdating = false;

        public ConverterPage(Currency currency)
        {
            InitializeComponent();
            currencyRates = currency;
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeIcons();
            UpdateCurrencyValues(1);
            InitializeEventHandlers();
            back.BackgroundColor = Color.FromHex(Context.User.AppModeColor);
        }

        private void InitializeIcons()
        {
            imageCard.Source = ImageSource.FromResource(Icons.Iconspath[2]);
            imageCathegory.Source = ImageSource.FromResource(Icons.Iconspath[3]);
            imageList.Source = ImageSource.FromResource(Icons.Iconspath[8]);
            imageDiagram.Source = ImageSource.FromResource(Icons.Iconspath[6]);
            imageConverter.Source = ImageSource.FromResource(Icons.Iconspath[4]);
        }

        private void InitializeEventHandlers()
        {
            EntryUSD.Unfocused += EntryUSD_TextChanged;
            EntryEUR.Unfocused += EntryEUR_TextChanged;
            EntryBYN.Unfocused += EntryBYN_TextChanged;
            EntryRUB.Unfocused += EntryRUB_TextChanged;
            EntryPLN.Unfocused += EntryPLN_TextChanged;
            EntryCNY.Unfocused += EntryCNY_TextChanged;
        }

        private void UpdateCurrencyValues(decimal value)
        {
            
            if (isUpdating) return;
            isUpdating = true;

            EntryEUR.Text = currencyRates.ConvertUSDtoEUR(value).ToString();
            EntryBYN.Text = currencyRates.ConvertUSDtoBYN(value).ToString();
            EntryRUB.Text = currencyRates.ConvertUSDtoRUB(value).ToString();
            EntryPLN.Text = currencyRates.ConvertUSDtoPLN(value).ToString();
            EntryCNY.Text = currencyRates.ConvertUSDtoCNY(value).ToString();

            isUpdating = false;
        }

        private void EntryUSD_TextChanged(object sender, FocusEventArgs e)
        {
            Console.WriteLine("текст изменился");
            if (isUpdating) return;
            if (decimal.TryParse(EntryUSD.Text, out decimal USD) && USD != 0)
            {
                UpdateCurrencyValues(Abs(USD));
            }
        }

        private void EntryEUR_TextChanged(object sender, FocusEventArgs e)
        {
            Console.WriteLine("текст изменился");
            if (isUpdating) return;
            if (decimal.TryParse(EntryEUR.Text, out decimal EUR) && EUR != 0)
            {
                decimal convertedUSD = currencyRates.ConvertEURtoUSD(Abs(EUR));
                EntryUSD.Text = convertedUSD.ToString();
                UpdateCurrencyValues(convertedUSD);
            }
        }

        private void EntryBYN_TextChanged(object sender, FocusEventArgs e)
        {
            Console.WriteLine("текст изменился");
            if (isUpdating) return;
            if (decimal.TryParse(EntryBYN.Text, out decimal BYN))
            {
                decimal convertedUSD = currencyRates.ConvertBYNtoUSD(Abs(BYN));
                EntryUSD.Text = convertedUSD.ToString();
                UpdateCurrencyValues(convertedUSD);
            }
        }
        private void EntryRUB_TextChanged(object sender, FocusEventArgs e)
        {
            Console.WriteLine("текст изменился");
            if (isUpdating) return; // Если уже происходит обновление, выходим
            if (decimal.TryParse(EntryRUB.Text, out decimal RUB) && RUB != 0)
            {
                decimal convertedUSD = currencyRates.ConvertRUBtoUSD(Abs(RUB));
                EntryUSD.Text = convertedUSD.ToString();
                UpdateCurrencyValues(convertedUSD);
            }
        }

        private void EntryPLN_TextChanged(object sender, FocusEventArgs e)
        {
            if (isUpdating) return; // Если уже происходит обновление, выходим
            if (decimal.TryParse(EntryPLN.Text, out decimal PLN) && PLN != 0)
            {
                decimal convertedUSD = currencyRates.ConvertPLNtoUSD(Abs(PLN));
                EntryUSD.Text = convertedUSD.ToString();
                UpdateCurrencyValues(convertedUSD);
            }
        }

        private void EntryCNY_TextChanged(object sender, FocusEventArgs e)
        {
            if (isUpdating) return; // Если уже происходит обновление, выходим
            if (decimal.TryParse(EntryCNY.Text, out decimal CNY) && CNY != 0)
            {
                decimal convertedUSD = currencyRates.ConvertCNYtoUSD(Abs(CNY));
                EntryUSD.Text = convertedUSD.ToString();
                UpdateCurrencyValues(convertedUSD);
            }
        }


        private async void ToNewCategoryPage(object sender, EventArgs e) => await Navigation.PushAsync(new NewOperationPage());
        private async void ToCardPage(object sender, EventArgs e) => await Navigation.PushAsync(new CardPage());
        private async void ToCategoriesPage(object sender, EventArgs e) => await Navigation.PushAsync(new CategoriesPage());
        private async void ToListPage(object sender, EventArgs e) => await Navigation.PushAsync(new ListPage());
        private async void ToDiagramPage(object sender, EventArgs e) => await Navigation.PushAsync(new DiagramPage());
        private async void ToSettingsPage(object sender, EventArgs e) => await Navigation.PushAsync(new SetingsPage());
        
    }
}