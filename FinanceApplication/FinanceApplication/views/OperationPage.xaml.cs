using FinanceApp.classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OperationPage : ContentPage
    {
        Context context = new Context();
        public OperationPage(Context context)
        {
            InitializeComponent();
            this.context = context;
        }
    }
}