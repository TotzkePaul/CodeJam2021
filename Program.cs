using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class CodeJam2021
{
    public static void Main(string[] args)
    {
        Solve(Reversort, new StreamReader($"{nameof(Reversort)}.in"), new StreamWriter($"{nameof(Reversort)}.out"));
        //Solve(Vestigium, System.Console.In, System.Console.Out);
    }
    public static void Solve(Func<int[], int, string> problem, TextReader reader, TextWriter writer)
    {
        int cntCases = int.Parse(reader.ReadLine());
        for (int i = 1; i <= cntCases; ++i)
        {
            int n = int.Parse(reader.ReadLine());

            int[] m = new int[n];

            string[] args = reader.ReadLine().Split(' ');

            for (int j = 0; j < n; j++)
            {
                m[j] = int.Parse(args[j]);                
            }

            string answer = problem(m, n);

            writer.WriteLine("Case #{0}: {1}", i, answer);
            writer.Flush();
        }
        writer.Close();
        reader.Close();
    }

    /**
     * Reversort(L):
     *   for i := 1 to length(L) - 1
     *       j := position with the minimum value in L between i and length(L), inclusive
     *           Reverse(L[i..j])           
     */
    public static string Reversort(int[] list, int n)
    {
        int cost = 0;
        
        for(int i = 0; i < list.Length-1; i++)
        {
            int min = list[i];
            int j = i;
            for (int k = i+1; k < list.Length; k++)
            {
                min = Math.Min(min, list[k]);
                j = (min == list[k]) ? k : j;
            }

            int d = (j - i) / 2;
            for(int k = 0; k < d; k++)
            {
                (list[i+k], list[j-k]) = (list[j - k], list[i + k]);
            }

            cost += j - i + 1;
        }

        return $"{cost}";
    }
}
