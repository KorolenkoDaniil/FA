using FinanceApp.classes;
using FinanceApplication.core;
using FinanceApplication.core.Currency;
using FinanceApplication.icons;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : ContentPage
    {
        List<ExtendedCategory> ListExtendedCategories;
        bool profit = true;
        public CategoriesPage()
        {
            InitializeComponent();
            ShowCategories();
            NavigationPage.SetHasNavigationBar(this, false);
            imageCard.Source = ImageSource.FromResource(Icons.Iconspath[2]);
            imageCathegory.Source = ImageSource.FromResource(Icons.Iconspath[3]);
            imageList.Source = ImageSource.FromResource(Icons.Iconspath[8]);
            imageDiagram.Source = ImageSource.FromResource(Icons.Iconspath[6]);
            imageConverter.Source = ImageSource.FromResource(Icons.Iconspath[4]);
            Settings.Source = ImageSource.FromResource(Icons.Iconspath[12]);
            PlusButton.BackgroundColor = Color.FromHex(Context.Color.DarkMode);
        }

        public void ShowCategories()
        {
            ListExtendedCategories = (from category in Context.Categories
                                      join color in Context.Colors on category.ColorId equals color.ColorId
                                      select new ExtendedCategory(category.Name, color.DarkMode, category.IconId, category.CategoryId, Context.User.UserId, category.ColorId, category.IsProfit)).ToList();

            CategoriesCollection.ItemsSource = ListExtendedCategories.Where(cat => cat.IsProfit);
        }


        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as ExtendedCategory;

            if (selectedItem != null)
            {
                await Navigation.PushAsync(new NewCategoryPage(selectedItem));
            }

            CategoriesCollection.SelectedItem = null;
        }

 

        private async void ToNewCategoryPage(object sender, EventArgs e) => await Navigation.PushAsync(new NewOperationPage());
        private async void ToCardPage(object sender, EventArgs e) => await Navigation.PushAsync(new CardPage());
        private async void ToCategoriesPage(object sender, EventArgs e) => await Navigation.PushAsync(new CategoriesPage());
        private async void ToListPage(object sender, EventArgs e) => await Navigation.PushAsync(new ListPage(DateTime.Now));
        private async void ToDiagramPage(object sender, EventArgs e) => await Navigation.PushAsync(new DiagramPage());
        private async void ToConverterPage(object sender, EventArgs e) 
        {
            Currency currencyRates = await CurrencyRepository.GetCurrency();
            await Navigation.PushAsync(new ConverterPage(currencyRates));
        } 
        private async void ToSettingsPage(object sender, EventArgs e) => await Navigation.PushAsync(new SettingsPage());
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e) => await Navigation.PushAsync(new NewCategoryPage(profit));

        private void Button_enrease_Clicked(object sender, EventArgs e)
        {
            CategoriesCollection.ItemsSource = ListExtendedCategories.Where(cat => cat.IsProfit);
            profit = false;
        }



        private void Button_consume_Clicked_1(object sender, EventArgs e)
        {
            CategoriesCollection.ItemsSource = ListExtendedCategories.Where(cat => !cat.IsProfit);
            profit = true;
        }
    }
}