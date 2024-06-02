using Server.Wallets;
using SQLite;

namespace Server.Users
{
    [Table("Users")]
    public class User
    {
        [AutoIncrement, PrimaryKey]
        public int UserId { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ColorId { get; set; }
        public string AppModeColor { get; set; }
        public string SelectedCurrency { get; set; }
        public User() { }
        public User(string name, string email, string password, int colorid, string appModeColor, string selectedCurrency)
        {
            NickName = name;
            Email = email;
            Password = password;
            ColorId = colorid;
            AppModeColor = appModeColor;
            SelectedCurrency = selectedCurrency;
        }

        public override string ToString() => $"{UserId} {NickName} {Email} {Password} {ColorId} SelectedCurrency {SelectedCurrency}";


        public override bool Equals(object obj) => obj is User user && user.UserId == UserId;
    }
}
