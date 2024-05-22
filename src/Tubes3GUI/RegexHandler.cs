using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StringHandler
{
    class LCS
    {
        static List<int> copyListInt(List<int> list)
        {
            List<int> newList = new List<int>(list.Count);
            for (var i = 0; i < list.Count; i++)
            {
                newList.Add(list[i]);
            }
            return newList;
        }
        public static int LongestCommonSubsequence(string[] regex, string[] normal)
        {
            List<int> matchIdx;
            List<int> prevMatchIdx = new List<int>(); prevMatchIdx.Add(0);
            int n = regex.Length;
            int m = normal.Length;
            // initializing 2 arrays of size m
            List<int> cur = new List<int>(m + 1) { };
            List<int> prev = new List<int>(m + 1) { };
            for (int idx2 = 0; idx2 < m + 1; idx2++) { cur.Add(0); prev.Add(0); }

            for (int idx1 = 1; idx1 < n + 1; idx1++)
            {
                matchIdx = new List<int>();
                for (int idx2 = 1; idx2 < m + 1; idx2++)
                {
                    switch (RegexPnySendiri.isEqualRgx(regex[idx1 - 1], normal[idx2 - 1]))
                    {
                        case -1: // not equal
                            cur[idx2] = Math.Max(cur[idx2 - 1], prev[idx2]);
                            break;
                        case 1:
                        case -2:
                            if (prevMatchIdx.Contains(0)) // case vokal diawal
                            {
                                cur[0] = 1 + prev[0]; cur[1] = 1 + prev[1];
                                matchIdx.Add(0);
                                prevMatchIdx.Remove(0);
                            }
                            if (prevMatchIdx.Contains(idx2)) // equal & optional
                            {
                                cur[idx2] = 1 + prev[idx2];
                                matchIdx.Add(idx2);
                            }
                            else
                            {
                                cur[idx2] = Math.Max(cur[idx2 - 1], prev[idx2]);
                            }
                            break;
                        case 0: // equal & not optional
                            cur[idx2] = 1 + prev[idx2 - 1];
                            matchIdx.Add(idx2);
                            break;
                    }
                }
                if (matchIdx.Count != 0) { prevMatchIdx = copyListInt(matchIdx); }
                prev = copyListInt(cur);
            }
            return cur[m];
        }

        //static void Main()
        //{
        //    string strs = "acaaBnxx man da best";
        //    string[] rgx = RegexPnySendiri.strToRgx(strs.ToLower());
        //    Console.WriteLine(rgx);
        //    string[] str = { "b", "n", "4", " ", "m", "x", "n", " ", "d", "a", " ", "b", "e", "s", "t" };
        //    Console.WriteLine(LCS.LongestCommonSubsequence(rgx, str));
        //}
    }

    class BoyerMoore
    {
        private static int[] buildLast(String[] pattern)
        {
            int[] last = new int[257]; // ASCII char set || 128 for optional char
            for (int i = 0; i < 257; i++)
                last[i] = -1; // initialize array
            for (int i = 0; i < pattern.Length; i++)
                if (RegexPnySendiri.isOptional(pattern[i])) { last[257] = i; } // !!!Belum cek optionalitas
                else { last[pattern[i][0]] = i; }
            return last;
        }
        public static int BMMatch(String[] text, String[] pattern)
        {
            Console.WriteLine(pattern.Length);
            int[] last = buildLast(pattern);
            int n = text.Length;
            int m = pattern.Length;
            int i = 0;

            int j = m - 1;
            while (i <= n - 1)
            {
                if (RegexPnySendiri.isEqualRgx(pattern[j], text[i]) >= 0) // equal
                {
                    if (j == 0)
                        return i; // match
                    else
                    { // looking-glass technique
                        if (i == 0) { i = i + m - j; j = m - 1; }
                        else { j--; i--; }
                    }
                }
                else
                { // character jump technique
                    if (RegexPnySendiri.isOptional(pattern[j])) { j--; }
                    else
                    {
                        int lo = Math.Max(last[text[i][0]], last[128]); //last occ
                        i = i + m - Math.Min(j, 1 + lo);
                        j = m - 1;
                    }
                }
            };
            return -1; // no match
        }
        //static void Main()
        //{
        //    Console.WriteLine(BMMatch(RegexPnySendiri.strToList("ascnwivc5jav14hbdf"), RegexPnySendiri.strToRgx("csjaeviah")));
        //    Console.ReadLine();
        //}
    }
    class kmp
    {
        public static int kmpmatch(string text, string pattern)
        {
            int[] b = computeborderfunction(pattern);
            int i = 0, j = 0;

            string[] regex = RegexPnySendiri.strToRgx(pattern);
            string[] textarr = RegexPnySendiri.strToList(text);

            while (i < text.Length)
            {
                if (RegexPnySendiri.isEqualRgx(regex[j], textarr[i]) >= 0)   // char equal
                {
                    if (j == pattern.Length - 1)
                        return i - j + 1;

                    i++; j++;
                }
                else if (RegexPnySendiri.isOptional(regex[j]))
                {
                    j++;
                }
                else if (j > 0)
                {
                    j = b[j];
                }
                else
                {
                    i++;
                }
            }

            return -1;
        }

        public static int[] computeborderfunction(string pattern)
        {
            int length = pattern.Length;
            int[] b = new int[length];
            int i = 0;
            for (i = 0; i < length; i++)  // initialize border array
            {
                b[i] = 0;
            }

            int j = 0; i = 1;
            while (i < length)
            {
                if (pattern[i] == pattern[j])
                {
                    j++;
                    b[i] = j;
                    i++;
                }
                else if (j > 0)
                {
                    j = b[j - 1];
                }
                else
                {
                    i++;
                }
            }

            return b;
        }

        //static void Main()
        //{
        //    Console.WriteLine(kmpmatch("ascnwivc5jav14hbdf", "csjaeviah"));
        //    Console.ReadLine();
        //}
    }

    class RegexPnySendiri
    {
        private static Dictionary<string, string> dict =
            new Dictionary<string, string>(){
                                {"a", "((a|4)?)"},
                                {"b", "(b|8)"},
                                {"d", "((d|17)"},
                                {"e", "((e|3)?)"},
                                {"g", "(g|6)"},
                                {"i", "((i|1)?)"},
                                {"o", "((o|0)?)"},
                                {"r", "(r|12)"},
                                {"s", "(s|5)"},
                                {"t", "(t|7)"},
                                {"u", "((u)?)"},
                                {"z", "(z|2)"} };
        public static string[] strToRgx(string str)
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

        public static bool isOptional(string str)
        {
            if (str.Length == 1) return false;
            if (str[str.Length - 2] == '?') return true;
            return false;
        }

        public static string[] strToList(string str)
        {
            string[] strings = new string[str.Length];
            for (var i = 0; i < str.Length; i++)
            {
                strings[i] = str[i].ToString();
            }
            return strings;
        }

        public static (string[], bool) parseRegex(string str)
        {
            bool isOptional = false;
            if (str.Length > 1) { str = str.Substring(1, str.Length - 2); }
            if (str.Length > 1 && str[str.Length - 1] == '?') { isOptional = true; str = str.Substring(1, str.Length - 3); }

            string[] strings = str.Split('|');
            return (strings, isOptional);
        }

        public static int isEqualRgx(string regex, string normal) //
        {
            // if regex char optional
            var a = RegexPnySendiri.parseRegex(regex);
            if (a.Item2)
            {
                if (a.Item1.Contains(normal)) { return 1; } // equal

                return -2; // not equal
            }

            // if regex char not optional
            else
            {
                if (a.Item1.Contains(normal)) { return 0; } // equal

                return -1; // not equal
            }
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