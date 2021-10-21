using System;
using FluentAssertions;
using LoliLang.Spell.Lexy;
using LoliLang.Spell.Lexy.Exceptions;
using Xunit;

namespace LoliLang.Spell.Tests.LexysTests
{
    public class LexyEyeOfTruthTests
    {

        [Fact]
        public void EyeOfTruth_WithWrongExpression_ThrowsMissingOperandException()
        {
            var lexy = new Spell.Lexy.Lexy();

            var tokens = lexy.LookAt("12 + 14 * 9 /");

            Action act = () => tokens.EyeOfTruth();
            act
                .Should()
                .Throw<MissingOperandException>()
                .WithMessage("Missing operand in expression \"12+14*9/\"");
        }
    }
}