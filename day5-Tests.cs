using System;
using Xunit;
using Xunit.Abstractions;
using AdventOfCode;
using FluentAssertions;

    public class Day5Tests
    {
        private static readonly string Sample = "FBFBBFFRLR";
        
        [Fact]
        public void Part1_Row()
        {
            var expected = 44;
            var actual = AdventOfCodeDay5.FindRow(Sample.Substring(0,7));
            Assert.Equal(expected, actual);
        } 
        [Fact]
        public void Part1_Seat()
        {
            var expected = 5;
            var actual = AdventOfCodeDay5.FindSeat(Sample.Substring(7));
            Assert.Equal(expected, actual);
        }
    }
