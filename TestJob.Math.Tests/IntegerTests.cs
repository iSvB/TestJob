using System;
using NUnit.Framework;

namespace TestJob.Math.Tests
{
    [TestFixture]
    public class IntegerTests
    {
        private Integer _target;
        
        [Test]
        [TestCase("0", "0")]
        [TestCase("1", "1")]
        [TestCase("4", "2")]
        [TestCase("8", "2")]
        [TestCase("9", "3")]
        [TestCase("10", "3")]        
        [TestCase("15", "3")]
        [TestCase("16", "4")]
        [TestCase("17", "4")]
        public void SqrtCalculatedCorrectly(string square, string root)
        {
            _target = new Integer(square);

            var sqrt = _target.Sqrt();
            
            Assert.AreEqual(root, sqrt.ToString());
        }

        [Test]
        [TestCase("-1")]
        [TestCase("-10")]
        public void SqrtShouldFail(string square)
        {
            _target = new Integer(square);

            Assert.Throws<InvalidOperationException>(() => _target.Sqrt());
        }

        [Test]
        [TestCase("0", true)]
        [TestCase("1", true)]
        [TestCase("8", false)]
        [TestCase("9", true)]
        [TestCase("10", false)]
        public void IsPerfectSquareCalculatedCorrectly(string square, bool isPerfect)
        {
            _target = new Integer(square);
            
            Assert.AreEqual(isPerfect, _target.IsPerfectSquare());
        }

        [Test]
        [TestCase("-1")]
        [TestCase("-10")]
        public void IsPerfectSquareShouldFail(string square)
        {
            _target = new Integer(square);

            Assert.Throws<InvalidOperationException>(() => _target.IsPerfectSquare());
        }

        [Test]
        [TestCase("0", true)]
        [TestCase("1", true)]
        [TestCase("2", true)]
        [TestCase("3", true)]
        [TestCase("5", true)]
        [TestCase("8", true)]
        [TestCase("12", false)]
        [TestCase("13", true)]        
        [TestCase("14", false)]
        public void IsFibonacciNumberCalculatedCorrectly(string number, bool isFibonacci)
        {
            _target = new Integer(number);
            
            Assert.AreEqual(isFibonacci, _target.IsFibonacciNumber());
        }

        [Test]
        [TestCase("2.3", typeof(ArgumentException))]
        [TestCase(".1", typeof(ArgumentException))]
        [TestCase("x", typeof(ArgumentException))]
        [TestCase(null, typeof(ArgumentNullException))]
        public void ConstructorShouldFailIfNotInteger(string value, Type exceptionType)
        {
            Assert.Throws(exceptionType, () => new Integer(value));
        }

        [Test]      
        [TestCase("1", "2")]
        [TestCase("0", "1")]
        [TestCase("-2", "-1")]
        [TestCase("-1", "0")]
        public void ShouldCompareCorrectly(string lesserStr, string greaterStr)
        {
            var lesser = new Integer(lesserStr);
            var greater = new Integer(greaterStr);
            
            Assert.True(greater.IsGreaterThan(lesser));
        }
    }
}