using FinanceApp.classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoryPagePage : ContentPage
	{
		Context context;
		public CategoryPagePage (Context context)
		{
			InitializeComponent ();
			this.context = context;
		}
	}
}