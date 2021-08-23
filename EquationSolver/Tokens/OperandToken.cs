using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver.Tokens
{
    public class OperandToken : Token
    {
        public Decimal operandValue;
        public OperandToken(String value) : base(value)
        {
            try
            {
                operandValue = Decimal.Parse(value);
            }
            catch (FormatException e)
            {
                throw new Exception("Non-number recognised as an operand", e);
            }
        }

        public OperandToken(Decimal value): base (value.ToString())
        {
            operandValue = value;
        }
    }
}
