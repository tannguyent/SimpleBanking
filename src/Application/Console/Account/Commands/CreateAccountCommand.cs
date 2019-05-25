
using SimpleBankingApp.Models;

namespace SimpleBankingApp.Account.Commands
{
    public class CreateAccountCommand
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public CreateAccountCommand(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }
    }
}
