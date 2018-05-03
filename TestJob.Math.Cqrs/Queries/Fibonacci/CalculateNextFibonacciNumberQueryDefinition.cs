using TestJob.Cqrs;

namespace TestJob.Math.Cqrs.Queries.Fibonacci
{
    public sealed class CalculateNextFibonacciNumberQueryDefinition 
        : IQueryDefinition<CalculateNextFibonacciNumberQueryResult>
    {
        public string CurrentValue { get; set; }
    }
}