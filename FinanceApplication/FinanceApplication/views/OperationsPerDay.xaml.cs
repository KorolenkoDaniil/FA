using FinanceApp.classes;
using FinanceApplication.core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OperationsPerDay : ContentPage
	{
		OperationsDays dayOperations;
		Context context;

        public OperationsPerDay (OperationsDays dayOperations, Context context)
		{
			InitializeComponent ();
			this.dayOperations = dayOperations;
			this.context = context;
		}
	}
}