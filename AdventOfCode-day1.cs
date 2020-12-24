using System;

namespace AdventOfCode
{
    public class AdventOfCode
    {
        public static void GetFirstStar()
        {
            string[] lines = System.IO.File.ReadAllLines("input.csv");
            int len=lines.Length;
            int i=0;
            int j=0;
            int answer=0;
            while(i<len && answer==0)
            {
                while(j<len && answer==0)
                {
                    if (int.Parse(lines[i])+int.Parse(lines[j])==2020)
                    {
                        answer=int.Parse(lines[i])*int.Parse(lines[j]);
                    }
                    j++;
                }
                i++;
                j=0;
            }
            Console.WriteLine("The answer is: {0}", answer);
        }
        public static void GetSecondStar()
        {
            string[] lines = System.IO.File.ReadAllLines("input.csv");
            int len=lines.Length;
            int i=0;
            int j=0;
            int k=0;
            int answer=0;
            while(i<len && answer==0)
            {
                while(j<len && answer==0)
                {
                    while(k<len && answer==0)
                    {
                        if (int.Parse(lines[i])+int.Parse(lines[j])+int.Parse(lines[k])==2020)
                        {
                            answer=int.Parse(lines[i])*int.Parse(lines[j])*int.Parse(lines[k]);
                        }
                        k++;
                    }
                    j++;
                    k=0;
                }
                i++;
                j=0;
            }
            Console.WriteLine("The answer is: {0}", answer);
        }
    }

    class Program
    {
        static void Main (string[] args)
        {
            // AdventOfCode.GetFirstStar();
            // AdventOfCode.GetSecondStar();
            // AdventOfCodeDay2.GetFirstStar();
            // AdventOfCodeDay2.GetSecondStar();
            // AdventOfCodeDay3.GetFirstStar();
            // AdventOfCodeDay3.GetSecondStar();
            // AdventOfCodeDay4.GetFirstStar();
            // AdventOfCodeDay5.GetFirstStar();
            AdventOfCodeDay5.GetSecondStar();
        }
    }
}
