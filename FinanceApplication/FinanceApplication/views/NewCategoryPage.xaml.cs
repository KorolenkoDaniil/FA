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
    public partial class NewCategoryPage : ContentPage
    {
        Context context;
        Category category;
        //Image selectedImage;
        Random random = new Random();

        public NewCategoryPage(Context context)
        {
            InitializeComponent();
            ShowImages();
            this.context = context;
            category = new Category();
            category.UserId = context.User.UserId;
            category.ColorId = random.Next(0, context.Colors.Count - 1);
            CreateSave.Text = "создать";
            CategoryImage.BackgroundColor = Color.FromHex(context.Colors.FirstOrDefault(color => color.ColorId == category.ColorId).LightMode);
        }

        public NewCategoryPage(Context context, Category category)
        {
            InitializeComponent();
            ShowImages();
            this.context = context;
            this.category = category;
            CategoryImage.BackgroundColor = Color.FromHex(context.Colors.First(color => color.ColorId == category.ColorId).LightMode);
            CreateSave.Text = "Сохранить";
            EntryCategoryName.Text = category.Name;
        }


        private void EntryCategoryName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EntryCategoryName.Text.Length < 20) category.Name = EntryCategoryName.Text;
        }

        private void ShowImages()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            CathegoryImage.Source = ImageSource.FromResource(Icons.Iconspath[11]);
            IconImage.Source = ImageSource.FromResource(Icons.Iconspath[2]);
            ColorImage.Source = ImageSource.FromResource(Icons.Iconspath[3]);
            xmarkCategoryName.Source = ImageSource.FromResource(Icons.Iconspath[16]);
            xmarkCategoryName.IsVisible = false;
        }

        private async void Cancel_Clicked(object sender, EventArgs e) =>
            await Navigation.PushAsync(new CategoriesPage(context));
        private void EntryCategoryName_focused(object sender, FocusEventArgs e) => xmarkCategoryName.IsVisible = false;
        private void EntryCategoryName_Unfocused(object sender, FocusEventArgs e) => xmarkCategoryName.IsVisible = EntryCategoryName.Text.Length > 20;
        private async void Create_Clicked(object sender, EventArgs e)
        {
            if (!Validator.ValidateString(EntryCategoryName.Text, 20)) return;
            category = await CategoryRepository.SaveCategory(category);
            context.Categories.Add(category);
            await Navigation.PushAsync(new CategoriesPage(context));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e) => await Navigation.PushAsync(new ColorPickerPage(context, category));
    }
}