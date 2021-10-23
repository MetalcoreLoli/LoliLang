using FluentAssertions;
using LoliLang.Spell.Dryad.Types;
using LoliLang.Spell.Lexy;
using Xunit;

namespace LoliLang.Spell.Tests.LexysTests
{
    public class LexyTests
    {

        [Fact]
        public void AnswerOn_WithValidAddExpression_ReturnNumberExpression()
        {
            var lexy = new Spell.Lexy.Lexy();
            var  result= lexy.AnswersOn("420+69");
            result.Reduce().ToString().Should().BeEquivalentTo("489");
        }
        
        [Fact]
        public void AnswerOn_WithValidSubExpression_ReturnsNumberExpression()
        {
            var lexy = new Spell.Lexy.Lexy();
            var  result= lexy.AnswersOn("12 - 2");
            result.Reduce().ToString().Should().BeEquivalentTo("10");
        }
        
        [Fact]
        public void AnswerOn_WithValidSubUndAddExpression_ReturnNumberExpression()
        {
            var lexy = new Spell.Lexy.Lexy();
            var  result= lexy.AnswersOn("12 - 2 + 1");
            result.Should().BeOfType<NumberExpression>();
            result.Reduce().ToString().Should().BeEquivalentTo("11");
        }
        
        [Fact]
        public void AnswerOn_WithValidSubUndAddUndMulExpression_ReturnNumberExpression()
        {
            var lexy = new Spell.Lexy.Lexy();
            var  result= lexy.AnswersOn("12 - 2 + 1 * 2 / 2");
            result.Should().BeOfType<NumberExpression>();
            result.Reduce().ToString().Should().BeEquivalentTo("11");
        }
        
        [Fact]
        public void AnswerOn_WithValidIfExpression_ReturnNumberExpression()
        {
            var lexy = new Spell.Lexy.Lexy();
            var  result= lexy.AnswersOn("if 1 == 1 then 1 else 0");
            result.Should().BeOfType<NumberExpression>();
            result.Reduce().ToString().Should().BeEquivalentTo("1");
        }

        [Fact]
        public void ParseWord_WithWordUndContext_ReturnsParsedWord()
        {
            string word = "expression";
            string context = "asdasd das expression dasda";

            (string tail, string result) = LexyParsingMagick.ParseWord(word, context);

            result.Should().BeEquivalentTo("expression");
        }
        
        [Fact]
        public void ParseWord_WithoutWordInContext_ReturnsEmptyString()
        {
            string word = "expression";
            string context = "asdasd das dasda";

            (string tail, string result) = LexyParsingMagick.ParseWord(word, context);

            result.Should().BeEquivalentTo(string.Empty);
        }
    }
}