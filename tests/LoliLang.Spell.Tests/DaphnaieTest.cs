using FluentAssertions;
using LoliLang.Spell.Dryad;
using LoliLang.Spell.Dryad.Mem;
using LoliLang.Spell.Dryad.Types;
using Xunit;

namespace LoliLang.Spell.Tests
{
    public class DaphnaieTest
    {

        [Fact]
        public void SimpleText()
        {
            var daphnaie = new Daphnaie(new LoliStack(), null);
            var lexy = new Lexy.Lexy();
            var tokens = lexy.LookAt("12 - 2 + 1");
            
            var result = daphnaie.GrowTreeFrom(tokens);

            var reduction = result.Reduce();

            reduction.Should().BeOfType<NumberExpression>();
            result.ToString().Should().BeEquivalentTo("12 - 2 + 1");
        }
    }
}