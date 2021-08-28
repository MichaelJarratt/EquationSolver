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
        public int position; //position within equation. For multi-character values the position is the index of the first character. position of the TOKEN can be identified by the TokenString collection

        /// <summary>
        /// Construct a token without a position
        /// </summary>
        /// <param name="value"></param>
        public Token(String value)
        {
            this.value = value;
        }
        
        /// <summary>
        /// Construct a token with a position
        /// </summary>
        /// <param name="value"></param>
        /// <param name="position"></param>
        public Token(String value, int position)
        {
            this.value = value;
            this.position = position;
        }

    }
}
