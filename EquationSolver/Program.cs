using System;
using EquationSolver.Tokens;

namespace EquationSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Config config = Config.getInstance();

            TokenString ts = Tokeniser.tokenise("(-2+12)*3");

            String s = ts.toString();
        }
    }
}
