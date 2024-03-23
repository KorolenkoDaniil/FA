using SQLite;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.classes.Wallets
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

        public bool Savewallet(Wallet wallet)
        {
            if (WalletDB.Insert(wallet) != 0) return true;
            else return false;
        }


        public List<Wallet> SearchByUserID(int userId)
        {
            List<Wallet> UsersWalletList = WalletDB.Table<Wallet>().Where(u => u.UserId == userId).ToList();
            return UsersWalletList;
        }

    }

}
