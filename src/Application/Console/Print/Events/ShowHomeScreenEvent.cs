
namespace SimpleBankingApp.Print.Events
{
    public class ShowHomeScreenEvent
    {
        public ShowHomeScreenEvent(bool isLogin = false)
        {
            IsLogin = isLogin;
        }

        public bool IsLogin { get; }
    }
}


