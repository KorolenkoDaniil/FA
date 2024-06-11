using FinanceApplication.icons;
using Xamarin.Forms;
namespace FinanceApplication.core.Category
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int ColorId { get; set; }
        public int IconId { get; set; }
        public bool IsProfit { get; set; }
        public Category() { }
        public Category(string name, int userId, int colorId, int iconId, bool isProfit)
        {
            Name = name;
            UserId = userId;
            ColorId = colorId;
            IconId = iconId;
            IsProfit = isProfit;
        }
        public Category(string name, int userId, int colorId, int iconId, int categoryid, bool isProfit) : this(name, userId, colorId, iconId, isProfit)
        {
            CategoryId = categoryid;
        }
        public override string ToString() => $"{CategoryId} {Name} {UserId} {ColorId} IsProfit {IsProfit}";
        public override bool Equals(object obj) => obj is Category category && category.CategoryId == CategoryId;
    }
}
