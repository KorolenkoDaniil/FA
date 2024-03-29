using FinanceApp.classes;
using FinanceApp.classes.Wallets;
using FinanceApplication.core.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListPage : ContentPage
	{
        Context context = new Context();

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


            Console.WriteLine("точка 8");

        }

        private void ShowOperations()
        {
            Console.WriteLine("!!!");
            var operations1 = from p in context.Operations
                              join c in context.Categories on p.Cathegory equals c.Name
                              select new
                              {
                                  Day = p.Day,
                                  Month = p.Month,
                                  Year = p.Year,
                                  Profit = p.Profit,
                                  Sum = p.Sum,
                                  Cathegory = p.Cathegory,
                                  Name = c.Name
                              };


            foreach (var op in operations1)
            {
                Console.WriteLine($"{op.Day} {op.Name} {op.Sum} {op.Profit} {op.Month}");
            }

            OperationsCollection.ItemsSource = operations1;
            
        }


        private async void ToCardPage (object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CardPage(context));
        }

        private void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}