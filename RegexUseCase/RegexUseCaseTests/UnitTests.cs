using Xunit;
using RegexUseCase;

namespace RegexUseCaseTests
{
    public class UnitTests
    {
        [Fact]
        public void TestCase_Success()
        {
            // Arrange
            var input = "abC!r03K";
            var maxLength = 10U;

            // Act
            var result = Program.IsMatch(maxLength, input);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TestCase_TooShortInput()
        {
            // Arrange
            var input = string.Empty;
            var maxLength = 10U;

            // Act
            var result = Program.IsMatch(maxLength, input);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TestCase_TooLongInput()
        {
            // Arrange
            var input = "abC%Tbdr03Kgggf";
            var maxLength = 10U;

            // Act
            var result = Program.IsMatch(maxLength, input);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TestCase_MatchingInputLength()
        {
            // Arrange
            var input = "abC!r03Kgg";
            var maxLength = 10U;

            // Act
            var result = Program.IsMatch(maxLength, input);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TestCase_MissingUppercase()
        {
            // Arrange
            var input = "abd23!%";
            var maxLength = 10U;

            // Act
            var result = Program.IsMatch(maxLength, input);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TestCase_MissingLowercase()
        {
            // Arrange
            var input = "ABD23!%";
            var maxLength = 10U;

            // Act
            var result = Program.IsMatch(maxLength, input);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TestCase_MissingSpecialCharacter()
        {
            // Arrange
            var input = "ABDdd23";
            var maxLength = 10U;

            // Act
            var result = Program.IsMatch(maxLength, input);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TestCase_MissingDigit()
        {
            // Arrange
            var input = "ABDdd!!";
            var maxLength = 10U;

            // Act
            var result = Program.IsMatch(maxLength, input);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TestCase_ContainsWhitespace()
        {
            // Arrange
            var input = "\vB\t\td !!\v";
            var maxLength = 10U;

            // Act
            var result = Program.IsMatch(maxLength, input);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TestCase_ContainsOtherUnicode()
        {
            // Arrange
            var input = "AbcD2-5¿";
            var maxLength = 10U;

            // Act
            var result = Program.IsMatch(maxLength, input);

            // Assert
            Assert.False(result);
        }
    }
}