using FinanceApplication.icons;
using Xamarin.Forms;

namespace FinanceApplication.core
{
    public class ExtendedCategory
    {
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public int ColorId { get; set; }
        public string Name { get; set; }
        public string DarkMode { get; set; }
        public string LightMode { get; set; }
        public decimal CategorySum { get; set; }
        public int IconId { get; set; }
        public ImageSource IconSource { get; set; }

        public ExtendedCategory() { }
        public ExtendedCategory( string name, string darkMode, string lightMode, int iconId, int categoryId, int userId, int colorId)
        {
            Name = name;
            DarkMode = darkMode;
            LightMode = lightMode;
            IconId = iconId;
            IconSource = ImageSource.FromResource(Icons.CategoriesIcons[IconId]);
            CategoryId = categoryId;
            UserId = userId;
            ColorId = colorId;
        }

        public override string ToString()
        {
            return $"Name {Name} DarkMode {DarkMode} LightMode {LightMode} CategorySum {CategorySum} IconId {IconId} IconSource {IconSource}";
        }
    }
}
