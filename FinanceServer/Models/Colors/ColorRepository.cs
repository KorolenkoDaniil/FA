using FinanceApp.classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinanceApplication.core.Colors
{
    public class ColorRepository
    {
        string pathToColorDB;
        SQLiteConnection ColorDB;

        public ColorRepository()
        {
            pathToColorDB = "D://FinAppDataBases//Users.db";
            ColorDB = new SQLiteConnection(pathToColorDB);
            ColorDB.CreateTable<Colorss>();
        }


        public Colorss SearchById(int colorId)
        {
            Console.WriteLine(colorId.ToString() + "  цвет");
            Colorss foundUser = ColorDB.Table<Colorss>().FirstOrDefault(u => u.ColorId == colorId);
            return foundUser;
        }
    }
}
