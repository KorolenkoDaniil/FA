using SQLite;

namespace Server.Colors
{
    [Table("Colors")]
    public class Colorss
    {
        public int ColorId { get; set; }
        public string Name { get; set; }
        public string DarkMode { get; set; }
        public string LightMode { get; set; }
        public string DarkText { get; set; }
        public string LightText { get; set; }
            
        public Colorss() { }

        public Colorss(int colorId, string name, string darkMode, string lightMode, string darkText, string lightText)
        {
            ColorId = colorId;
            Name = name;
            DarkMode = darkMode;
            LightMode = lightMode;
            DarkText = darkText;
            LightText = lightText;
        }

        public override string ToString() => $"{ColorId} {Name} {DarkMode} {LightMode} {DarkText} {LightText}";
    }
}
