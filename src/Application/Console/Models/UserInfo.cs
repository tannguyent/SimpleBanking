namespace SimpleBankingApp.Models
{
    public class UserInfo
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public bool IsLogin => !string.IsNullOrEmpty(AccessToken);
    }
}
