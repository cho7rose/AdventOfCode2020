using System;

namespace AdventOfCode
{
    public class AdventOfCodeDay3
    {
        public static void GetFirstStar()
        {
            
            Console.WriteLine("Sledge went through {0} trees",GoDownSlope(3,1));

        }
        public static void GetSecondStar()
        {
            
            double trees;
            trees=0;
            trees=GoDownSlope(1,1)*GoDownSlope(3,1)*GoDownSlope(5,1)*GoDownSlope(7,1)*GoDownSlope(1,2);
            Console.WriteLine("Sledge went through {0} trees",trees);

        }
        
        public static double GoDownSlope(int left, int down)
        {
            int x, y,ln;
            double trees;
            x=y=ln=0;
            trees=0;
            string[] lines = System.IO.File.ReadAllLines("input-day3.csv");
            foreach(var l in lines)
            {
                if(y==0)
                {
                    ln++;
                    x=(x+left)%31;
                    y=y+down;
                }
                else {
                    if(ln==y)
                    {
                        if(l[x]=='#') trees++;
                        x=(x+left)%31;
                        y=y+down;
                    }
                    ln++;
                }

            }
            return(trees);
        }

    }
}