using System;
using FinanceApp.classes;
using FinanceApplication.core.Category;
using FinanceApplication.core.Colors;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorPickerPage : ContentPage
    {
        Context context;
        Category category;
        int objectForColorise;

        public ColorPickerPage(Context context, Category category)
        {
            objectForColorise = 1;
            this.context = context;
            this.category = category;
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
                newButton.TextColor = Color.FromHex(color.LightMode);
                newButton.BackgroundColor = Color.FromHex(color.LightMode);
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
            Console.WriteLine("кнопка проверяется_-------------------------------");
            if (sender is Button button){
                if (objectForColorise == 1) ColoriseCategory(button);     
            }
        }

        private async void ColoriseCategory(Button button)
        {
            category.ColorId = int.Parse(button.Text);
            await Navigation.PushAsync(new NewCategoryPage(context, category));
        }
    }
}