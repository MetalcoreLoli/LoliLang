using FluentAssertions;
using LoliLang.Spell.Lexy;
using Xunit;

namespace LoliLang.Spell.Tests.LexysTests
{
    public class LexyTests
    {

        [Fact]
        public void ExpressionParserHelper_WithValidAddExpression_ReturnAddExpression()
        {
            var lexy = new Spell.Lexy.Lexy();
            var expression = lexy.LookAt("420+69").NormBinaryExpression();

            var result = Spell.Lexy.Lexy.ExpressionParserHelper(expression);

            result.ToString().Should().BeEquivalentTo("420 + 69");
        }
    }
}