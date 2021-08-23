using System;
using EquationSolver.Tokens;

namespace EquationSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Config config = Config.getInstance();

            TokenString ts = Tokeniser.tokenise("test_constant_A-test_constant_B");

            Decimal d = EqSolve.solveEquation("test_constant_A-test_constant_B");

            Console.WriteLine(d);
        }
    }
}
