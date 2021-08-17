using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver.Tokens
{
    public class OperandToken : Token
    {
        public double operandValue;
        public OperandToken(String value) : base(value)
        {
            try
            {
                operandValue = double.Parse(value);
            }
            catch (FormatException e)
            {
                throw new Exception("Non-number recognised as an operand", e);
            }
        }
    }
}
