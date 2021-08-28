using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver.Tokens
{
    public class ConstantToken : OperandToken
    {
        public string constant;

        /// <summary>
        /// Construct Token without position
        /// </summary>
        /// <param name="value"></param>
        /// <param name="constant"></param>
        public ConstantToken(Decimal value, string constant) : base(value)
        {
            this.constant = constant;
        }

        /// <summary>
        /// COnstruct Token with position
        /// </summary>
        /// <param name="value"></param>
        /// <param name="constant"></param>
        /// <param name="position"></param>
        public ConstantToken(Decimal value, string constant, int position) : base(value,position)
        {
            this.constant = constant;
        }
    }
}
