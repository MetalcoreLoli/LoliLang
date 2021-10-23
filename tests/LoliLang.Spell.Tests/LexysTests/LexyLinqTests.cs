using System.Collections.Generic;
using FluentAssertions;
using LoliLang.Spell.Lexy;
using LoliLang.Spell.Lexy.ParsingRules;
using Moq;
using Xunit;

namespace LoliLang.Spell.Tests.LexysTests
{
    public class LexyLinqTests
    {
        [Fact]
        public void TryToLookAt_WithOnePlusTwo_ReturnsTokens()
        {
            var mockNums = new Mock<IParsingRule>();
            var plusMockRule = new Mock<IParsingRule>();

            mockNums
                .Setup(x => x.TryOn(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new Token("NUMBER", Token.Forma.Number));
            plusMockRule
                .Setup(x => x.TryOn("+", It.IsAny<string>()))
                .Returns(new Token("PLUS", Token.Forma.Add));

            var rules = new List<IParsingRule> {mockNums.Object, plusMockRule.Object};

            rules.TryToLookAt("420+69").Should().BeEquivalentTo(new[]
            {
                new Token("NUMBER", Token.Forma.Number),
                new Token("PLUS", Token.Forma.Add),
                new Token("NUMBER", Token.Forma.Number)
            });
        }
    }
}