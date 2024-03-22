namespace FinanceApp.classes.Users
{
    public class User
    {
        public int UserId { get; set; }
        public string NickName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public int ColorId { get; private set; }
        public User(string name, string email, string password, int colorid)
        {
            NickName = name;
            Email = email;
            Password = password;
            ColorId = colorid;
        }

        public override string ToString() => $"{UserId} {NickName} {Email} {Password} {ColorId}";
      
    }
}
