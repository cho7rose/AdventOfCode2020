using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using AdventOfCode;

namespace AdventOfCode
{
    public class AdventOfCodeDay6
    {
        public static void GetFirstStar()
        {
            
            string[] Questionnaire = System.IO.File.ReadAllLines("input-day6.csv");
            var Answers = CalculateAnswersPart1(Questionnaire);
            Console.WriteLine("The sum of questions answered yes to is {0}",SumOfCounts(Answers));
        }
        public static void GetSecondStar()
        {
            string[] Questionnaire = System.IO.File.ReadAllLines("input-day6.csv");
            var Answers = CalculateAnswersPart2(Questionnaire);
            Console.WriteLine("The sum of questions answered yes to by all people from group is {0}",SumOfCounts(Answers));
        }
        public static Dictionary <int, Dictionary <char, int>> CalculateAnswersPart1(string[] Questionnaire)
        {
            int i=0;
            int Group = 0;
            var Answers = new Dictionary <int, Dictionary <char, int>>();
            while(i<Questionnaire.Length)
            {
                while(i<Questionnaire.Length && (Questionnaire[i]!="\r" && Questionnaire[i]!=String.Empty))
                {
                    if(!Answers.ContainsKey(Group)) Answers[Group] = new Dictionary<char, int>();
                    foreach(var c in Questionnaire[i])
                    {
                        if(Answers[Group].ContainsKey(c)) Answers[Group][c]+=1;
                        else if(c!='\r') Answers[Group].Add(c,1);
                    }
                    i++;
                }
                Group++;
                i++;
            }
            return Answers;
        }
        public static Dictionary <int, Dictionary <char, int>> CalculateAnswersPart2(string[] Questionnaire)
        {
            int i=0;
            int Group = 0;
            var Answers = new Dictionary <int, Dictionary <char, int>>();
            while(i<Questionnaire.Length)
            {
                int PeopleInGroup=0;
                while(i<Questionnaire.Length && (Questionnaire[i]!="\r" && Questionnaire[i]!=String.Empty))
                {
                    PeopleInGroup++;
                    if(!Answers.ContainsKey(Group)) Answers[Group] = new Dictionary<char, int>();
                    foreach(var c in Questionnaire[i])
                    {
                        if(Answers[Group].ContainsKey(c)) Answers[Group][c]+=1;
                        else if(c!='\r') Answers[Group].Add(c,1);
                    }
                    i++;
                }
                foreach(var Ans in Answers[Group])
                {
                    if(Ans.Value < PeopleInGroup) Answers[Group].Remove(Ans.Key);
                }
                Group++;
                i++;
            }
            return Answers;
        }
        public static int SumOfCounts(Dictionary <int, Dictionary <char, int>> Answers)
        {
            int count = 0;
            foreach(var Ans in Answers)
            {
                foreach(var letter in Ans.Value)
                {
                    count++;
                }
            }
            return count;
        }
    }
}