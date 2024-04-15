using FinanceApp.classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConverterPage : ContentPage
	{
        Context context = new Context();

        public ConverterPage (Context context)
		{
			InitializeComponent ();
            this.context = context;
        }
	}
}