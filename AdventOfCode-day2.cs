using System;

namespace AdventOfCode
{
    public class AdventOfCodeDay2
    {
        public static void GetFirstStar()
        {
            int count = 0;
            string[] lines = System.IO.File.ReadAllLines("input-day2.csv");
            foreach(string l in lines)
            {
               if(IsPwdCorrectPart1(l)==true) count++;
            }
            Console.WriteLine("The number of correct passwords is: {0}", count);
        }
        public static bool IsPwdCorrectPart1(string input)
        {
            char[] separators = {'-', ' ', ':'};
            string[] s = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int min = int.Parse(s[0]);
            int max = int.Parse(s[1]);
            char RequiredChar = char.Parse(s[2]);
            string Password = s[3];
            int counter=0;
            foreach (char c in Password)
            {
               if(c==RequiredChar) counter++;
            }
            bool res = false;
            if(counter>=min && counter<=max) res =true;
            return(res);
        }
        public static void GetSecondStar()
        {
            int count = 0;
            string[] lines = System.IO.File.ReadAllLines("input-day2.csv");
            foreach(string l in lines)
            {
               if(IsPwdCorrectPart2(l)==true) count++;
            }
            Console.WriteLine("The number of correct passwords is: {0}", count);
        }
        public static bool IsPwdCorrectPart2(string input)
        {
            char[] separators = {'-', ' ', ':'};
            string[] s = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int min = int.Parse(s[0]);
            int max = int.Parse(s[1]);
            char RequiredChar = char.Parse(s[2]);
            string Password = s[3];
            bool res = false;
            if((Password[min-1]==RequiredChar && Password[max-1]!=RequiredChar) || (Password[min-1]!=RequiredChar && Password[max-1]==RequiredChar)) res = true;
            return(res);
        }
    }
}