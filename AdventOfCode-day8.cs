using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using AdventOfCode;

namespace AdventOfCode
{
    public class AdventOfCodeDay8
    {
        public static void GetFirstStar()
        {
            string[] input = System.IO.File.ReadAllLines("input-day8.csv");
            Console.WriteLine("The last value of the accumulator is: {0}", Find_acc_value(input, out var cursor).ToString());
        }
        public static void GetSecondStar()
        {
            string[] input = System.IO.File.ReadAllLines("input-day8.csv");
            Console.WriteLine("The value of the accumulator when the boot code is fixed is: {0}", Fix_boot_code(input).ToString());
        }
        public static int Find_acc_value (string[] input, out int cursor)
        {
            var accumulator = 0;
            List<int> instructions_used = new List<int>();
            cursor = 0;
            string[] separators = {" "};
            while(!instructions_used.Contains(cursor) && cursor!=input.Count())
            {
                var tmp = input[cursor].Split(separators,StringSplitOptions.RemoveEmptyEntries);
                instructions_used.Add(cursor);
                switch(tmp.First())
                {
                    case "nop":
                        cursor++;
                        break;
                    case "acc":
                        accumulator = accumulator + Int16.Parse(tmp[1]);
                        cursor++;
                        break;
                    case "jmp":
                        cursor = cursor + Int16.Parse(tmp[1]);
                        break;
                }
            }
            return accumulator;
            
        }
        public static int Fix_boot_code(string[] original)
        {
            string[] separators = {" "};
            var acc = 0;
            var new_input = new string[original.Count()];
            for(int i=0; i<original.Count(); i++)
            {
                original.CopyTo(new_input,0);
                var tmp = new_input[i].Split(separators,StringSplitOptions.RemoveEmptyEntries);
                if(tmp[0]=="jmp"){new_input[i]="nop "+tmp[1];}
                else if (tmp[0]=="nop"){new_input[i]="jmp "+tmp[1];}
                acc = Find_acc_value(new_input, out int cursor);
                if(cursor==new_input.Count()) return acc;
            }
            return acc;
        }
    }
}