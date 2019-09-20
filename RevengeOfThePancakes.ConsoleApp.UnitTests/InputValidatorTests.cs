using FluentAssertions;
using NUnit.Framework;
using RevengeOfThePancakes.ConsoleApp;

namespace Tests
{
    [TestFixture]
    public class InputValidatorTests
    {
        private InputValidator _inputValidator;
        
        [SetUp]
        public void Setup()
        {
            _inputValidator = new InputValidator();
        }
        
        [Test]
        public void IsValidPancakeStringTest_TooShortOrNull_ReturnsFalse()
        {
            _inputValidator.IsValidPancakeString(null).Should().BeFalse();
            _inputValidator.IsValidPancakeString("").Should().BeFalse();
        }
        
        [Test]
        public void IsValidPancakeStringTest_TooLong_ReturnsFalse()
        {
            _inputValidator.IsValidPancakeString(new string('-', 101)).Should().BeFalse();
        }
        
        [Test]
        public void IsValidPancakeStringTest_NotValidPancakeString_ReturnsFalse()
        {
            _inputValidator.IsValidPancakeString("foo").Should().BeFalse();
        }
        
        [Test]
        [TestCase("-")]
        [TestCase("-+")]
        [TestCase("+-")]
        [TestCase("+++")]
        [TestCase("--+-")]
        public void IsValidPancakeStringTest_ValidPancakeString_ReturnsTrue(string pancakeString)
        {
            _inputValidator.IsValidPancakeString(pancakeString).Should().BeTrue();
        }
    }
}