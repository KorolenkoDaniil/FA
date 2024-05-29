using FinanceApp.classes;
using FinanceApplication.core;
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
        ExtendedCategory category;
        Random random = new Random();
        bool delete;
        bool profit;

        public NewCategoryPage(bool profit)
        {
            InitializeComponent();
            ShowImages();
            category = new ExtendedCategory();
            category.UserId = Context.User.UserId;
            category.ColorId = random.Next(0, Context.Colors.Count - 1);
            category.IconId = random.Next(0, Icons.CategoriesIcons.Length - 1);
            CreateSave.Text = "создать";
            Cancel.Text = "отмена";
            delete = false;
            //category.IsProfit = profit;
            this.profit = profit;
            CategoryImage.BackgroundColor = Color.FromHex(Context.Colors.FirstOrDefault(color => color.ColorId == category.ColorId).DarkMode);
            categoryIcon.Source = ImageSource.FromResource(Icons.CategoriesIcons[category.IconId]);
        }

        public NewCategoryPage(ExtendedCategory category)
        {
            InitializeComponent();
            ShowImages();
            this.category = category;
            CategoryImage.BackgroundColor = Color.FromHex(Context.Colors.First(color => color.ColorId == category.ColorId).DarkMode);
            categoryIcon.Source = category.IconSource;
            CreateSave.Text = "Сохранить";
            Cancel.Text = "удалить";
            delete = true;
            EntryCategoryName.Text = category.Name;
        }

        public NewCategoryPage(ExtendedCategory category, bool f)
        {
            InitializeComponent();
            ShowImages();
            this.category = category;
            CategoryImage.BackgroundColor = Color.FromHex(Context.Colors.First(color => color.ColorId == category.ColorId).DarkMode);

            categoryIcon.Source = category.IconSource;

            CreateSave.Text = "Сохранить";
            Cancel.Text = "удалить";
            delete = true;

            if (!string.IsNullOrEmpty(EntryCategoryName.Text))
                EntryCategoryName.Text = category.Name;
        }

        private void EntryCategoryName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EntryCategoryName.Text.Length < 20) category.Name = EntryCategoryName.Text;
        }

        private void ShowImages()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            CathegoryImage.Source = ImageSource.FromResource(Icons.Iconspath[3]);
            IconImage.Source = ImageSource.FromResource(Icons.Iconspath[18]);
            ColorImage.Source = ImageSource.FromResource(Icons.Iconspath[17]);
            xmarkCategoryName.Source = ImageSource.FromResource(Icons.Iconspath[16]);
            xmarkCategoryName.IsVisible = false;
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            if (!delete) await Navigation.PushAsync(new CategoriesPage());
            else
            {
                if (Context.Categories.Count == 1)
                {
                    AlertButton_Clicked();
                    return;
                }

                Cancel.IsEnabled = false;
                CreateSave.IsEnabled = false;
                int index = Context.Categories.FindIndex(cat => cat.CategoryId == category.CategoryId);
                await CategoryRepository.DeleteCategory(Context.Categories[index]);
                Context.Categories.Remove(Context.Categories[index]);
                await Navigation.PushAsync(new CategoriesPage());
            }
            Cancel.IsEnabled = true;
            CreateSave.IsEnabled = true;
        }
        private void EntryCategoryName_focused(object sender, FocusEventArgs e) => xmarkCategoryName.IsVisible = false;
        private void EntryCategoryName_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(EntryCategoryName.Text))
            {
                xmarkCategoryName.IsVisible = true;
                return;
            }
            xmarkCategoryName.IsVisible = EntryCategoryName.Text.Length > 20;
        }


        private async void Create_Clicked(object sender, EventArgs e)
        {
            ValidationBeforeSaving();

            Device.StartTimer(TimeSpan.FromSeconds(4), () =>
            {
                CreateSave.IsEnabled = false;
                Cancel.IsEnabled = false;
                ColorPicker.IsEnabled = false;
                ImagePicker.IsEnabled = false;
                return false;
            });

            Category isSend = await CategoryRepository.SaveCategory(new Category(EntryCategoryName.Text, Context.User.UserId, category.ColorId, category.IconId, category.CategoryId, profit));
            Resave(isSend);
            await Navigation.PushAsync(new CategoriesPage());
        }

        private void ValidationBeforeSaving()
        {
            if (!Validator.ValidateString(EntryCategoryName.Text, 20)) return;
        }





        public void Resave(Category category)
        {
            int index = Context.Categories.IndexOf(category);
            if (index != -1)
            {
                Context.Categories[index] = category;
                return;
            }
            Context.Categories.Add(category);
        }


        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IconPickerPage(category));
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e) => await Navigation.PushAsync(new ColorPickerPage(category));

        private async void AlertButton_Clicked()
        {
            await DisplayAlert("Последняя категория", "категория не может быть удалена,\nтк она последняя", "ОK");
            await Navigation.PushAsync(new CategoriesPage());
        }

    }
}