using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace LoliLang.Lexy.Tests
{
    public class LexyTests
    {
        [Fact]
        public void LootAt_WithOnePlusTwoString_ReturnsListOfTokens()
        {
            var lexy = new Lexy();
            
            //act
            var answer = lexy.LookAt("420+69");

            //assert
            answer.Should().BeEquivalentTo(new List<Token>()
            {
                new ("420", Token.Forma.Number),
                new ("+", Token.Forma.Plus),
                new ("69", Token.Forma.Number)
            });
        }
    }
}