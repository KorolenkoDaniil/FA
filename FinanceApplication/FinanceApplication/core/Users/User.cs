namespace FinanceApp.classes.Users
{
    public class User
    {
        public int UserId { get; set; }
        public string NickName { get; set; }
        public string Email { get;  set; }
        public string Password { get; set; }
        public int ColorId { get; set; }
        public string AppModeColor { get; set; }
        public string SelectedCurrency { get; set; }
        public User(string name, string email, string password, int colorid, string appModeColor, string selectedCurrency)
        {
            NickName = name;
            Email = email;
            Password = password;
            ColorId = colorid;
            AppModeColor = appModeColor;
            SelectedCurrency = selectedCurrency;
        }

        public User () { }

        public override string ToString() => $"{UserId} {NickName} {Email} {Password} {ColorId} selectedCurrency {SelectedCurrency}";
      
    }
}
