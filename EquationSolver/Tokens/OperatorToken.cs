using System;
using System.Collections.Generic;
using System.Text;
using EquationSolver.Operations;

namespace EquationSolver.Tokens
{
    public class OperatorToken : Token
    {
        public OperationType operationType;

        /// <summary>
        /// construct a token without a position
        /// </summary>
        /// <param name="value"></param>
        public OperatorToken(String value) : base(value)
        {
            construct(value);
        }

        /// <summary>
        /// Construct Token with position.
        /// </summary>
        /// <param name="value">Value of the Token</param>
        /// <param name="position">Position of the Token</param>
        public OperatorToken(String value, int position) : base(value, position)
        {
            construct(value);
        }

        /// <summary>
        /// Common constructoin operations
        /// </summary>
        /// <param name="value"></param>
        private void construct(String value)
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
