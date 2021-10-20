using System.Collections.Generic;
using FluentAssertions;
using LoliLang.Lexy;
using Xunit;

namespace LoliLang.Lexy.Tests
{
    public class LexyTests
    {

        [Fact]
        public void ExpressionParserHelper_WithValidAddExpression_ReturnAddExpression()
        {
            var lexy = new Lexy();
            var expression = lexy.LookAt("420+69").NormBinaryExpression();

            var result = Lexy.ExpressionParserHelper(expression);

            result.ToString().Should().BeEquivalentTo("420 + 69");
        }
    }
}