using FinanceApp.classes;
using FinanceApplication.core;
using FinanceApplication.core.Category;
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
        Context context;
        public CategoriesPage(Context context)
        {
            InitializeComponent();
            this.context = context;
            ShowCategories();
            NavigationPage.SetHasNavigationBar(this, false);
            imageCard.Source = ImageSource.FromResource(Icons.Iconspath[2]);
            imageCathegory.Source = ImageSource.FromResource(Icons.Iconspath[3]); ;
            imageList.Source = ImageSource.FromResource(Icons.Iconspath[8]);
            imageDiagram.Source = ImageSource.FromResource(Icons.Iconspath[6]);
            imageConverter.Source = ImageSource.FromResource(Icons.Iconspath[4]);
            //Settings.Source = ImageSource.FromResource(Icons.Iconspath[12]);
            PlusButton.BackgroundColor = Color.FromHex(context.Color.LightMode);
        }

        public void ShowCategories()
        {
            List<ExtendedCategory> CategoriesWithColors = (from category in context.Categories
                                                        join color in context.Colors on category.ColorId equals color.ColorId
                                                        select new ExtendedCategory(category.Name, color.DarkMode, color.LightMode, category.IconId, category.CategoryId, context.User.UserId, category.ColorId)).ToList();


            Console.WriteLine("------------------------новые категории");
            foreach (ExtendedCategory category in CategoriesWithColors)
            {
                category.CategorySum = context.Operations.Where(categ => categ.Cathegory == category.Name && categ.Profit).Sum(u => u.Sum) - context.Operations.Where(categ => categ.Cathegory == category.Name && !categ.Profit).Sum(u => u.Sum);
                Console.WriteLine(category);
            }
            Console.WriteLine("------------------------новые категории");

            CategoriesCollection.ItemsSource = CategoriesWithColors;
        }


        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as ExtendedCategory;

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
        private async void ToConverterPage(object sender, EventArgs e) 
        {
            Currency currencyRates = await CurrencyRepository.GetCurrency();
            await Navigation.PushAsync(new ConverterPage(context, currencyRates));
        } 
        private async void ToSettingsPage(object sender, EventArgs e) => await Navigation.PushAsync(new SettingsPage(context));
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e) => await Navigation.PushAsync(new NewCategoryPage(context));
       
    }
}