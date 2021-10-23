using System.Collections.Generic;
using FluentAssertions;
using LoliLang.Spell.Lexy;
using Xunit;

namespace LoliLang.Spell.Tests.LexysTests
{
    public class LexyBinaryOperationsTests
    {
        [Fact]
        public void LootAt_WithOnePlusTwoString_ReturnsListOfTokens()
        {
            var lexy = new Spell.Lexy.Lexy();
            
            //act
            var answer = lexy.LookAt("420+69");

            //assert
            answer.Should().BeEquivalentTo(new List<Token>()
            {
                new ("420", Token.Forma.Number),
                new ("+", Token.Forma.Add),
                new ("69", Token.Forma.Number)
            });
        }
        
        [Fact]
        public void LootAt_WithOneSubTwoString_ReturnsListOfTokens()
        {
            var lexy = new Spell.Lexy.Lexy();
            
            //act
            var answer = lexy.LookAt("420-69");

            //assert
            answer.Should().BeEquivalentTo(new List<Token>()
            {
                new ("420", Token.Forma.Number),
                new ("-", Token.Forma.Sub),
                new ("69", Token.Forma.Number)
            });
        }
        
        [Fact]
        public void LootAt_WithOneMulTwoString_ReturnsListOfTokens()
        {
            var lexy = new Spell.Lexy.Lexy();
            
            //act
            var answer = lexy.LookAt("420*69");

            //assert
            answer.Should().BeEquivalentTo(new List<Token>()
            {
                new ("420", Token.Forma.Number),
                new ("*", Token.Forma.Mul),
                new ("69", Token.Forma.Number)
            });
        }
        [Fact]
        public void LootAt_WithOneDivTwoString_ReturnsListOfTokens()
        {
            var lexy = new Spell.Lexy.Lexy();
            
            //act
            var answer = lexy.LookAt("420 / 69");

            //assert
            answer.Should().BeEquivalentTo(new List<Token>()
            {
                new ("420", Token.Forma.Number),
                new ("/", Token.Forma.Div),
                new ("69", Token.Forma.Number)
            });
        }
        
        
        [Fact]
        public void LootAt_WithAllBinaryOperationInString_ReturnsListOfTokens()
        {
            var lexy = new Spell.Lexy.Lexy();
            
            //act
            var answer = lexy.LookAt("1+23 - 3* 4 / 5");

            //assert
            answer.Should().BeEquivalentTo(new List<Token>()
            {
                new ("1", Token.Forma.Number),
                new ("+", Token.Forma.Add),
                new ("23", Token.Forma.Number),
                new ("-", Token.Forma.Sub),
                new ("3", Token.Forma.Number),
                new ("*", Token.Forma.Mul),
                new ("4", Token.Forma.Number),
                new ("/", Token.Forma.Div),
                new ("5", Token.Forma.Number),
            });
        }


        [Fact]
        public void LookAt_WithIfExpression_ReturnsListOfTokens()
        {
            
            var lexy = new Spell.Lexy.Lexy();
            
            //act
            var answer = lexy.LookAt("if 1 == 1 then true else false");

            //assert
            answer.Should().BeEquivalentTo(new List<Token>()
            {
                new ("if", Token.Forma.If),
                new ("1", Token.Forma.Number),
                new ("==", Token.Forma.Eq),
                new ("1", Token.Forma.Number),
                new ("then", Token.Forma.Then),
                new ("true", Token.Forma.True),
                new ("else", Token.Forma.Else),
                new ("false", Token.Forma.False),
            });
        }
        
        [Fact]
        public void LookAt_WithVarUndIfExpression_ReturnsListOfTokens()
        {
            
            var lexy = new Spell.Lexy.Lexy();
            
            //act
            var answer = lexy.LookAt("varName = if 1 == 1 then true else false");

            //assert
            answer.Should().BeEquivalentTo(new List<Token>()
            {
                new ("varName", Token.Forma.Var),
                new ("=", Token.Forma.Define),
                new ("if", Token.Forma.If),
                new ("1", Token.Forma.Number),
                new ("==", Token.Forma.Eq),
                new ("1", Token.Forma.Number),
                new ("then", Token.Forma.Then),
                new ("true", Token.Forma.True),
                new ("else", Token.Forma.Else),
                new ("false", Token.Forma.False),
            });
        }
    }
}