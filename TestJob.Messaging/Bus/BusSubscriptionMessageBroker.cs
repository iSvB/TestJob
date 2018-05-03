using System.Threading.Tasks;
using EasyNetQ;
using IMessage = TestJob.Messages.IMessage;

namespace TestJob.Messaging.Bus
{
    public sealed class BusSubscriptionMessageBroker : ISubscribeMessageBroker
    {
        private readonly IBus _bus;

        public BusSubscriptionMessageBroker(IBus bus)
        {
            _bus = bus;
        }

        public void Subscribe<T>(string subscriptionId, IMessageHandler<T> messageHandler) where T : class, IMessage
        {
            _bus.Subscribe(subscriptionId, (T msg) => Task.Factory.StartNew(() => messageHandler.Handle(msg)));
        }
    }
}