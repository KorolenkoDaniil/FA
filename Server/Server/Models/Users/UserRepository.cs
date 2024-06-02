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

        public User SaveUser(User user)
        {
            Console.WriteLine("!!!" + user);
            var existingUser = UserDB.Table<User>().FirstOrDefault(w => w.UserId == user.UserId);
            if (existingUser != null)
                UserDB.Update(user);
            else
                UserDB.Insert(user);
            return UserDB.Table<User>().FirstOrDefault(w => w.UserId == user.UserId);
        }


        public User SearchByEmailAndPassword(string email, string password)
        {
            User foundUser = UserDB.Table<User>().FirstOrDefault(u => u.Email == email && u.Password == password);
            return foundUser;
        }

    }
}

