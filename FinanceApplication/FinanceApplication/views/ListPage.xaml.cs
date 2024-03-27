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
            ShowOperations();
        }


        private void ShowOperations()
        { 
            if (context.Operations == null) { NoOperations.IsVisible = true; return; } 
            
            foreach (Operation operation in context.Operations) 
            {
                Console.WriteLine(operation);
            }
            OperationsCollection.ItemsSource = context.Operations;
        }

        private void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}