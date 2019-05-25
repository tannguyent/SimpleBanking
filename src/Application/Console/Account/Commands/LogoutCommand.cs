using SimpleBankingApp.Models;

namespace SimpleBankingApp.Account.Commands
{
    public class LogoutCommand 
    {
        public string AccessToken { get; set; }

        public LogoutCommand(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
