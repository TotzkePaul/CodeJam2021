using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam2021
{
    public class Problem1
    {
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

            int[] map = new int[n];
            for (int i = 0; i < list.Length; i++)
            {
                map[list[i] - 1] = i;
            }

            for (int i = 0; i < list.Length - 1; i++)
            {
                int j = map[i];

                int d = (j - i + 1) / 2;
                for (int k = 0; k < d; k++)
                {
                    //Non-mono: (list[i+k], list[j-k]) = (list[j - k], list[i + k]);
                    list[j - k] ^= list[i + k];
                    list[i + k] ^= list[j - k];
                    list[j - k] ^= list[i + k];

                    map[list[i + k] - 1] = i + k;
                    map[list[j - k] - 1] = j - k;
                }

                cost += j - i + 1;
            }

            return $"{cost}";
        }
    }
}
