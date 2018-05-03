using System;
using System.Numerics;

namespace TestJob.Math
{
    public sealed class Integer
    {
        private readonly BigInteger _value;

        public Integer(int value)
        {
            _value = new BigInteger(value);
        }

        public Integer(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            try
            {
                _value = BigInteger.Parse(value);
            }
            catch (FormatException)
            {
                throw new ArgumentException($"{value} is not integer");
            }
        }

        private Integer(BigInteger value)
        {
            _value = value;
        }

        public bool IsFibonacciNumber()
        {
            // For simplicity, let's consider that fibonacci numbers can be only positive
            if (_value.Sign < 0)
            {
                return false;
            }

            var square = BigInteger.Pow(_value, 2);
            var fiveSquares = BigInteger.Multiply(5, square);
            var a = new Integer(fiveSquares + 4);
            var b = new Integer(fiveSquares - 4);

            return a.IsPerfectSquare() || b.IsPerfectSquare();
        }

        public bool IsPerfectSquare()
        {
            var sqrt = Sqrt();
            var square = BigInteger.Multiply(sqrt._value, sqrt._value);
            return square == _value;
        }

        public Integer Sqrt()
        {
            if (_value.Sign < 0)
            {
                throw new InvalidOperationException();
            }

            if (_value.IsZero)
            {
                return new Integer("0");
            }

            int bitLength = Convert.ToInt32(System.Math.Ceiling(BigInteger.Log(_value, 2)));
            BigInteger root = BigInteger.One << (bitLength / 2);

            while (!IsSqrt(_value, root))
            {
                root += _value / root;
                root /= 2;
            }

            return new Integer(root);
        }

        public Integer Add(Integer x) => new Integer(BigInteger.Add(_value, x._value));

        public bool IsGreaterThan(Integer x) => BigInteger.Compare(_value, x._value) > 0;

        public bool IsEqual(Integer x) => BigInteger.Compare(_value, x._value) == 0;

        public override string ToString() => _value.ToString();

        private static Boolean IsSqrt(BigInteger n, BigInteger root)
        {
            BigInteger lowerBound = root * root;
            BigInteger upperBound = (root + 1) * (root + 1);

            return n >= lowerBound && n < upperBound;
        }
    }
}