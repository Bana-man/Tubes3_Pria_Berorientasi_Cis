using System;

class Program
{
    static int LongestCommonSubsequence(string text1, string text2)
    {
        int n = text1.Length;
        int m = text2.Length;
        
        int[] prev = new int[m + 1];
        int[] cur = new int[m + 1];
        for (int idx2 = 0; idx2 < m + 1; idx2++)
            cur[idx2] = 0;
        for (int idx1 = 1; idx1 < n + 1; idx1++)
        {
            for (int idx2 = 1; idx2 < m + 1; idx2++)
            {
                // if matching
                if (text1[idx1 - 1] == text2[idx2 - 1])
                    cur[idx2] = 1 + prev[idx2 - 1];
                // not matching
                else
                    cur[idx2] = 0 + Math.Max(cur[idx2 - 1], prev[idx2]);
            }
            prev = cur;
        }
 
        return cur[m];
    }
    static void Main()
    {
        string S1 = "AGGTAB";
        string S2 = "GXTXAYB";
        // Function call
        Console.WriteLine("Length of LCS is " + LongestCommonSubsequence(S1, S2));
    }
}
