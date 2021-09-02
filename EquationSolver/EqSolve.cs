using System;
using System.Collections.Generic;
using System.Text;
using EquationSolver.Tokens;
using EquationSolver.Operations;
using EquationSolver.Validation;

namespace EquationSolver
{
    //Algorithm yoinked from: https://www.geeksforgeeks.org/expression-evaluation/
    public static class EqSolve
    {
        private static Stack<OperandToken> operandStack = new Stack<OperandToken>();
        private static Stack<OperatorToken> operatorStack = new Stack<OperatorToken>();

        /// <summary>
        /// Takes an equation in string format and validates and solves it.
        /// Returns a SolveResult object, which contains a success status and the result (if successful) or ValidationInstance(if not).
        /// </summary>
        /// <param name="equation">Equation to solve in string format</param>
        /// <returns></returns>
        public static SolveResult solveEquation(string equation)
        {
            TokenString tsEquation = Tokeniser.tokenise(equation); //tokenise once
            ValidationInstance valInstance = EqValidator.isValid(tsEquation);

            if(!valInstance.valid) //fails validation
            {
                return SolveResult.failed(valInstance);
            }
            else
            {
                decimal result = solveEquationInternal(tsEquation);
                return SolveResult.succeeded(result);
            }
        }

        /// <summary>
        /// Takes an equation in TokenString format and returns the calculated value.
        /// If validate = true will throw a ValidationException if validation fails.
        /// ValidationException contains a ValidationInstance, which will give the reasons it failed to validate.
        /// </summary>
        /// <param name="equation">Equation to solve</param>
        /// <param name="validate">Validate the equation before solving</param>
        /// <returns>Solution to equation</returns>
        public static Decimal solveEquation(TokenString equation, bool validate)
        {
            if(!validate)
            {
                return solveEquationInternal(equation);
            }
            else
            {
                ValidationInstance valInstance = EqValidator.isValid(equation);
                if (valInstance.valid)
                {
                    return solveEquationInternal(equation);
                }
                else
                {
                    throw new ValidationException("Equation failed to validate. Refer to the ValididationInstance to find out why.", valInstance);
                }
            }
        }

        /// <summary>
        /// Takes an equation in string format and returns the calculated value.
        /// If validate = true will throw a ValidationException if validation fails.
        /// ValidationException contains a ValidationInstance, which will give the reasons it failed to validate.
        /// </summary>
        /// <param name="equation">Equation to solve</param>
        /// <param name="validate">Validate the equation before solving</param>
        /// <returns>Solution to equation</returns>
        public static Decimal solveEquation(string equation, bool validate)
        {
            TokenString tsEquation = Tokeniser.tokenise(equation);
            return solveEquation(tsEquation, validate);
        }

        /// <summary>
        /// Takes an equation in a string format and returns the calculated result.
        /// Example of equation - (3*-5)+5-1
        /// </summary>
        /// <param name="equation">Equation to solve in string format</param>
        /// <returns>Solution of equation</returns>
        private static Decimal solveEquationInternal(string equation)
        {
            TokenString tokenString = Tokeniser.tokenise(equation);
            return solveEquationInternal(tokenString);
        }

        /// <summary>
        /// Takes an equation in a string format and returns the calculated result.
        /// Example of equation - (3*-5)+5-1
        /// </summary>
        /// <param name="equation">Equation to solve in TokenString format</param>
        /// <returns>Solution of equation</returns>
        private static Decimal solveEquationInternal(TokenString tokenString)
        {
            Token token; OperatorToken opToken; OperandToken operandToken; //allocations for current token
            tokenString.index = 0;

            while(tokenString.hasNext()) //pass through whole set of tokens
            {
                token = tokenString.next();
                if (token is OperandToken)
                {
                    operandStack.Push((OperandToken)token);
                }
                else if (token is OperatorToken)
                {
                    opToken = (OperatorToken)token; //cast token
                    // "("
                    if (opToken.operationType == OperationType.OpenBracket)
                    {
                        operatorStack.Push(opToken);
                    }
                    // ")" - calculate everything between the brackets
                    else if (opToken.operationType == OperationType.ClosedBracket)
                    {
                        //while top of the operator stack is not "("
                        while (operatorStack.Peek().operationType != OperationType.OpenBracket)
                        {
                            calculateTop();
                        }
                        operatorStack.Pop(); //pop and discard the "("
                    }
                    else //any operator besides a bracket
                    {
                        //while operator at the top of the stack has greater than or equal precedence than current operator
                        while (operatorStack.Count > 0 && operatorStack.Peek().operationType >= opToken.operationType)
                        {
                            //solve the operator
                            calculateTop();
                        }
                        operatorStack.Push(opToken);
                    }
                }
                else
                {
                    throw new Exception("Unrecognised Token type");
                }
                
            }
            //now that brackets have been solved and the stacks have been filled, just work through the rest of the operations
            while(operatorStack.Count > 0) //while there are still operators
            {
                //calculate operands and operations
                calculateTop();
            }

            if(operandStack.Count != 1) //should only be one operand left on the stack
            {
                throw new Exception("Unidentified calculation error");
            }
            return operandStack.Pop().operandValue; //return result
        }

        /// <summary>
        /// Performs the top operation in the operatorStack on the top two operands of the operandStack.
        /// Result is pushed to the operandStack in an OperandToken
        /// </summary>
        private static void calculateTop()
        {
            OperandToken operandToken = operandStack.Pop();
            //do calculation
            Decimal sum = calculate(operandStack.Pop().operandValue, operatorStack.Pop().operationType, operandToken.operandValue);
            operandStack.Push(new OperandToken(sum)); //push value back on to operand stack
        }

        /// <summary>
        /// Takes an operation and two values and performs the calculation.
        /// For unary operators, the value of opB does not matter
        /// </summary>
        /// <param name="opA">The first operand</param>
        /// <param name="operation">The Operation to be performed</param>
        /// <param name="opB">The second operand, value does not matter for unary operations</param>
        /// <returns>Calculated Value</returns>
        private static Decimal calculate(Decimal opA, OperationType operation, Decimal opB)
        {
            return calculate(operation, opA, opB);
        }

        /// <summary>
        /// Takes an operation and two values and performs the calculation.
        /// For unary operators, the value of opB does not matter
        /// </summary>
        /// <param name="operation">Operation to be performed.</param>
        /// <param name="opA">The first operand</param>
        /// <param name="opB">The second operand, value does not matter for unary operations</param>
        /// <returns>Calculated value</returns>
        private static Decimal calculate(OperationType operation, Decimal opA, Decimal opB)
        {
            switch (operation)
            {
                case OperationType.Exponent:
                    //the alternative is to download a user library to use decimals, I'll just take the loss of precision
                    return (Decimal)Math.Pow((double)opA, (double)opB);
                case OperationType.Division:
                    return opA / opB;
                case OperationType.Multiplication:
                    return opA * opB;
                case OperationType.Addition:
                    return opA + opB;
                case OperationType.Subtraction:
                    return opA - opB;
                default:
                    throw new Exception($"Invalid Operation {operation}");
            }
        }
    }
}
