using System;
using Xunit;
using Xunit.Abstractions;
using AdventOfCode;
using FluentAssertions;

    public class Day6Tests
    {
        private static readonly string Sample = @"abc

a
b
c

ab
ac

a
a
a
a

b";
        
        [Fact]
        public void Part1()
        {
            var expected = 11;
            string[] input = Sample.Split('\n');
            var Answers = AdventOfCodeDay6.CalculateAnswersPart1(input);
            var actual = AdventOfCodeDay6.SumOfCounts(Answers);
            Assert.Equal(expected, actual);
        } 
        [Fact]
        public void Part2()
        {
            var expected = 6;
            string[] input = Sample.Split('\n');
            var Answers = AdventOfCodeDay6.CalculateAnswersPart2(input);
            var actual = AdventOfCodeDay6.SumOfCounts(Answers);
            Assert.Equal(expected, actual);
        }
    }