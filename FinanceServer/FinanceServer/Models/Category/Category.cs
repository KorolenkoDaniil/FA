﻿using SQLite;

namespace FinanceApplication.core.Category
{
    [Table("Categories")]
    public class Category
    {
        public int CategoryId { get; set; }    
        public string Name { get; set; }    
        public int UserId { get; set; }    
        public int ColorId { get; set; }

        public Category(int categoryId, string name, int userId, int colorId)
        {
            CategoryId = categoryId;
            Name = name;
            UserId = userId;
            ColorId = colorId;
        }
        public Category() { }

        public override string ToString() => $"{CategoryId} {Name} {UserId} {ColorId}";

    }
}
