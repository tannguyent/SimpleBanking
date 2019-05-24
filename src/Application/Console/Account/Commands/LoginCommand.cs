using SimpleBankingApp.Core.CommandPattern;

namespace SimpleBankingApp.Account.Commands
{
    public class LoginCommand : ICommand
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
