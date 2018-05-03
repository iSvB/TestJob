using EasyNetQ;
using IMessage = TestJob.Messages.IMessage;

namespace TestJob.Messaging.Bus
{
    public sealed class BusPublishMessageBroker : IPublishMessageBroker
    {
        private readonly IBus _bus;

        public BusPublishMessageBroker(IBus bus)
        {
            _bus = bus;
        }
        
        public void Publish<T>(T message) where T : class, IMessage
        {
            _bus.Publish(message);
        }
    }
}