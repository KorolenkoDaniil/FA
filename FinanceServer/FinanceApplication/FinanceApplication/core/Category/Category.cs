namespace FinanceApplication.core.Category
{
    public class Category
    {
        public int CategoryId { get; set; }    
        public string Name { get; private set; }    
        public int UserId { get; private set; }    
        public int ColorId { get; private set; }

        public Category(string name, int userId, int colorId)
        {
            Name = name;
            UserId = userId;
            ColorId = colorId;
        }

        public override string ToString() => $"{CategoryId} {Name} {UserId} {ColorId}";

    }
}
