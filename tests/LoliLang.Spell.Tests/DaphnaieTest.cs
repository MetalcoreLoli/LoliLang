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
        public void GrowTreeFrom_WithValidExpression_ReturnsBinaryTreeWhereReduceResultIsNumberExpression()
        {
            var daphnaie = new Daphnaie(new LoliStack(), null);
            var lexy = new Lexy.Lexy();
            var tokens = lexy.LookAt("12 - 2 + 1"); // (- 12 (+ 2 1))
            
            var result = daphnaie.GrowTreeFrom(tokens);
            var resultOfReduction = result.Reduce();

            resultOfReduction.Should().BeOfType<NumberExpression>();
            resultOfReduction.Value.Should().BeEquivalentTo("11");
            result.ToString().Should().BeEquivalentTo("12 - 2 + 1");
        }
    }
}