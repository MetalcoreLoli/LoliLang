using FluentAssertions;
using LoliLang.Spell.Dryad;
using LoliLang.Spell.Dryad.Builders;
using LoliLang.Spell.Dryad.Types;
using LoliLang.Spell.Mnemosyne;
using Moq;
using Xunit;

namespace LoliLang.Spell.Tests
{
    public class LoliUnitTests
    {
        private Mock<IExpressionBuilder> _expressionBuilder;
        private Mock<ILoliStack<Expression>> _valueTypeStack;

        [Fact]
        public void SayWhatIsThe_WithThreeExpression_Returns10()
        {
            var loli = new Daphnaie();
            var lexy = new Lexy.Lexy();
            var a = lexy.LookAt("a = 4");
            var b = lexy.LookAt("b = 6");
            var c = lexy.LookAt("a + b");

            var aTree = loli.GrowTreeFrom(a);
            var bTree = loli.GrowTreeFrom(b);
            var cTree = loli.GrowTreeFrom(c);
            
            //act
            var result = loli.SayWhatIsThe();
            
            //assert
            result.ToString().Should().BeEquivalentTo("10");
        }
        
        [Fact]
        public void SayWhatIsThe_WithBinaryExpression_ReturnsTypeExpression()
        {
            _valueTypeStack = new Mock<ILoliStack<Expression>>();
            _expressionBuilder = new Mock<IExpressionBuilder>();
            var loli = new Daphnaie(_valueTypeStack.Object, _expressionBuilder.Object);

            var one = new Mock<TypeExpression>();
            var two = new Mock<TypeExpression>();
            var three = new Mock<TypeExpression>();
            three
                .Setup(x => x.ToString()).Returns("3");
            
            var binaryExpression = new Mock<BinaryExpression>(one.Object, two.Object);
            binaryExpression
                .Setup(x => x.Reduce()).Returns(three.Object);

            //act
            var result = loli.SayWhatIsThe();
            
            //assert
            result.Should().BeOfType<TypeExpression>();
            result.ToString().Should().BeEquivalentTo("3");
        }
    }
}