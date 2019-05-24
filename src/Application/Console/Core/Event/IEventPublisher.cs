using SimpleBankingApp.Core.Event.Internal;

namespace SimpleBankingApp.Core.Event
{
    public interface IEventPublisher
    {
        void Queue(IEvent @event);

        void Broadcast();

        void Discard();
    }
}
