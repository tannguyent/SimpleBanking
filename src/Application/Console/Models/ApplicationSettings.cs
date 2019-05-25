namespace SimpleBankingApp.Models
{
    public class ApplicationSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public Configuration Configuration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Identity Identity { get; set; }
    }

    public class Configuration
    {
        /// <summary>
        /// Sets header title in console window
        /// </summary>
        public string ConsoleTitle { get; set; }
    }

    public class Identity
    {
        public string IdentityServer { get; set; }
        public string ClientId { get; set; }
        public string Scope { get; set; }
    }
}
