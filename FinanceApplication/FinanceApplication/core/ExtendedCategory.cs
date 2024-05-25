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
        public decimal CategorySum { get; set; }
        public int IconId { get; set; }
        public bool IsProfit { get; set; }
        public ImageSource IconSource { get; set; }

        public ExtendedCategory() { }
        public ExtendedCategory( string name, string darkMode, int iconId, int categoryId, int userId, int colorId, bool isProfit)
        {
            Name = name;
            DarkMode = darkMode;
            IconId = iconId;
            IconSource = ImageSource.FromResource(Icons.CategoriesIcons[IconId]);
            CategoryId = categoryId;
            UserId = userId;
            ColorId = colorId;
            IsProfit = isProfit;
        }

        public override string ToString()
        {
            return $"Name {Name} DarkMode {DarkMode}s CategorySum {CategorySum} IconId {IconId} IconSource {IconSource}";
        }
    }
}
