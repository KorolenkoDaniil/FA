using FinanceApp.classes;
using FinanceApplication.core;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OperationsPerDay : ContentPage
    {
        OperationsDays dayOperations;

        public OperationsPerDay(OperationsDays dayOperations)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            back.BackgroundColor = Color.FromHex(Context.User.AppModeColor);
            this.dayOperations = dayOperations;

            foreach (var item in dayOperations.Operations)
            {
                Console.WriteLine(item);
            }

            //foreach (var item in Context.Wallets)
            //{
            //    Console.WriteLine(item);

            //}

            //List<ExtendedDayOperation> extendeoperations = (from dayOperation in dayOperations.Operations
            //                                                join wallet in Context.Wallets on dayOperation.Id equals wallet.WalletId
            //                                                select new 
            //                                                ExtendedDayOperation(dayOperation.Id, dayOperation.Profit, dayOperation.Date, dayOperation.Sum, dayOperation.WalletId,
            //                                                dayOperation.Cathegory, dayOperation.Description, dayOperation.WalletName, ImageSource.FromResource(Icons.WalletsIcons[wallet.IconId]),
            //                                                Color.FromHex(Context.Colors[wallet.ColorId].DarkMode))
            //                                                ).ToList();

            //foreach (var item in extendeoperations)
            //{
            //    Console.WriteLine(item);
            //}


            OperationsCollection.ItemsSource = dayOperations.Operations.Where(op => op.Profit == true);
            OperationsCollection1.ItemsSource = dayOperations.Operations.Where(op => op.Profit == false);
            Title.Text = "Операции за " + dayOperations.Operations[0].Date;

          

        }


        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as OperationResult;

            //if (selectedItem != null)
            //{
            //    await Navigation.PushAsync(new OperationsPerDay(selectedItem));
            //}

            OperationsCollection.SelectedItem = null;
        }
        private async void OnItemSelected1(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as OperationResult;

            //if (selectedItem != null)
            //{
            //    await Navigation.PushAsync(new OperationsPerDay(selectedItem));
            //}

            OperationsCollection.SelectedItem = null;
        }



    }
}
