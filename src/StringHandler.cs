using System;
using System.Collections;
using System.Collections.Generic;

namespace StringHandler
{
    class LCS
    {
        static int isEqualRgx(string regex, string normal, List<int> matchIdx, int normalIdx) //
        {
            // if using regex, parse (...)
            if (regex.Length > 2)
            {
                regex = regex.Substring(1, regex.Length - 2);
            }

            // if regex char optional
            if (regex[regex.Length - 1] == '?') 
            { 
                if (matchIdx.Contains(normalIdx))
                    return 1; 
                else
                    return -1;
            }

            else
            {
                string[] choices = regex.Split('|');
                foreach (var choice in choices)
                {
                    if (choice == normal) { return 0; }
                }
                return -1;
            }
        }

        static int[] copyListInt(int[] list)
        {
            int[] newList = new int[list.Length];
            for (var i = 0; i < list.Length; i++)
            {
                newList[i] = list[i];
            }
            return newList;
        }
        static int LongestCommonSubsequence(string[] regex, string[] normal)
        {
            List<int> matchIdx = new List<int>();
            int n = regex.Length;
            int m = normal.Length;
            // initializing 2 arrays of size m
            int[] prev = new int[m + 1];
            int[] cur = new int[m + 1];
            for (int idx2 = 0; idx2 < m + 1; idx2++)
                cur[idx2] = 0;
            for (int idx1 = 1; idx1 < n + 1; idx1++)
            {
                for (int idx2 = 1; idx2 < m + 1; idx2++)
                {
                    switch (isEqualRgx(regex[idx1 - 1], normal[idx2 - 1], matchIdx, idx2 - 1))
                    {
                        case -1: // not equal
                            cur[idx2] = 0 + Math.Max(cur[idx2 - 1], prev[idx2]);
                            break;
                        case 0: // equal & not optional
                            cur[idx2] = 1 + prev[idx2 - 1];
                            matchIdx.Add(idx2 - 1);
                            break;
                        case 1:
                            cur[idx2] = 1 + prev[idx2];
                            matchIdx.Add(idx2 - 1);
                            break;
                    }
                }
                prev = copyListInt(cur);
            }
            return cur[m];
        }

        static void Main()
        {
            string strs = "aBnxx man da best";
            string[] rgx = Regex.StrToRgx(strs.ToLower());
            Console.WriteLine(rgx);
            string[] str = { "b", "n", "4", " ", "m", "a", "n", " ", "d", "a", " ", "b", "e", "s", "t" };
            Console.WriteLine(LCS.LongestCommonSubsequence(rgx, str));
            //for (var i = 0; i < strs.Length; i++)
            //{
            //    Console.WriteLine(Regex.StrToRgx(strs.ToLower())[i]);
            //}
        }
    }

    class Regex
    {
        private static Dictionary <string, string> dict =
            new Dictionary<string, string>(){
                                {"a", "((a|4)?)"},
                                {"b", "(b|8)"},
                                //{"d", "((d|17)"},
                                {"e", "((e|3)?)"},
                                {"g", "(g|6)"},
                                {"i", "((i|1)?)"},
                                {"o", "((o|0)?)"},
                                //{"r", "(r|12)"},
                                {"s", "(s|5)"},
                                {"t", "(t|7)"},
                                {"u", "((u)?)"},
                                {"z", "(z|2)"} };
        public static string[] StrToRgx(string str)
        {
            string[] newStr = new string[str.Length];
            for (var i = 0; i < str.Length; i++)
            {
                string value;
                try
                {
                    value = dict[str[i].ToString()];
                }
                catch (KeyNotFoundException _)
                {
                    value = str[i].ToString();
                }
                newStr[i] = value;
            }
            return newStr;
        }

        //static void Main()
        //{
        //    string strs = "Bana man da best";
        //    for (var i = 0; i <strs.Length; i++)
        //    {
        //        Console.WriteLine(StrToRgx(strs.ToLower())[i]);
        //    }
        //}
    }
}
