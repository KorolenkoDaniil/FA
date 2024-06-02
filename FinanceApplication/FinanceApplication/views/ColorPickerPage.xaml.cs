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
        ExtendedCategory category;
        ExtendedWallet wallet;

        public ColorPickerPage(ExtendedCategory category)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            back.BackgroundColor = Color.FromHex(Context.User.AppModeColor);
            this.category = category;
            CreateCategoryButtons();
        }

        public ColorPickerPage(ExtendedWallet wallet)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            back.BackgroundColor = Color.FromHex(Context.User.AppModeColor);
            this.wallet = wallet;
            CreateCardButtons();
        }

        public void CreateCategoryButtons()
        {
            int column = 0, row = 0;

            foreach (Colorss color in Context.Colors)
            {
                Button newButton = new Button
                {
                    Text = color.ColorId.ToString(),
                    TextColor = Color.Transparent,
                    BackgroundColor = Color.FromHex(color.DarkMode),
                    WidthRequest = 40,
                    HeightRequest = 40,
                    CornerRadius = 20,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                newButton.Clicked += ColoriseCategory;

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

        public void CreateCardButtons()
        {
            int column = 0, row = 0;

            foreach (Colorss color in Context.Colors)
            {
                Button newButton = new Button
                {
                    Text = color.ColorId.ToString(),
                    TextColor = Color.Transparent,
                    BackgroundColor = Color.FromHex(color.DarkMode),
                    WidthRequest = 40,
                    HeightRequest = 40,
                    CornerRadius = 20,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                newButton.Clicked += ColoriseCard;

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

        private async void ColoriseCategory(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                category.ColorId = int.Parse(button.Text);
                await Navigation.PushAsync(new NewCategoryPage(category));
            }
        }

        private async void ColoriseCard(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                wallet.ColorId = int.Parse(button.Text);
                wallet.ChangeColors();
                await Navigation.PushAsync(new NewCardPage(wallet));
            }
        }
    }
}
