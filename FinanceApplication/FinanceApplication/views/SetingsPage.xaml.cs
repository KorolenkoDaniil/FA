using FinanceApp.classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        Context context;

        public SettingsPage(Context context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {

        }
    }
}