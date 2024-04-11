using FinanceApp.classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DiagramPage : ContentPage
	{
		Context context;
        public DiagramPage (Context context)
		{
			InitializeComponent ();
			this.context = context;
		}



	}
}