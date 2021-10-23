using FluentAssertions;
using LoliLang.Spell.Dryad;
using LoliLang.Spell.Dryad.Types;
using Xunit;
using Xunit.Sdk;

namespace LoliLang.Spell.Tests
{
    public class IfExpressionTests
    {

        [Fact]
        public void Reduce_WithAddUndSubExpression_ReturnsTrue()
        {
            var ifExpression = new IfExpression(
                new EqExpression(
                    new AddExpression(new NumberExpression("0"), new NumberExpression("1")), 
                    new SubExpression(new NumberExpression("2"), new NumberExpression("1"))),
                    new TrueExpression(), new FalseExpression());

            var result = ifExpression.Reduce();

            result.Value.Should().BeEquivalentTo("true");
            ifExpression.ToString().Should().BeEquivalentTo("if 0 + 1 == 2 - 1 then True else False");
        }
    }
}