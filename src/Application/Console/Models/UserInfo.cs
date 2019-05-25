namespace SimpleBankingApp.Models
{
    public class UserInfo
    {
        public string AccessToken { get; set; }

        public bool IsLogin => !string.IsNullOrEmpty(AccessToken);
    }
}
