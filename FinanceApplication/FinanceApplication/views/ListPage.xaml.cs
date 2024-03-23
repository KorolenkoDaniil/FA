using FinanceApp.classes;
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
        }
	}
}