using TestJob.Cqrs;

namespace TestJob.Math.Cqrs.Queries.Fibonacci
{
    public sealed class CalculateNextFibonacciNumberQueryResult : IQueryResult
    {
        public string NextValue { get; set; }
    }
}