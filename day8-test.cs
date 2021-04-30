using System;
using Xunit;
using Xunit.Abstractions;
using AdventOfCode;
using FluentAssertions;

    public class Day8Tests
    {
        private static readonly string Sample = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";

        [Fact]
        public void Part1()
        {
        var expected = 5;
        var actual = AdventOfCodeDay8.Find_acc_value(Sample.Split(new[] { Environment.NewLine }, StringSplitOptions.None), out var cursor);
        Assert.Equal(expected,actual);
        }
                [Fact]
        public void Part2()
        {
        var expected = 8;
        var actual = AdventOfCodeDay8.Fix_boot_code(Sample.Split(new[] { Environment.NewLine }, StringSplitOptions.None));
        Assert.Equal(expected,actual);
        }
    }