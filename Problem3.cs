using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeJam2021
{
    public class Problem3
    {
        public static void Solve(Func<int, int, string> problem, TextReader reader, TextWriter writer)
        {
            int cntCases = int.Parse(reader.ReadLine());
            for (int i = 1; i <= cntCases; ++i)
            {
                string[] args = reader.ReadLine().Split(' ');
                int n = int.Parse(args[0]);

                int m = int.Parse(args[1]);

                string answer = problem(n, m);

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
        public static string ReversortEngineering(int n, int cost)
        {
            var error = "IMPOSSIBLE";

            int[] example = Enumerable.Range(1, n).ToArray();
            int min = n - 1;
            int max = (n * n + 3 * n) / 2;

            if (cost < min || cost > max)
            {
                return $"{error}";
            }

            int[] budget = Enumerable.Repeat(1, n - 1).ToArray();
            int current = cost - (n - 1);
            for (int i = 0; i < budget.Length; i++)
            {
                int mine = Math.Min(current, budget.Length - 1 - i);
                current -= mine;
                budget[i] += mine;
            }

            for (int i = 0; i < budget.Length; i++)
            {
                int d = budget[i];
                int j = i + d;
                for (int k = 0; k < d; k++)
                {
                    //Non-mono: (list[i+k], list[j-k]) = (list[j - k], list[i + k]);
                    example[j - k] ^= example[i + k];
                    example[i + k] ^= example[j - k];
                    example[j - k] ^= example[i + k];
                }
            }

            return string.Join(' ', example);
        }
    }
}
