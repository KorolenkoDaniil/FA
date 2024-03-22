using FinanceApplication.core.Operations;
using SQLite;

namespace FinanceApplication.core.Category
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

        public bool SaveCategory(Category category)
        {
            if (CategoriesDB.Insert(category) != 0) return true;
            else return false;
        }


        public List<Category> SearchByUserID(int userId)
        {
            List<Category> UsersOperationsList = CategoriesDB.Table<Category>().Where(u => u.UserId == userId).ToList();
            return UsersOperationsList;
        }
    }
}
