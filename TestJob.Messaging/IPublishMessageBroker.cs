using System;
using TestJob.Messages;

namespace TestJob.Messaging
{
    public interface IPublishMessageBroker
    {
        void Publish<T>(T message) where T : class, IMessage;
    }
}