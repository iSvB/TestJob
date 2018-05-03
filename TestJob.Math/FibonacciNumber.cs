namespace TestJob.Math
{
    public sealed class FibonacciNumber
    {
        private readonly Integer _value;                

        public FibonacciNumber(Integer value)
        {
            _value = value;
        }

        public FibonacciNumber GetPrevious()
        {
            if (_value.IsEqual(new Integer(1)))
            {
                return new FibonacciNumber(new Integer(1));
            }
            
            FibonacciNumber previous, current;
            previous = current = new FibonacciNumber(new Integer(1));

            while (_value.IsGreaterThan(current._value))
            {
                var next = current.GetNext();
                previous = current;
                current = next;
            }

            return previous;
        }

        public FibonacciNumber GetNext()
        {
            var previousFibonacciNumber = GetPrevious();
            var nextInteger = previousFibonacciNumber._value.Add(_value);
            return new FibonacciNumber(nextInteger);
        }

        public override string ToString() => _value.ToString();
    }
}