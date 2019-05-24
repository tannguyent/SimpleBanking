namespace SimpleBankingApp.Core.CommandPattern
{
    public interface ICommandProcessor
    {
        void Excute<TCommand>(TCommand command);
    }
}
