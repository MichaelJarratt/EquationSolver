using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver.Tokens
{
    public class OperandToken : Token
    {
        public Decimal operandValue;

        /// <summary>
        /// Construct Token without a position using a string value.
        /// </summary>
        /// <param name="value">Value of the operand</param>
        public OperandToken(String value) : base(value)
        {
            construct(value);
        }

        /// <summary>
        /// Construct Token without a position using a decimal value.
        /// </summary>
        /// <param name="value">Value of the operand</param>
        public OperandToken(Decimal value): base (value.ToString())
        {
            construct(value);
        }

        /// <summary>
        /// Construct token with a position using a string value
        /// </summary>
        /// <param name="value">Value of the operand</param>
        /// <param name="position">Position of the token</param>
        public OperandToken(String value, int position): base(value, position)
        {
            construct(value);
        }
        /// <summary>
        /// Construct token with a position using a decimal value
        /// </summary>
        /// <param name="value">Value of the operand</param>
        /// <param name="position">Position of the token</param>
        public OperandToken(Decimal value, int position): base(value.ToString(),position)
        {
            construct(value);
        }

        /// <summary>
        /// common construction operations
        /// </summary>
        /// <param name="value"></param>
        private void construct(Decimal value)
        {
            operandValue = value;
        }

        /// <summary>
        /// Common construction operations
        /// </summary>
        /// <param name="value"></param>
        private void construct(String value)
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
    }
}
