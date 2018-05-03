using System;
using TestJob.Messages;

namespace TestJob.Settings
{
    // Make it static and hardcode values in sake of simplicity
    public static class MessageBrokerSettings
    {
        public static string ConnectionString => "host=localhost";

        public static string FibonacciSubscriptionId = "fibonacciSequenceSubscriptionId";

        // Maybe it worth to replace it with visitor to map message to corresponding uri using polymorphism
        // But maybe not, so i left it as is
        public static string GetUri<T>() where T : IMessage
        {
            if (typeof(T) == typeof(NextFibonacciMessage))
            {
                return FibonacciHttpUri;
            }
            
            throw new ArgumentException("Unknown message");
        }
        
        public static string FibonacciHttpUri => "http://localhost:5000/api/fibonacci";
    }
}