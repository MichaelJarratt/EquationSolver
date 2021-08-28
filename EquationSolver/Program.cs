using System;
using EquationSolver.Tokens;

namespace EquationSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Config config = Config.getInstance();

            TokenString ts = Tokeniser.tokenise("(1+2))");

            ValidationInstance valInstance = EqValidator.isValid(ts);

            Decimal d = EqSolve.solveEquation("test_constant_A-test_constant_B");

            Console.WriteLine(d);
        }
    }
}
