using FluentAssertions;
using LoliLang.Spell.Dryad.Types;
using LoliLang.Spell.Lexy;
using Xunit;

namespace LoliLang.Spell.Tests.LexysTests
{
    public class LexyTests
    {

        [Fact]
        public void AnswerOn_WithValidAddExpression_ReturnAddExpression()
        {
            var lexy = new Spell.Lexy.Lexy();
            var  result= lexy.AnswersOn("420+69");
            result.Reduce().ToString().Should().BeEquivalentTo("489");
        }
        
        [Fact]
        public void AnswerOn_WithValidSubExpression_ReturnsSubExpression()
        {
            var lexy = new Spell.Lexy.Lexy();
            var  result= lexy.AnswersOn("12 - 2");
            result.Reduce().ToString().Should().BeEquivalentTo("10");
        }
        
        [Fact]
        public void AnswerOn_WithValidSubUndAddExpression_ReturnAddExpression()
        {
            var lexy = new Spell.Lexy.Lexy();
            var  result= lexy.AnswersOn("12 - 2 + 1");
            result.Should().BeOfType<NumberExpression>();
            result.Reduce().ToString().Should().BeEquivalentTo("11");
        }
    }
}