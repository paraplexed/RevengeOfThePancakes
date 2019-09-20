using FluentAssertions;
using NUnit.Framework;

namespace RevengeOfThePancakes.ConsoleApp.UnitTests
{
    [TestFixture]
    public class PancakeSorterTests
    {
        private PancakeSorter _pancakeSorter;
        
        [SetUp]
        public void Setup()
        {
            _pancakeSorter = new PancakeSorter();
        }

        [Test]
        [TestCase("-", 1)]
        [TestCase("-+", 1)]
        [TestCase("+-", 2)]
        [TestCase("+++", 0)]
        [TestCase("--+-", 3)]
        public void SortTest_GivenTestCases(string pancakeString, int expectedResult)
        {
            // While loop
            var (gotPancakeString, attemptsResult) = _pancakeSorter.Sort(pancakeString);
            gotPancakeString.Should().NotBeNullOrEmpty();
            gotPancakeString.Should().NotContain("-");
            gotPancakeString.Length.Should().Be(pancakeString.Length);
            attemptsResult.Should().Be(expectedResult);
            
            // Recursive
            (gotPancakeString, attemptsResult) = _pancakeSorter.SortRecursive(pancakeString);
            gotPancakeString.Should().NotBeNullOrEmpty();
            gotPancakeString.Should().NotContain("-");
            gotPancakeString.Length.Should().Be(pancakeString.Length);
            attemptsResult.Should().Be(expectedResult);
        }
    }
}