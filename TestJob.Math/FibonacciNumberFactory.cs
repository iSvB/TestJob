using System;

namespace TestJob.Math
{
    public class FibonacciNumberFactory
    {
        public FibonacciNumber Create(string value)
        {
            var integer = new Integer(value);
            if (!integer.IsFibonacciNumber())
            {
                throw new ArgumentException($"{value} is not a fibonacci number");
            }
            
            return new FibonacciNumber(integer);
        }
    }
}