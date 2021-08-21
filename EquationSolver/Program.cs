using System;
using EquationSolver.Tokens;

namespace EquationSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            TokenString ts = Tokeniser.tokenise("5+6");

            double d = EqSolve.solveEquation("50-20+2*100/5^2");

            Console.WriteLine(d);
        }
    }
}
