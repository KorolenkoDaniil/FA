using SQLite;

namespace FinanceApp.classes.Users
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

        public User() { }
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
