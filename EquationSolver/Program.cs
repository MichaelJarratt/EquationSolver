using System;
using EquationSolver.Tokens;

namespace EquationSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            double d = EquationSolver.solveEquation("(4*5)-4+6");

            Console.WriteLine(d);
        }
    }
}
