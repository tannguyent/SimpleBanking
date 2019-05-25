namespace SimpleBankingApp.Account.Commands
{
    public class LoginCommand
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public LoginCommand(string  userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
