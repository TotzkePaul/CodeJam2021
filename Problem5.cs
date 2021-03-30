using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeJam2021
{
    public class Problem5
    {
        public static void Solve(Func<bool[][], int, string> problem, TextReader reader, TextWriter writer)
        {
            int T = int.Parse(reader.ReadLine());
            for (int i = 1; i <= T; ++i)
            {
                int P = int.Parse(reader.ReadLine());

                bool[][] m = new bool[100][];

                for (int j = 0; j < m.Length; j++)
                {
                    string line = reader.ReadLine();
                    var answers = line.ToList().Select(character => character == '1').ToArray();
                    m[j] = answers;
                }

                string answer = problem(m, P);

                writer.WriteLine("Case #{0}: {1}", i, answer);
                writer.Flush();
            }
            writer.Close();
            reader.Close();
        }


        public static string CheatingDetection(bool[][] m, int p)
        {
            var cheater = 0;
            double[] skill = new double[m.Length];
            double[] expected = new double[m.Length];

            for (int i = 0; i < m.Length; i++)
            {
                var S_i = -3.0 + 6 * (i / 100.0);
                for (int j = 0; j < m[i].Length; j++)
                {
                    var Q_j = -3.0 + 6 * (j / 10000.0);

                    var probability = Sigmoid(S_i - Q_j);
                    expected[i] += probability;
                    if (m[i][j])
                        skill[i] += probability;
                }
                if (skill[cheater] / expected[cheater] < skill[i] / expected[i])
                    cheater = i;
            }

            return $"{cheater + 1}";
        }
        public static double Sigmoid(double x)
        {
            double S = 1.0 / (1.0 + Math.Exp(-x));

            return S;
        }
    }


}
