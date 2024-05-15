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

        public Category () { }
        public Category(string name, int userId, int colorId, int iconId)
        {
            Name = name;
            UserId = userId;
            ColorId = colorId;
            IconId = iconId;
        }

        public Category(string name, int userId, int colorId, int iconId, int categoryid): this(name, userId, colorId, iconId)
        {
            Name = name;
            UserId = userId;
            ColorId = colorId;
            IconId = iconId;
            CategoryId = categoryid;
        }


        public override string ToString() => $"{CategoryId} {Name} {UserId} {ColorId}";

        public override bool Equals(object obj) => obj is Category category && category.CategoryId == CategoryId;
        

    }
}
