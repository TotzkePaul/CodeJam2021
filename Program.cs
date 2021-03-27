using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class CodeJam2021
{
    public static void Main(string[] args)
    {
        new CodeJam2021().Solve(Vestigium);
    }

    private void Solve(Func<int[][], int, string> problem)
    {
        int cntCases = int.Parse(Console.ReadLine());
        for (int i = 1; i <= cntCases; ++i)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] m = new int[n][];

            for (int j = 0; j < n; j++)
            {
                string[] args = Console.ReadLine().Split(' ');

                int[] row = new int[args.Length];
                for (int k = 0; k < row.Length; k++)
                {
                    row[k] = Int32.Parse(args[k]);
                }

                m[j] = row;
            }

            string answer = problem(m, n);

            Console.WriteLine("Case #{0}: {1}", i, answer);
        }
    }


    public static string Vestigium(int[][] m, int n)
    {
        int trace = 0;
        int r = 0; // rows w/ repeated elements
        int c = 0; // cols w/ repeated elements

        for (int i = 0; i < n; i++)
        {
            HashSet<int> r_seen = new HashSet<int>();
            HashSet<int> c_seen = new HashSet<int>();
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                {
                    trace += m[i][j];
                }

                r_seen.Add(m[i][j]);


                c_seen.Add(m[j][i]);

            }

            if (r_seen.Count != n)
            {
                r++;
            }

            if (c_seen.Count != n)
            {
                c++;
            }
        }


        return $"{trace} {r} {c}";
    }
}
