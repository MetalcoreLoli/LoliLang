using FluentAssertions;
using LoliLang.Spell.Dryad;
using LoliLang.Spell.Dryad.Types;
using Xunit;

namespace LoliLang.Spell.Tests
{
    public class DaphnaieTest
    {

        [Fact]
        public void GrowTreeFrom_WithValidExpression_ReturnsBinaryTreeWhereReduceResultIsNumberExpression()
        {
            var daphnaie = new Daphnaie();
            var lexy = new Lexy.Lexy();
            var tokens = lexy.LookAt("12 - 2 + 1"); // (- 12 (+ 2 1))
            
            var result = daphnaie.GrowTreeFrom(tokens);
            var resultOfReduction = result.Reduce();

            resultOfReduction.Should().BeOfType<NumberExpression>();
            resultOfReduction.Value.Should().BeEquivalentTo("11");
            result.ToString().Should().BeEquivalentTo("12 - 2 + 1");
        }
        
        [Fact]
        public void GrowTreeFrom_WithValidIfExpression_ReturnsBinaryTreeWhereReduceResultIsNumberExpression()
        {
            var daphnaie = new Daphnaie();
            var lexy = new Lexy.Lexy();
            var tokens = lexy.LookAt("if 1 == 1 then 1 else 0"); 
            
            var result = daphnaie.GrowTreeFrom(tokens);
            var resultOfReduction = result.Reduce();

            resultOfReduction.Should().BeOfType<NumberExpression>();
            result.ToString().Should().BeEquivalentTo("if 1 == 1 then 1 else 0");
            resultOfReduction.Value.Should().BeEquivalentTo("1");
        }
        
        
        [Fact]
        public void GrowTreeFrom_WithValidVarUndIfExpression_ReturnsBinaryTreeWhereReduceResultIsNumberExpression()
        {
            var daphnaie = new Daphnaie();
            var lexy = new Lexy.Lexy();
            var tokens = lexy.LookAt("a = if 1 == 1 then 1 else 0"); 
            
            var result = daphnaie.GrowTreeFrom(tokens);
            var resultOfReduction = result.Reduce();

            resultOfReduction.Should().BeOfType<NumberExpression>();
            result.ToString().Should().BeEquivalentTo("a = if 1 == 1 then 1 else 0");
            resultOfReduction.Value.Should().BeEquivalentTo("1");
        }
    }
}