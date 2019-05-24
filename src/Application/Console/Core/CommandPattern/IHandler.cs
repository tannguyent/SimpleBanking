namespace SimpleBankingApp.Core.CommandPattern
{
    public interface IHandler<T> 
    {
        void Handle(T command);
    }
}
