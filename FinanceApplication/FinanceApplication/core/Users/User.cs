namespace FinanceApp.classes.Users
{
    public class User
    {
        public int UserId { get; set; }
        public string NickName { get; set; }
        public string Email { get;  set; }
        public string Password { get; set; }
        public int ColorId { get; set; }
        public bool AppModeWhite { get; set; }
        public User(string name, string email, string password, int colorid, bool appMode)
        {
            NickName = name;
            Email = email;
            Password = password;
            ColorId = colorid;
            AppModeWhite = appMode;
        }

        public User () { }

        public override string ToString() => $"{UserId} {NickName} {Email} {Password} {ColorId}";
      
    }
}
