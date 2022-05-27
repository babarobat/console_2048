using System;
using System.Collections.Generic;
using console_2048.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace tests;

public class EnumerableExtensionsTests
{

    [Test]
    public void WhenCurrentIsFirst_AndMovePrevious_ThenReturnLast()
    {
        // Arrange.
        var list = new List<int> { 1, 2, 3, 4 };
        var current = 1;

        // Act.
        var result = list.Previous(current);

        // Assert.
        result.Should().Be(4);
    }
    
    [Test]
    public void WhenCurrentIsLast_AndMoveNext_ThenReturnFirst()
    {
        // Arrange.
        var list = new List<int> { 1, 2, 3, 4 };
        var current = 4;

        // Act.
        var result = list.Next(current);

        // Assert.
        result.Should().Be(1);
    }
    
    [Test]
    public void WhenCurrentIsSecond_AndMoveNext_ThenReturnThird()
    {
        // Arrange.
        var list = new List<int> { 1, 2, 3, 4 };
        var current = 2;

        // Act.
        var result = list.Next(current);

        // Assert.
        result.Should().Be(3);
    }
    
    [Test]
    public void WhenCurrentIsSecond_AndMovePrevious_ThenReturnFirst()
    {
        // Arrange.
        var list = new List<int> { 1, 2, 3, 4 };
        var current = 2;

        // Act.
        var result = list.Next(current);

        // Assert.
        result.Should().Be(3);
    }
    
    [Test]
    public void WhenLengthIsOne_AndMovePrevious_ThenReturnFirst()
    {
        // Arrange.
        var list = new List<int> {1};
        var current = 1;

        // Act.
        var result = list.Next(current);

        // Assert.
        result.Should().Be(1);
    }
    
    [Test]
    public void WhenLengthIsOne_AndMoveNext_ThenReturnFirst()
    {
        // Arrange.
        var list = new List<int> {1};
        var current = 1;

        // Act.
        var result = list.Next(current);

        // Assert.
        result.Should().Be(1);
    }
    
    [Test]
    public void WhenLengthIsZero_AndMoveNext_ThenThrow()
    {
        // Arrange.
        var list = new List<int>();
        var current = 1;

        // Act.
      

        // Assert.
        Assert.Throws<InvalidOperationException>(() => { list.Next(current);});
    }
    
    [Test]
    public void WhenLengthIsZero_AndMovePrevious_ThenThrow()
    {
        // Arrange.
        var list = new List<int>();
        var current = 1;

        // Act.

        // Assert.
        Assert.Throws<InvalidOperationException>(() => { list.Previous(current);});
    }
    
    [Test]
    public void WhenNotContains_AndMovePrevious_ThenThrow()
    {
        // Arrange.
        var list = new List<int>{1,2,3,4};
        var current = 5;

        // Act.

        // Assert.
        Assert.Throws<ArgumentOutOfRangeException>(() => { list.Previous(current);});
    }
}