using System.Collections.Generic;
using console_2048.StaticData;
using FluentAssertions;
using NUnit.Framework;

namespace tests;

public class ConfigsTests
{
    [Test]
    public void WhenCreateLibrary_ThenLibraryNotNull()
    {
        // Arrange.
        // Act.

        // Assert.
        Configs.Library.Should().NotBeNull();
    }
    
    [Test]
    public void WhenCreateLibrary_AndHasDeclarations_ThenAllDeclarationsShouldBeDeclared()
    {
        // Arrange.
        var declarations = new Declarations();
        // Act.

        // Assert.
        
        Assert.Multiple(() =>
        {
            foreach (var declaration in declarations.All)
            {
                foreach (var config in declaration.Configs)
                {
                    Assert.DoesNotThrow(()=> Configs.Get(config.GetType(), config.Name));
                }
            }
        });
    }
}