using System;
using EquationSolver.Tokens;

namespace EquationSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Config config = Config.getInstance();

            TokenString ts = Tokeniser.tokenise("5.6+4.4");

            Decimal d = EqSolve.solveEquation("5.6+4.4");

            Console.WriteLine(d);
        }
    }
}
