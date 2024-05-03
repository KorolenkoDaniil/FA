using SQLite;

namespace Server.Models.Categories1
{
    public class CategoryRepository
    {
        string pathToCategoriesDB;
        SQLiteConnection CategoriesDB;

        public CategoryRepository()
        {
            pathToCategoriesDB = "D://FinAppDataBases//Users.db";
            CategoriesDB = new SQLiteConnection(pathToCategoriesDB);
            CategoriesDB.CreateTable<Category>();
        }

        public Category SaveCategory(Category category)
        {
            var existingCategory = CategoriesDB.Table<Category>().FirstOrDefault(cat => cat.CategoryId == category.CategoryId);

            if (existingCategory != null)
                CategoriesDB.Update(category);
            else
                CategoriesDB.Insert(category);
            
            return CategoriesDB.Table<Category>().FirstOrDefault(cat => cat.CategoryId == category.CategoryId);
        }



        public List<Category> SearchByUserID(int userId)
        {
            List<Category> UserscategoryList = CategoriesDB.Table<Category>().Where(u => u.UserId == userId).ToList();
            Console.WriteLine("-----категории");
            foreach (var category in UserscategoryList)
            {
                Console.WriteLine(category);
            }
            Console.WriteLine("-----категории");

            return UserscategoryList;
        }
    }
}
