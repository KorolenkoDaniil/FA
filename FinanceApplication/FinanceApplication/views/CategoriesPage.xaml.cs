using FinanceApp.classes;
using FinanceApplication.core.Category;
using FinanceApplication.icons;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : ContentPage
    {
        Context context;
        public CategoriesPage(Context context)
        {
            InitializeComponent();
            this.context = context;
            NavigationPage.SetHasNavigationBar(this, false);
            imageCard.Source = ImageSource.FromResource(Icons.Iconspath[2]);
            imageCathegory.Source = ImageSource.FromResource(Icons.Iconspath[3]); ;
            imageList.Source = ImageSource.FromResource(Icons.Iconspath[8]);
            imageDiagram.Source = ImageSource.FromResource(Icons.Iconspath[6]);
            imageConverter.Source = ImageSource.FromResource(Icons.Iconspath[4]);
            Settings.Source = ImageSource.FromResource(Icons.Iconspath[12]);

            CategoriesCollection.ItemsSource = context.Categories;
            PlusButton.BackgroundColor = Color.FromHex(context.Color.LightMode);
        }


        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as Category;

            if (selectedItem != null)
            {
                await Navigation.PushAsync(new NewCategoryPage(context, selectedItem));
            }

            CategoriesCollection.SelectedItem = null;
        }

 

        private async void ToNewCategoryPage(object sender, EventArgs e) => await Navigation.PushAsync(new NewOperationPage(context));
        private async void ToCardPage(object sender, EventArgs e) => await Navigation.PushAsync(new CardPage(context));
        private async void ToCategoriesPage(object sender, EventArgs e) => await Navigation.PushAsync(new CategoriesPage(context));
        private async void ToListPage(object sender, EventArgs e) => await Navigation.PushAsync(new ListPage(DateTime.Now, context));
        private async void ToDiagramPage(object sender, EventArgs e) => await Navigation.PushAsync(new DiagramPage(context));
        private async void ToConverterPage(object sender, EventArgs e) => await Navigation.PushAsync(new ConverterPage(context));
        private async void ToSettingsPage(object sender, EventArgs e) => await Navigation.PushAsync(new SettingsPage(context));
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e) => await Navigation.PushAsync(new NewCategoryPage(context));
       
    }
}