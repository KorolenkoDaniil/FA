namespace FinanceApplication.core.Colors
{
    public class Colorss
    {
        public int ColorId { get; set; }
        public string Name { get; set; }
        public string DarkMode { get; set; }
       
        public Colorss () { }
        public Colorss(string name, string darkMode)
        {
            Name = name;
            DarkMode = darkMode;
        }

        public override string ToString() => $"ColorId {ColorId} Name {Name} DarkMode {DarkMode}";
    }
}
