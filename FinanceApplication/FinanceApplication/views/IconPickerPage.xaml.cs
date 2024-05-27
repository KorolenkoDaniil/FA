using FinanceApplication.core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FinanceApplication.icons;
using System;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IconPickerPage : ContentPage
    {
        ExtendedCategory category;
        ExtendedWallet wallet;

        public IconPickerPage(ExtendedCategory category)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            this.category = category;
            CreateCategoryButtons();
        }

        public IconPickerPage(ExtendedWallet wallet)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            this.wallet = wallet;
            CreateCardButtons();
        }

        public void CreateCategoryButtons()
        {
            int column = 0, row = 0;

            for (int i = 0; i < Icons.CategoriesIcons.Length; i++)
            {
                ImageButton newButton = new ImageButton
                {
                    Source = ImageSource.FromResource(Icons.CategoriesIcons[i]),
                    WidthRequest = 55,
                    HeightRequest = 55,
                    Padding = 10,
                    CornerRadius = 55,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    BackgroundColor = Color.Transparent,
                    BorderWidth = 1,
                    BorderColor = Color.Black
                };

                newButton.Clicked += ColoriseCategory;

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

        public void CreateCardButtons()
        {
            int column = 0, row = 0;

            for (int i = 0; i < Icons.WalletsIcons.Length; i++)
            {
                ExtendedImageButton newButton = new ExtendedImageButton
                {
                    Source = ImageSource.FromResource(Icons.WalletsIcons[i]),
                    WidthRequest = 55,
                    HeightRequest = 55,
                    Padding = 10,
                    CornerRadius = 55,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    BackgroundColor = Color.Transparent,
                    BorderWidth = 1,
                    BorderColor = Color.Black,
                    id = i 
                };

                newButton.Clicked += ChangeCardIcon;

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

        private async void ColoriseCategory(object sender, EventArgs e)
        {
            if (sender is ExtendedImageButton button)
            {
                category.IconSource = button.Source;
                category.IconId = button.id;
                await Navigation.PushAsync(new NewCategoryPage(category));
            }
        }

        private async void ChangeCardIcon(object sender, EventArgs e)
        {
            if (sender is ExtendedImageButton button)
            {
                wallet.WalletIconPath = button.Source;
                wallet.IconId = button.id;
                await Navigation.PushAsync(new NewCardPage(wallet));
            }
        }
    }
}
