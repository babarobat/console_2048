using console_2048;
using console_2048.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace tests;

public class IntExtensionsTests
{
    [Test]
    public void WhenCountingLength_AndLengthIs1_ThenLengthsShouldBe1()
    {
        // Arrange.
        var number = 9;
        // Act.
        var result = number.Length();
        // Assert.
        result.Should().Be(1);
    }
    
    [Test]
    public void WhenCountingLength_AndLengthIs2_ThenLengthsShouldBe2()
    {
        // Arrange.
        var number = 99;
        // Act.
        var result = number.Length();
        // Assert.
        result.Should().Be(2);
    }
    
    [Test]
    public void WhenCountingLength_AndNumberIsNegativeWithLengthIs1_ThenLengthsShouldBe1()
    {
        // Arrange.
        var number = -9;
        // Act.
        var result = number.Length();
        // Assert.
        result.Should().Be(1);
    }
    
    [Test]
    public void WhenCountingLength_AndNumberIsNegativeWithLengthIs2_ThenLengthsShouldBe2()
    {
        // Arrange.
        var number = -99;
        // Act.
        var result = number.Length();
        // Assert.
        result.Should().Be(2);
    }
    
    [Test]
    public void WhenCountingLength_AndNumberIs0_ThenLengthsShouldBe1()
    {
        // Arrange.
        var number = 0;
        // Act.
        var result = number.Length();
        // Assert.
        result.Should().Be(1);
    }
}