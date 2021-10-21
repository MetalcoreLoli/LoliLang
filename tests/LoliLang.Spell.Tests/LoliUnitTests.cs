using FluentAssertions;
using LoliLang.Spell.Dryad;
using LoliLang.Spell.Dryad.Builders;
using LoliLang.Spell.Dryad.Mem;
using LoliLang.Spell.Dryad.Types;
using Moq;
using Xunit;

namespace LoliLang.Spell.Tests
{
    public class LoliUnitTests
    {
        private Mock<IExpressionBuilder> _expressionBuilder;
        private Mock<ILoliStack<ValueTypeExpression>> _valueTypeStack;

        [Fact]
        public void SayWhatIsThe_WithThreeExpression_ReturnsThree()
        {
            _expressionBuilder = new Mock<IExpressionBuilder>();
            _valueTypeStack = new Mock<ILoliStack<ValueTypeExpression>>();
            var loli = new Daphnaie(_valueTypeStack.Object, _expressionBuilder.Object);

            var three = new Mock<Expression>();
            three
                .Setup(x => x.ToString()).Returns("3");

            //act
            var result = loli.SayWhatIsThe(three.Object);
            
            //assert
            result.ToString().Should().BeEquivalentTo("3");
        }
        
        [Fact]
        public void SayWhatIsThe_WithBinaryExpression_ReturnsTypeExpression()
        {
            _valueTypeStack = new Mock<ILoliStack<ValueTypeExpression>>();
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
            var result = loli.SayWhatIsThe(binaryExpression.Object);
            
            //assert
            result.Should().BeOfType<TypeExpression>();
            result.ToString().Should().BeEquivalentTo("3");
        }
    }
}