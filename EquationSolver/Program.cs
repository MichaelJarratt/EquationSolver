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

            Token t = ts.next();

            t = ts.next();

            ts.index = 6;

            bool b = ts.hasNext();

            t = ts.next();

            b = ts.hasNext();

            String s = ts.toString();
        }
    }
}
