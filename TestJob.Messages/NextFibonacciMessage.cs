namespace TestJob.Messages
{
    public sealed class NextFibonacciMessage : IMessage
    {
        public string Value { get; set; }
    }
}
