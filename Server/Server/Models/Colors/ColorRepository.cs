﻿using SQLite;
using System.Linq;

namespace Server.Colors
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
            Colorss foundUser = ColorDB.Table<Colorss>().FirstOrDefault(u => u.ColorId == colorId);
            return foundUser;
        }

        public List<Colorss> ReturnAllColors()
        {
            List<Colorss> allColors = ColorDB.Table<Colorss>().ToList();
            return allColors;
        }

    }
}
