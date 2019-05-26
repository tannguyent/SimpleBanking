using System;

namespace SimpleBankingApp.Models
{
    public class UserInfo
    {
        public Guid UserId { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
        
        public Guid DebitAccountId { get; set; }

        public bool IsLogin => !string.IsNullOrEmpty(AccessToken);
    }
}
