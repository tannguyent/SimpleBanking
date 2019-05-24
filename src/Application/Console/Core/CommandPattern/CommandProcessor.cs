using System;
using System.Reflection;

namespace SimpleBankingApp.Core.CommandPattern
{
    public class CommandProcessor : ICommandProcessor
    {
        public CommandProcessor()
        {
        }

        public void Excute<TCommand>(TCommand command)
        {
            Type handlerType = typeof(IHandler<>).MakeGenericType(command.GetType());
            var handlers = ServiceLocator.Current.GetAllInstances(handlerType);
            MethodInfo handleMethod = handlerType.GetMethod("Handle");
            foreach (var handler in handlers)
            {
                handleMethod.Invoke(handler, new object[] { command });
            }
        }
    }
}
