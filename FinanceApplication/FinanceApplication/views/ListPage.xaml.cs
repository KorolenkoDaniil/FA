using FinanceApp.classes;
using System;
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

        public ListPage (Context context)
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
            ShowOperations();
            total.Text = $"$ {totalBalance}";

            Console.WriteLine("точка 8");

        }

        private void ShowOperations()
        {
            Console.WriteLine("!!!");
            Console.WriteLine("----------- новая таблица");

            var operations1 = from operation in context.Operations
                              join cathegory in context.Categories on operation.Cathegory equals cathegory.Name
                              join wallet in context.Wallets on operation.WalletId equals wallet.WalletId
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

            Console.WriteLine("!!!");
        }


        private async void ToCardPage (object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CardPage(context));
        }

        private void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {

        }

        //decimal TotalBalance
        //{
        //    get => totalBalance;
        //}
    }
}