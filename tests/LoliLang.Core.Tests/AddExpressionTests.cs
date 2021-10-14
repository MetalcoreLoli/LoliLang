using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace LoliLang.Core.Tests
{
    public class AddExpressionTests
    {
        [Fact]
        public void ToString_WithLeftUndRightExpressions_ReturnsAddOnePlusTwoTest()
        {
            var one = new Mock<Expression>();
            var two = new Mock<Expression>();

            one
                .Setup(x => x.ToString()).Returns("1");
            two
                .Setup(x => x.ToString()).Returns("2");

            var add = new AddExpression(one.Object, two.Object);
            
            //act
            var result = add.ToString();

            //assert
            result.Should().BeEquivalentTo("1 + 2");
        }

        [Fact]
        public void Constructor_WithNulls_ThrowsNullReferencesException()
        {
            var one = new Mock<Expression>();

            //act 
            Action withTwoNull = () =>
            {
                var add = new AddExpression(null, null);
            };

            Action withLeftNull = () =>
            {
                var add = new AddExpression(null, one.Object);
            };

            Action withRightNull = () =>
            {
                var add = new AddExpression(one.Object, null);
            };
            
            //assert
            withTwoNull
                .Should()
                .Throw<NullReferenceException>();

            withLeftNull.Should().Throw<NullReferenceException>().WithMessage("Left expression is null");
            withRightNull.Should().Throw<NullReferenceException>().WithMessage("Right expression is null");
        }
    }
}