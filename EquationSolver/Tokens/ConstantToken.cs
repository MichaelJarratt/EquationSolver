using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver.Tokens
{
    public class ConstantToken : OperandToken
    {
        string constant;
        public ConstantToken(Decimal value, string constant) : base(value)
        {
            this.constant = constant;
        }
    }
}
