using FinanceApp.classes;
using FinanceApplication.core.Currency;
using FinanceApplication.icons;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConverterPage : ContentPage
    {
        Context context = new Context();
        Currency currencyRates;

        public ConverterPage(Context context, Currency currency)
        {
            InitializeComponent();
            this.context = context;
            currencyRates = currency;
            NavigationPage.SetHasNavigationBar(this, false);
            imageCard.Source = ImageSource.FromResource(Icons.Iconspath[2]);
            imageCathegory.Source = ImageSource.FromResource(Icons.Iconspath[3]); ;
            imageList.Source = ImageSource.FromResource(Icons.Iconspath[8]);
            imageDiagram.Source = ImageSource.FromResource(Icons.Iconspath[6]);
            imageConverter.Source = ImageSource.FromResource(Icons.Iconspath[4]);

            EntryUSD.Text = "1";
            EntryEUR.Text = currencyRates.ConvertUSDtoEUR(1).ToString();
            EntryBYN.Text = currencyRates.ConvertUSDtoBYN(1).ToString();
            EntryRUB.Text = currencyRates.ConvertUSDtoRUB(1).ToString();
            EntryPLN.Text = currencyRates.ConvertUSDtoPLN(1).ToString();
            EntryCNY.Text = currencyRates.ConvertUSDtoCNY(1).ToString();
        }


        private async void ToCardPage(object sender, EventArgs e) => await Navigation.PushAsync(new CardPage(context));
        private async void ToCategoriesPage(object sender, EventArgs e) => await Navigation.PushAsync(new CategoriesPage(context));
        private async void ToListPage(object sender, EventArgs e) => await Navigation.PushAsync(new ListPage(DateTime.Now, context));
        private async void ToDiagramPage(object sender, EventArgs e) => await Navigation.PushAsync(new DiagramPage(context));
        private async void ToConverterPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConverterPage(context, currencyRates));
        }
        private async void ToSettingsPage(object sender, EventArgs e) => await Navigation.PushAsync(new SettingsPage(context));

  
        private void EntryUSD_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(EntryUSD.Text)) return;
            try
            {
                decimal USD = 0;
                if (decimal.TryParse(EntryUSD.Text, out USD))
                {
                    EntryEUR.Text = currencyRates.ConvertUSDtoEUR(USD).ToString();
                    EntryBYN.Text = currencyRates.ConvertUSDtoBYN(USD).ToString();
                    EntryRUB.Text = currencyRates.ConvertUSDtoRUB(USD).ToString();
                    EntryPLN.Text = currencyRates.ConvertUSDtoPLN(USD).ToString();
                    EntryCNY.Text = currencyRates.ConvertUSDtoCNY(USD).ToString();
                }
                else
                    ToZero();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void EntryEUR_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(EntryEUR.Text)) return;
            try
            {
                decimal EUR = 0;
                if (decimal.TryParse(EntryEUR.Text, out EUR))
                {
                    EUR = currencyRates.ConvertEURtoUSD(EUR);

                    EntryUSD.Text = EUR.ToString();
                    EntryBYN.Text = currencyRates.ConvertUSDtoBYN(EUR).ToString();
                    EntryRUB.Text = currencyRates.ConvertUSDtoRUB(EUR).ToString();
                    EntryPLN.Text = currencyRates.ConvertUSDtoPLN(EUR).ToString();
                    EntryCNY.Text = currencyRates.ConvertUSDtoCNY(EUR).ToString();
                }
                else
                    ToZero();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void EntryBYN_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(EntryBYN.Text)) return;
            try
            {
                decimal BYN = 0;
                if (decimal.TryParse(EntryUSD.Text, out BYN))
                {
                    BYN = currencyRates.ConvertBYNtoUSD(BYN);

                    EntryUSD.Text = BYN.ToString();
                    EntryEUR.Text = currencyRates.ConvertUSDtoEUR(BYN).ToString();
                    EntryRUB.Text = currencyRates.ConvertUSDtoRUB(BYN).ToString();
                    EntryPLN.Text = currencyRates.ConvertUSDtoPLN(BYN).ToString();
                    EntryCNY.Text = currencyRates.ConvertUSDtoCNY(BYN).ToString();
                }
                else
                    ToZero();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void EntryRUB_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(EntryRUB.Text)) return;
            try
            {
                decimal RUB = 0;
                if (decimal.TryParse(EntryUSD.Text, out RUB))
                {
                    RUB = currencyRates.ConvertBYNtoUSD(RUB);

                    EntryUSD.Text = RUB.ToString();
                    EntryEUR.Text = currencyRates.ConvertUSDtoEUR(RUB).ToString();
                    EntryBYN.Text = currencyRates.ConvertUSDtoBYN(RUB).ToString();
                    EntryPLN.Text = currencyRates.ConvertUSDtoPLN(RUB).ToString();
                    EntryCNY.Text = currencyRates.ConvertUSDtoCNY(RUB).ToString();
                }
                else
                    ToZero();
            }
            catch { }
        }

        private void EntryPLN_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(EntryPLN.Text)) return;
            try
            {
                decimal PLN = 0;
                if (decimal.TryParse(EntryUSD.Text, out PLN))
                {
                    PLN = currencyRates.ConvertPLNtoUSD(PLN);

                    EntryUSD.Text = PLN.ToString();
                    EntryEUR.Text = currencyRates.ConvertUSDtoEUR(PLN).ToString();
                    EntryBYN.Text = currencyRates.ConvertUSDtoBYN(PLN).ToString();
                    EntryRUB.Text = currencyRates.ConvertUSDtoRUB(PLN).ToString();
                    EntryCNY.Text = currencyRates.ConvertUSDtoCNY(PLN).ToString();
                }
                else
                    ToZero();
            }
            catch { }
        }

        private void EntryCNY_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(EntryCNY.Text)) return;
            try
            {
                decimal CNY = 0;
                if (decimal.TryParse(EntryCNY.Text, out CNY))
                {
                    CNY = currencyRates.ConvertCNYtoUSD(CNY);

                    EntryUSD.Text = CNY.ToString();

                    EntryEUR.Text = currencyRates.ConvertUSDtoEUR(CNY).ToString();
                    EntryBYN.Text = currencyRates.ConvertUSDtoBYN(CNY).ToString();
                    EntryRUB.Text = currencyRates.ConvertUSDtoRUB(CNY).ToString();
                    EntryPLN.Text = currencyRates.ConvertUSDtoPLN(CNY).ToString();
                    //EntryCNY.Text = currencyRates.ConvertUSDtoCNY(CNY).ToString();
                }
                else
                    ToZero();
                
            }
            catch { }
        }

        public void ToZero()
        {
            EntryUSD.Text = "0";
            EntryEUR.Text = "0";
            EntryBYN.Text = "0";
            EntryRUB.Text = "0";
            EntryPLN.Text = "0";
            EntryCNY.Text = "0";
        }
    }
}