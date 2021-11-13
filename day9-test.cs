using System;
using Xunit;
using Xunit.Abstractions;
using AdventOfCode;
using FluentAssertions;

    public class Day8Tests
    {
        private static readonly string Sample = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";

        [Fact]
        public void Part1()
        {
            var expected = 127;
            var actual = AdventOfCodeDay9.FirstStar();
            Assert.Equal(expected, actual);
        }

    }