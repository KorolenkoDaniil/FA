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

        public OperationsPerDay(OperationsDays dayOperations)
        {
            InitializeComponent();
            back.BackgroundColor = Color.FromHex(Context.User.AppModeColor);
            this.dayOperations = dayOperations;
        }

    }
}
