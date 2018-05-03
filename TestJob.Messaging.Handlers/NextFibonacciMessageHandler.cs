using System;
using TestJob.Cqrs;
using TestJob.Math.Cqrs.Queries.Fibonacci;
using TestJob.Messages;

namespace TestJob.Messaging.Handlers
{
    public sealed class NextFibonacciMessageHandler : IMessageHandler<NextFibonacciMessage>
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly IPublishMessageBroker _publishMessageBroker;

        public NextFibonacciMessageHandler(
            IQueryDispatcher queryDispatcher,
            IPublishMessageBroker publishMessageBroker)
        {
            _queryDispatcher = queryDispatcher;
            _publishMessageBroker = publishMessageBroker;
        }
        
        public void Handle(NextFibonacciMessage message)
        {
            // Replace with normal logging
            Console.WriteLine(message.Value);
            
            var queryDefinition = new CalculateNextFibonacciNumberQueryDefinition {CurrentValue = message.Value};
            var queryResult = _queryDispatcher
                    .Dispatch<CalculateNextFibonacciNumberQueryDefinition, CalculateNextFibonacciNumberQueryResult>(
                        queryDefinition);

            var messageToSend = new NextFibonacciMessage {Value = queryResult.NextValue};
            _publishMessageBroker.Publish(messageToSend);
        }
    }
}