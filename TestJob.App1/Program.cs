using System;
using System.Linq;
using System.Threading.Tasks;
using SimpleInjector;
using TestJob.Messages;
using TestJob.Messaging;
using TestJob.Messaging.Handlers;
using TestJob.Settings;

namespace TestJob.App1
{
    class Program
    {
        static void Main(string[] args)
        {
            int threads = int.Parse(args.First());
            
            var container = new Container();
            Startup.RegisterServices(container);
            container.Verify();
            
            var subscribeMessageBroker = container.GetInstance<ISubscribeMessageBroker>();

            for (int i = 0; i < threads; ++i)
            {
                Task.Factory.StartNew(() =>
                {
                    var messageHandler = container.GetInstance<NextFibonacciMessageHandler>();
                    subscribeMessageBroker.Subscribe(MessageBrokerSettings.FibonacciSubscriptionId, messageHandler);

                    messageHandler.Handle(new NextFibonacciMessage {Value = "1"});
                });
            }            
                        
            Console.ReadLine();
        }
    }
}
