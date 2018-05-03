using TestJob.Messages;

namespace TestJob.Messaging
{
    public interface IMessageHandler<in T> where T : IMessage
    {
        void Handle(T message);
    }
}