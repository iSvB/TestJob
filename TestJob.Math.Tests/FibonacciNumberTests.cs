using NUnit.Framework;

namespace TestJob.Math.Tests
{
    [TestFixture]
    public class FibonacciNumberTests
    {
        [Test]
        [TestCase("1", "2")]
        [TestCase("2", "3")]
        [TestCase("3", "5")]
        [TestCase("5", "8")]
        public void ShouldCalculateNextFibonacciNumberCorrectly(string current, string expected)
        {
            var factory = new FibonacciNumberFactory();            
            var _target = factory.Create(current);
            
            var next = _target.GetNext();
            
            Assert.AreEqual(expected, next.ToString());
        }
                
                
        [Test]
        [TestCase("2", "1")]
        [TestCase("3", "2")]
        [TestCase("5", "3")]
        [TestCase("8", "5")]
        public void ShouldCorrectlyCalculatePreviousNumber(string current, string expecetedPrevious)
        {
            var factory = new FibonacciNumberFactory();
            var _target = factory.Create(current);
            
            Assert.AreEqual(expecetedPrevious, _target.GetPrevious().ToString());
        }
    }
}