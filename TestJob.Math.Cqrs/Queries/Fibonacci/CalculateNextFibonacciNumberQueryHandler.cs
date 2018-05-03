using TestJob.Cqrs;

namespace TestJob.Math.Cqrs.Queries.Fibonacci
{
    public sealed class CalculateNextFibonacciNumberQueryHandler 
        : IQueryHandler<CalculateNextFibonacciNumberQueryDefinition, CalculateNextFibonacciNumberQueryResult>
    {
        private readonly FibonacciNumberFactory _fibonacciNumberFactory;

        public CalculateNextFibonacciNumberQueryHandler(FibonacciNumberFactory fibonacciNumberFactory)
        {
            _fibonacciNumberFactory = fibonacciNumberFactory;
        }

        public CalculateNextFibonacciNumberQueryResult Handle(CalculateNextFibonacciNumberQueryDefinition queryDefinition)
        {
            var fibonacciNumber = _fibonacciNumberFactory.Create(queryDefinition.CurrentValue);
            var nextFibonacciNumber = fibonacciNumber.GetNext();
            var result = new CalculateNextFibonacciNumberQueryResult {NextValue = nextFibonacciNumber.ToString()};
            return result;
        }
    }
}