using FinanceApp.classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DiagramPage : ContentPage
	{
        Context context = new Context();

        public DiagramPage(Context context)
        {
            InitializeComponent();
            this.context = context;


        }
    }
}