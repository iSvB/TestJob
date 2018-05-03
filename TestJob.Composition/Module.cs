using EasyNetQ;
using SimpleInjector;
using TestJob.Cqrs;
using TestJob.Math.Cqrs.Queries.Fibonacci;
using TestJob.Messages;
using TestJob.Messaging;
using TestJob.Messaging.Handlers;

namespace TestJob.Composition
{
    public static class Module
    {
        // Wire all indirect dependencies for solution, except specific for endpoint
        public static void RegisterServices(Container container)
        {
            container.Register<IMessageHandler<NextFibonacciMessage>, NextFibonacciMessageHandler>();
            
            container.Register(() => RabbitHutch.CreateBus(Settings.MessageBrokerSettings.ConnectionString), Lifestyle.Singleton);
            
            container.Register<IQueryHandlerFactory, QueryHandlerFactory>();
            
            container.Register<IQueryDispatcher, QueryDispatcher>();

            container.Register(typeof(IQueryHandler<,>), typeof(CalculateNextFibonacciNumberQueryHandler).Assembly);
        }
    }
}