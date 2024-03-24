namespace FinanceApplication.core.Colors
{
    public class Colorss
    {
        public int ColorId { get; private set; }
        public string Name { get; private set; }
        public string DarkMode { get; private set; }
        public string LightMode { get; private set; }
        public string DarkText { get; private set; }
        public string LightText { get; private set; }
        
        public Colorss () { }
        public Colorss(string name, string darkMode, string lightMode, string darkText, string lightText)
        {
            Name = name;
            DarkMode = darkMode;
            LightMode = lightMode;
            DarkText = darkText;
            LightText = lightText;
        }

        public override string ToString() => $"{ColorId} {Name} {DarkMode} {LightMode} {DarkText} {LightText}";
    }
}
