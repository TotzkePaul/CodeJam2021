using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeJam2021
{
    public class CodeJam2021
    {
        public static void Main(string[] args)
        {
            int problem = 3;
            switch (problem)
            {
                case 1:
                    Problem1.Solve(Problem1.Reversort, new StreamReader($"{nameof(Problem1.Reversort)}.in"), new StreamWriter($"{nameof(Problem1.Reversort)}.out"));
                    break;
                case 3:
                    Problem3.Solve(Problem3.ReversortEngineering, new StreamReader($"{nameof(Problem3.ReversortEngineering)}.in"), new StreamWriter($"{nameof(Problem3.ReversortEngineering)}.out"));
                    break;
                case 5:
                    Problem5.Solve(Problem5.CheatingDetection, new StreamReader($"{nameof(Problem5.CheatingDetection)}.in"), new StreamWriter($"{nameof(Problem5.CheatingDetection)}.out"));
                    break;
            }
        }
    }
}