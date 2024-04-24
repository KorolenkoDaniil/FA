using Server.Operations;
using SQLite;

namespace Server.Wallets
{
    public class WalletRepository
    {
        string pathToUserDB;
        SQLiteConnection WalletDB;

        public WalletRepository()
        {
            pathToUserDB = "D://FinAppDataBases//Users.db";
            WalletDB = new SQLiteConnection(pathToUserDB);
            WalletDB.CreateTable<Wallet>();
        }

        public Wallet Savewallet(Wallet wallet)
        {
            if (WalletDB.Insert(wallet) != 0)
                return wallet;
            else
                return null;  
        }


        public List<Wallet> SearchByUserID(int userId)
        {
            List<Wallet> UsersWalletList = WalletDB.Table<Wallet>().Where(u => u.UserId == userId).ToList();
            Console.WriteLine("-----кошельки");
            foreach (var a in UsersWalletList)
                Console.WriteLine(a);
            Console.WriteLine("-----кошельки");

            return UsersWalletList;
        }

    }

}
