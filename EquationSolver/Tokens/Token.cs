using System;
using System.Collections.Generic;
using System.Text;
using EquationSolver.Operations;

namespace EquationSolver.Tokens
{
    //tokens represent parts of an equation, such as numbers and operators
    public abstract class Token
    {
        public string value;

        public Token(String value)
        {
            this.value = value;
        }

    }
}
