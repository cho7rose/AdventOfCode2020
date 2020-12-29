using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using AdventOfCode;

namespace AdventOfCode
{
    public class AdventOfCodeDay7
    {
        public static List<string> ResultBags = new List<string>();
        public static void GetFirstStar()
        {
            
            string[] input = System.IO.File.ReadAllLines("input-day7.csv");
            var Bags = CreateBagTree(input);
            HowManyBagsCanCarryYourBag(Bags, "shiny gold");
            Console.WriteLine("There are {0} bag that can contain shiny gold bags", ResultBags.Count());
        }
        public static void GetSecondStar()
        {
            string[] input = System.IO.File.ReadAllLines("input-day7.csv");            
            var Bags = CreateBagTree(input);
            Console.WriteLine("Shiny gold bags must contain {0} bags", HowManyBagsDoYouNeedToCarryYourBag(Bags, "shiny gold"));   
        }
        public static List<Bag> CreateBagTree(string[] input)
        {
            List<Bag> Bags = new List<Bag>();
            foreach (var line in input)
            {
                string[] separators = {" bags contain ", " bags, ", " bags.", " bag, ", " bag."};
                var tmp = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                var list_of_content = tmp.Skip(1).Where(t=>t!="no other");
                Bags.Add(new Bag()
                {
                    Colour=tmp.First()
                });
                var abi = Bags.Where(t=>t.Colour==tmp.First()).First().Content = new List<Bag>();
                foreach(var el in list_of_content)
                {
                    abi.Add(new Bag() 
                    {
                        nb_bags=el[0]-'0',
                        Colour=el.Substring(2)
                    });
                }
            }
            return Bags;                  
        }
        public static void HowManyBagsCanCarryYourBag(List<Bag> Bags, string myColour)
        {
            foreach (var bag in Bags)
            {
                bag.Content.Where(x=>x.Colour==myColour)
                    .ToList()
                    .ForEach(x=>
                    {
                        if(!ResultBags.Contains(bag.Colour)) ResultBags.Add(bag.Colour);
                        HowManyBagsCanCarryYourBag(Bags, bag.Colour);
                    });
            }
        }
        public static int HowManyBagsDoYouNeedToCarryYourBag(List<Bag> Bags, string myColour)
        {
            int AmountsOfBags = 0;
            foreach (var bag in Bags.Where(x=>x.Colour==myColour))
            {
               bag.Content.ToList()
                .ForEach(x=>
                    {
                        AmountsOfBags+=x.nb_bags;
                        AmountsOfBags+=x.nb_bags * HowManyBagsDoYouNeedToCarryYourBag(Bags, x.Colour);
                    }); 
            }
            return AmountsOfBags;
            
        }
        
    }
    public class Bag
    {
        public string Colour {get; set;}
        public int nb_bags {get; set;}
        public List<Bag> Content {get; set;} = new List<Bag>();
    }
}