namespace SimpleBankingApp.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationContext
    {
        public UserInfo UserInfo { get; set; }

        public ApplicationContext()
        {
            UserInfo = new UserInfo();
        }
    }
}
