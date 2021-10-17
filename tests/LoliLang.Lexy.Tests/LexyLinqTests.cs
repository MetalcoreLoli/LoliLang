using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Xunit;

namespace LoliLang.Lexy.Tests
{
    public class LexyLinqTests
    {
        [Fact]
        public void TryToLookAt_WithOnePlusTwo_ReturnsTokens()
        {
            var mockNums = new Mock<IParserRule>();
            var plusMockRule = new Mock<IParserRule>();

            var rules = new List<IParserRule> {mockNums.Object, plusMockRule.Object};

            rules.TryToLookAt("420+69").Should().BeEquivalentTo(new[]
            {
                new Token("420", Token.Forma.Number),
                new Token("+", Token.Forma.Plus),
                new Token("69", Token.Forma.Number)
            });
        }
    }
}