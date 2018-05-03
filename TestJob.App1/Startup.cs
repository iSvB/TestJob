using SimpleInjector;
using TestJob.Messaging;
using TestJob.Messaging.Bus;
using TestJob.Messaging.Http;

namespace TestJob.App1
{
    public static class Startup
    {
        public static void RegisterServices(Container container)
        {
            TestJob.Composition.Module.RegisterServices(container);            
            
            // Register specific for this endpoint services here
            container.Register<IPublishMessageBroker, HttpPublishMessageBroker>();
            container.Register<ISubscribeMessageBroker, BusSubscriptionMessageBroker>();
        }
    }
}