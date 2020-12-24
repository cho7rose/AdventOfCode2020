using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using AdventOfCode;

namespace AdventOfCode
{
    public class AdventOfCodeDay5
    {
        public static void GetFirstStar()
        {
            
            var BoardingPasses = LoadBoardingPasses();
            Console.WriteLine("The highest seat ID is {0}",BoardingPasses.Keys.Max());
        }
        public static void GetSecondStar()
        {
            var BoardingPasses = LoadBoardingPasses();
            int i=5;
            var result=0;
            while(i<832 && result==0)
            {
                if(!BoardingPasses.ContainsKey(i) && BoardingPasses.ContainsKey(i-1) && BoardingPasses.ContainsKey(i+1)) result=i;
                i++;
            }
            Console.WriteLine("My seat ID is {0}",result);
        }
        public static Dictionary<int,string> LoadBoardingPasses()
        {
            string[] lines = System.IO.File.ReadAllLines("input-day5.csv");
            var BoardingPasses = new Dictionary<int,string>();
            foreach(var l in lines)
            {
                int row = FindRow(l.Substring(0,7));
                int seat = FindSeat(l.Substring(7));
                BoardingPasses.Add((row*8+seat),l);
            }
            return BoardingPasses;
        }
        public static int FindRow(string l_row)
        {
            int min = 0;
            int max = 127;
            foreach(char c in l_row)
            {
                if(c=='F') 
                {
                    max=(max-min+1)/2+min-1;
                }
                else
                {
                    min=(max-min+1)/2+min;
                }
            }
            return min;
        }
        public static int FindSeat(string l_seat)
        {
            int min = 0;
            int max = 7;
            foreach(char c in l_seat)
            {
                if(c=='L')
                {
                    max=(max-min+1)/2-1+min;
                }
                else
                {
                    min=(max-min+1)/2+min;
                }
            }
            return min;
        }
    }
}