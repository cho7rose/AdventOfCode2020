using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class AdventOfCodeDay4
    {
        public static void GetFirstStar()
        {
            
            var PPorts = LoadPassports();
            Console.WriteLine("There are {0} valid passports",CountValidPassports(PPorts));

        }
        public static void GetSecondStar()
        {

        }
        public static Dictionary <int, Dictionary<string,string>> LoadPassports()
        {
            string[] lines = System.IO.File.ReadAllLines("input-day4.csv");
            int i = 0;
            var Passports = new Dictionary <int, Dictionary<string,string>>();
            int passport_nb=0;
            while(i<lines.Length)            
            {
                while(i<lines.Length && lines[i]!=string.Empty)
                {
                    char[] separators={' ', '\n'};
                    string[] sub = lines[i].Split(separators);
                    if(Passports.ContainsKey(passport_nb)==false) Passports[passport_nb] = new Dictionary<string,string>();
                    foreach(string a in sub)
                    {
                        string[] b = a.Split(':');
                        Passports[passport_nb].Add(b[0],b[1]);
                    }
                    i++;
                }
                passport_nb++;
                i++;
            }
            return Passports;
        }
        public static int CountValidPassports (Dictionary <int, Dictionary<string,string>> Passports)
        {
            int ValidPassports = 0;
            string[] RequiredFields = {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};
            foreach(var kvp in Passports)
            {
                bool valid=true;
                foreach(var field in RequiredFields)
                {
                    if(kvp.Value.ContainsKey(field)==false) valid=false;
                    else 
                    {
                        if(CheckFieldFormat(field, kvp.Value)==false) valid=false;
                    }
                }
                if (valid==true) 
                {
                    ValidPassports++;
                }
            }
            return ValidPassports;
        }
        public static bool CheckFieldFormat (string field, Dictionary <string,string> ID)
        {
            bool result = true;
            char[] hexadecimal = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', '#'};
            String[] EyeColours = {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
            switch (field)
            {
                case "byr":
                    result=(Int16.Parse(ID["byr"])>=1920 && Int16.Parse(ID["byr"])<=2002) ? true : false;
                    break;
                case "iyr":
                    result=(Int16.Parse(ID["iyr"])>=2010 && Int16.Parse(ID["iyr"])<=2020) ? true : false;
                    break;
                case "eyr":
                    result=(Int16.Parse(ID["eyr"])>=2020 && Int16.Parse(ID["eyr"])<=2030) ? true : false;
                    break;
                case "hgt":
                    string s=ID["hgt"];
                    int height = 0;
                    if(s[s.Length-1]=='m')
                    {
                        height=int.Parse(s.Split('c')[0]);
                        result=(height>=150 && height<=193) ? true : false;
                    }
                    else if (s[s.Length-1]=='n')
                    {
                        height=int.Parse(s.Split('i')[0]);
                        result=(height>=59 && height<=76) ? true : false;
                    }
                    else result=false;
                    break;
                case "hcl":
                    foreach (char c in ID["hcl"])
                    {
                        if(hexadecimal.Contains(c)==false)
                        {
                            result=false;
                            break;
                        }
                    }
                    result=ID["hcl"][0]=='#' ? true : false;
                    break;
                case "ecl":
                    result = EyeColours.Contains(ID["ecl"]) ? true : false;
                    break;
                case "pid":
                    result = (ID["pid"].Length==9 && int.TryParse(ID["pid"], out _)) ? true : false;
                    break;
            }
            return result;
        }
    }
}