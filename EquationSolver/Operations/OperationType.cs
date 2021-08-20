using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver.Operations
{
    public enum OperationType
    {
        Exponent = 100,
        Division = 90,
        Multiplication = 80,
        Addition = 70,
        Subtraction = 60,
        OpenBracket = 49,
        ClosedBracket = 50
    }
}
