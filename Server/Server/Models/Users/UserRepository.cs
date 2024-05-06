using SQLite;

namespace Server.Users
{
    public class UserRepository
    {
        string pathToUserDB;
        SQLiteConnection UserDB;

        public UserRepository()
        {
            pathToUserDB = "D://FinAppDataBases//Users.db";
            UserDB = new SQLiteConnection(pathToUserDB);
            UserDB.CreateTable<User>();
        }

        public int SaveUser(User user)
        {

            User foundUser = UserDB.Table<User>().FirstOrDefault(u => u.Email == user.Email);
            if (foundUser == null)
                UserDB.Insert(user);
            return UserDB.Table<User>().FirstOrDefault(u => u.Email == user.Email).UserId;
        }

        public User SearchByEmailAndPassword(string email, string password)
        {
            User foundUser = UserDB.Table<User>().FirstOrDefault(u => u.Email == email && u.Password == password);
            return foundUser;
        }

    }
}

