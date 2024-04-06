namespace FinanceApplication.core.Category
{
    public class Category
    {
        public int CategoryId { get; set; }    
        public string Name { get; set; }    
        public int UserId { get; set; }    
        public int ColorId { get; set; }

        public Category () { }
        public Category(string name, int userId, int colorId)
        {
            Name = name;
            UserId = userId;
            ColorId = colorId;
        }

        public override string ToString() => $"{CategoryId} {Name} {UserId} {ColorId}";

    }
}
