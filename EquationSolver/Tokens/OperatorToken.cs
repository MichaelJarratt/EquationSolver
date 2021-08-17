using System;
using System.Collections.Generic;
using System.Text;
using EquationSolver.Operations;

namespace EquationSolver.Tokens
{
    public class OperatorToken : Token
    {
        public OperationType operationType;

        public OperatorToken(String value) : base(value)
        {
            if (value == "(")
            {
                operationType = OperationType.OpenBracket;
            }
            else if (value == ")")
            {
                operationType = OperationType.ClosedBracket;
            }
            else
            {
                operationType = Operators.getOperation(value);                
            }
        }
    }
}
