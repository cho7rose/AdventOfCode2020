using System;
using Xunit;
using Xunit.Abstractions;
using AdventOfCode;
using FluentAssertions;

    public class Day7Tests
    {
        private static readonly string Sample = @"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.";
        
        [Fact]
        public void Part1()
        {
            var expected = 4;
            var Bags = AdventOfCodeDay7.CreateBagTree(Sample.Split(new[] { Environment.NewLine }, StringSplitOptions.None));
            AdventOfCodeDay7.HowManyBagsCanCarryYourBag(Bags, "shiny gold");
            var actual = AdventOfCodeDay7.ResultBags.Count;
            Assert.Equal(expected, actual);
        } 
        [Fact]
        public void Part2()
        {
            var expected = 32;
            var Bags = AdventOfCodeDay7.CreateBagTree(Sample.Split(new[] { Environment.NewLine }, StringSplitOptions.None));
            var actual = AdventOfCodeDay7.HowManyBagsDoYouNeedToCarryYourBag(Bags, "shiny gold");
            Assert.Equal(expected, actual);
        }
    }