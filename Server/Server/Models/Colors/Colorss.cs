using SQLite;

namespace Server.Colors
{
    [Table("Colors")]
    public class Colorss
    {
        public int ColorId { get; set; }
        public string Name { get; set; }
        public string DarkMode { get; set; }

        public Colorss() { }

        public Colorss(int colorId, string name, string darkMode)
        {
            ColorId = colorId;
            Name = name;
            DarkMode = darkMode;
        }

        public override string ToString() => $"{ColorId} {Name} {DarkMode}";
    }
}
