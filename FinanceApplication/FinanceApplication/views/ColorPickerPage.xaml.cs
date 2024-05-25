using System;
using FinanceApp.classes;
using FinanceApplication.core;
using FinanceApplication.core.Colors;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorPickerPage : ContentPage
    {
        Context context;
        ExtendedCategory category;
        ExtendedWallet wallet;
        int objectForColorise;

        public ColorPickerPage(Context context, ExtendedCategory category)
        {
            objectForColorise = 1;
            this.context = context;
            this.category = category;
            CreateButtons();
        }

        public ColorPickerPage(Context context, ExtendedWallet wallet)
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

            foreach (Colorss color in context.Colors)
            {
                Button newButton = new Button();
                newButton.Text = color.ColorId.ToString();
                newButton.TextColor = Color.Transparent;
                newButton.BackgroundColor = Color.FromHex(color.DarkMode);
                newButton.WidthRequest = 40;
                newButton.HeightRequest = 40;
                newButton.CornerRadius = 20; 

                newButton.HorizontalOptions = LayoutOptions.Center;
                newButton.VerticalOptions = LayoutOptions.Center;

                newButton.Clicked += NewButton_Clicked;

                Grid.SetRow(newButton, row);
                Grid.SetColumn(newButton, column);
                ColorGrid.Children.Add(newButton);

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
            if (sender is Button button){
                if (objectForColorise == 1) ColoriseCategory(button);     
                if (objectForColorise == 2) ColoriseCard(button);     
            }
        }

        private async void ColoriseCategory(Button button)
        {
            category.ColorId = int.Parse(button.Text);
            await Navigation.PushAsync(new NewCategoryPage(context, category));
        }

        private async void ColoriseCard(Button button)
        {
            wallet.ColorId = int.Parse(button.Text);
            wallet.ChangeColors();
            await Navigation.PushAsync(new  NewCardPage(context, wallet));
        }
    }
}