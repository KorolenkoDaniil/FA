using FinanceApp.classes;
using FinanceApp.classes.Wallets;
using FinanceApplication.core;
using FinanceApplication.core.Category;
using FinanceApplication.icons;
using Org.Apache.Http.Cookies;
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
        ExtendedCategory category;
        Random random = new Random();
        bool delete;

        public NewCategoryPage(Context context)
        {
            InitializeComponent();
            ShowImages();
            this.context = context;
            category = new ExtendedCategory();
            category.UserId = context.User.UserId;
            category.ColorId = random.Next(0, context.Colors.Count - 1);
            CreateSave.Text = "создать";
            Cancel.Text = "отмена";
            delete = false;

            CategoryImage.BackgroundColor = Color.FromHex(context.Colors.FirstOrDefault(color => color.ColorId == category.ColorId).LightMode);
        }

        public NewCategoryPage(Context context, ExtendedCategory category)
        {
            InitializeComponent();
            ShowImages();
            this.context = context;
            this.category = category;
            CategoryImage.BackgroundColor = Color.FromHex(context.Colors.First(color => color.ColorId == category.ColorId).LightMode);
            CreateSave.Text = "Сохранить";
            Cancel.Text = "удалить";
            delete = true;
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

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            if (!delete) await Navigation.PushAsync(new CardPage(context));
            else
            {
                if (context.Categories.Count == 1)
                {
                    AlertButton_Clicked();
                    return;
                }

                Cancel.IsEnabled = false;
                CreateSave.IsEnabled = false;
                int index = context.Categories.FindIndex(cat => cat.CategoryId == category.CategoryId);
                await CategoryRepository.DeleteCategory(context.Categories[index]);
                context.Categories.Remove(context.Categories[index]);
                await Navigation.PushAsync(new CategoriesPage(context));
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

            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                //дописать блокировку кнопок
                return false;
            });

            Category isSend = await CategoryRepository.SaveCategory(new Category(EntryCategoryName.Text, context.User.UserId, category.ColorId, category.IconId, category.CategoryId));
            Resave(isSend);
            await Navigation.PushAsync(new CategoriesPage(context));
        }

        private void ValidationBeforeSaving()
        {
            if (!Validator.ValidateString(EntryCategoryName.Text, 20)) return;
        }





        public void Resave(Category category)
        {
            int index = context.Categories.IndexOf(category);
            if (index != -1)
            {
                context.Categories[index] = category;
                return;
            }
            context.Categories.Add(category);
        }


        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e) => await Navigation.PushAsync(new ColorPickerPage(context, category));

        private async void AlertButton_Clicked()
        {
            await DisplayAlert("Последняя категория", "категория не может быть удалена,\nтк она последняя", "ОK");
            await Navigation.PushAsync(new CardPage(context));
        }

    }
}