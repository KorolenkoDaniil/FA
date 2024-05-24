using FinanceApplication.core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FinanceApplication.icons;
using System;
using FinanceApp.classes;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IconPickerPage : ContentPage
    {
       
        Context context;
        ExtendedCategory category;
        ExtendedWallet wallet;
        int objectForColorise;

        public IconPickerPage(Context context, ExtendedCategory category)
        {
            objectForColorise = 1;
            this.context = context;
            this.category = category;
            CreateButtons();
        }

        public IconPickerPage(Context context, ExtendedWallet wallet)
        {
            objectForColorise = 2;
            this.context = context;
            this.wallet = wallet;
            CreateButtons();
        }

        public void CreateButtons()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            int column = 0, row = 0;
            for (int i = 0; i < Icons.CategoriesIcons.Length; i++) 
            {
                ImageButton newButton = new ImageButton();
                newButton.Source = ImageSource.FromResource(Icons.CategoriesIcons[i]);
                newButton.WidthRequest = 55;
                newButton.HeightRequest = 55;
                newButton.Padding = 10;
                newButton.CornerRadius = 55;
                newButton.HorizontalOptions = LayoutOptions.Center;
                newButton.VerticalOptions = LayoutOptions.Center;
                newButton.BackgroundColor = Color.Transparent;
                newButton.BorderWidth = 1;
                newButton.BorderColor = Color.Black;
                newButton.Clicked += NewButton_Clicked;
                Grid.SetRow(newButton, row);
                Grid.SetColumn(newButton, column);
                IconsGrid.Children.Add(newButton);

                column++;

                if (column == 4)
                {
                    column = 0;
                    row++;
                }
            }
        }
        private void NewButton_Clicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button)
            {
                if (objectForColorise == 1) ColoriseCategory(button);
                if (objectForColorise == 2) ColoriseCard(button);
            }
        }

        private async void ColoriseCategory(ImageButton button)
        {
            category.IconSource = button.Source;
            await Navigation.PushAsync(new NewCategoryPage(context, category));
        }

        private async void ColoriseCard(ImageButton button)
        {
            wallet.WalletIconPath = button.Source;
            Console.WriteLine("карта после изменения иконки");
            Console.WriteLine(wallet);
            await Navigation.PushAsync(new NewCardPage(context, wallet));
        }
    }
}