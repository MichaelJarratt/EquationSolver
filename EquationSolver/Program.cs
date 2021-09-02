using System;
using EquationSolver.Tokens;
using EquationSolver.Validation;

namespace EquationSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            //Config config = Config.getInstance();


            ValidationInstance valInstance = EqValidator.isValid(")/(1+2+*^))");

            Decimal d = EqSolve.solveEquation("test_constant_A-test_constant_B");

            Console.WriteLine(d);
        }
    }
}
