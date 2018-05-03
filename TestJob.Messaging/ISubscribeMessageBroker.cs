using TestJob.Messages;

namespace TestJob.Messaging
{
    public interface ISubscribeMessageBroker
    {
        void Subscribe<T>(string subscriptionId, IMessageHandler<T> messageHandler) where T : class, IMessage;
    }
}