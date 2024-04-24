using FinanceApp.classes;
using FinanceApplication.core;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OneCardPage : ContentPage
	{
        Context context;
        ExtendedWallet wallet;
        public OneCardPage (ExtendedWallet wallet, Context context)
		{
			InitializeComponent ();
            this.context = context;
            this.wallet = wallet;
        }
	}
}