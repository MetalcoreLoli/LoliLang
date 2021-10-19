using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace LoliLang.Lexy.Tests
{
    public class LexyBinaryOperationsTests
    {
        [Fact]
        public void LootAt_WithOnePlusTwoString_ReturnsListOfTokens()
        {
            var lexy = new Lexy();
            
            //act
            var answer = lexy.LookAt("420+69");

            //assert
            answer.Should().BeEquivalentTo(new List<Token>()
            {
                new ("420", Token.Forma.Number),
                new ("+", Token.Forma.Plus),
                new ("69", Token.Forma.Number)
            });
        }
        [Fact]
        public void LootAt_WithOneSubTwoString_ReturnsListOfTokens()
        {
            var lexy = new Lexy();
            
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
            var lexy = new Lexy();
            
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
            var lexy = new Lexy();
            
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
            var lexy = new Lexy();
            
            //act
            var answer = lexy.LookAt("1+2 - 3* 4 / 5");

            //assert
            answer.Should().BeEquivalentTo(new List<Token>()
            {
                new ("1", Token.Forma.Number),
                new ("+", Token.Forma.Plus),
                new ("2", Token.Forma.Number),
                new ("-", Token.Forma.Sub),
                new ("3", Token.Forma.Number),
                new ("*", Token.Forma.Mul),
                new ("4", Token.Forma.Number),
                new ("/", Token.Forma.Div),
                new ("5", Token.Forma.Number),
            });
        }
    }
}