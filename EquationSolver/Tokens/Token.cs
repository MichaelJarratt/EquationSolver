using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver.Tokens
{
    //tokens represent parts of an equation, such as numbers and operators
    public class Token
    {
        public TokenType type;
        public string value;
        public double operandValue;

        public Token(TokenType type, String value)
        {
            this.type = type;
            this.value = value;

            if(type == TokenType.Operand)
            {
                try
                {
                    operandValue = double.Parse(value);
                }
                catch (Exception e)
                {
                    throw new Exception("None-number recognised as an operand",e);
                }
            }
        }
    }
}
