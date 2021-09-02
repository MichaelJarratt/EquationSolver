using EquationSolver.Operations;
using EquationSolver.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver.Validation
{
    //this class Takes an equation and validates it.
    public static class EqValidator
    {

        private static ValidationInstance valInstance; //this is a field so that it does not have to be passed around to methods

        /// <summary>
        /// Takes an equation in TokenString format and validates it.
        /// Returns a ValidationInstance with a flag and any validation failures
        /// </summary>
        /// <param name="equation">Equation to validate</param>
        /// <returns>ValidationInstance with a flag and any validation failures</returns>
        public static ValidationInstance isValid(TokenString equation)
        {
            int openBrackets = 0, closedBrackets = 0;
            Token token;
            OperatorToken operatorToken;
            OperandToken operandToken;
            ConstantToken constantToken;

            valInstance = new ValidationInstance();

            while(equation.hasNext()) //iterate over every token
            {
                token = equation.next();
                bool validToken = true;

                if(token is OperatorToken)
                {
                    operatorToken = (OperatorToken)token;
                    if(operatorToken.operationType == OperationType.OpenBracket)
                    {
                        openBrackets++;
                    }
                    else if(operatorToken.operationType == OperationType.ClosedBracket)
                    {
                        closedBrackets++;
                    }
                    else //must be binary operator
                    {
                        //if it is the first or last character
                        if (!equation.hasPrevious() || !equation.hasNext())
                        {
                            addOffence(token);
                        }
                        else
                        {
                            //check for operands on the left
                            if (equation.hasPrevious())
                            {
                                int currentIndex = equation.index; //store reference so it can be restored later
                                validToken = false; //false by default, search for a token that makes the operator valid
                                Token previous;
                                while (equation.hasPrevious() && !validToken)
                                {
                                    previous = equation.previous();
                                    //if there's an operand to the left of the operator, the operator is valid
                                    if (previous is OperandToken)
                                    {
                                        validToken = true;
                                    }
                                    //if it's any operator besides ')' the current operator cannot be valid
                                    else if (!(((OperatorToken)previous).operationType == OperationType.ClosedBracket))
                                    {
                                        break; //break out of the while loop, no need to check further
                                    }
                                }
                                equation.index = currentIndex; //restore the index of the TokenString
                                if (!validToken)
                                {
                                    addOffence(token);
                                }
                            }
                            //check for operands on the right (if it's already failed validation don't bother checking)
                            if (equation.hasNext() && validToken)
                            {
                                int currentIndex = equation.index; //store reference so it can be restored later
                                validToken = false; //false by default, search for a token that makes the operator valid
                                Token next;
                                while (equation.hasNext() && !validToken)
                                {
                                    next = equation.next();
                                    //if there's an operand to the left of the operator, the operator is valid
                                    if (next is OperandToken)
                                    {
                                        validToken = true;
                                    }
                                    //if it's any operator besides '(' the current operator cannot be valid
                                    else if (!(((OperatorToken)next).operationType == OperationType.OpenBracket))
                                    {
                                        break; //break out of the while loop, no need to check further
                                    }
                                }
                                equation.index = currentIndex; //restore the index of the TokenString
                                if (!validToken)
                                {
                                    addOffence(token);
                                }
                            }
                            validToken = true; //reset flag
                        }

                    }
                }
                else //must be Operand (or constant subclass)
                {
                    operandToken = (OperandToken)token;
                    if(equation.hasPrevious() && equation.peakPrevious() is OperandToken) //if the previous token is also an operand
                    {
                        validToken = false;
                    }
                    else if(equation.hasNext() && equation.peakNext() is OperandToken) //if the next token is also an operand
                    {
                        validToken = false;
                    }

                    if(!validToken) //token is invalid, add offence
                    {
                        addOffence(token);
                        validToken = true;
                    }
                }

            }

            if (openBrackets > closedBrackets) //search for the offending bracket/s
            {
                Stack<Token> openBracketStack = new Stack<Token>();
                equation.index = 0;
                //iterate over TokenString from left to right
                while(equation.hasNext())
                {
                    token = equation.next();
                    if(token is OperatorToken)
                    {
                        operatorToken = (OperatorToken)token;
                        if (operatorToken.operationType == OperationType.OpenBracket) //push open brackets to stack
                        {
                            openBracketStack.Push(token);
                        }
                        else if (operatorToken.operationType == OperationType.ClosedBracket) //pop them when a closing pair is found
                        {
                            openBracketStack.Pop();
                        }
                    }
                }
                //every open bracket left in the stack is unpaired
                while(openBracketStack.Count > 0)
                {
                    token = openBracketStack.Pop();
                    addOffence(token);
                }

                //addOffence("Uncoupled Open bracket.");
            }
            //iterate right to left for closed brackets
            else if (closedBrackets > openBrackets)
            {
                Stack<Token> closedBracketStack = new Stack<Token>();
                equation.setToEnd(); //goes to last index

                while (equation.hasPrevious())
                {
                    token = equation.previous();
                    if (token is OperatorToken)
                    {
                        operatorToken = (OperatorToken)token;
                        if (operatorToken.operationType == OperationType.ClosedBracket) //push closed brackets to stack
                        {
                            closedBracketStack.Push(token);
                        }
                        else if (operatorToken.operationType == OperationType.OpenBracket) //pop them when an opening pair is found
                        {
                            closedBracketStack.Pop();
                        }
                    }
                }
                while(closedBracketStack.Count > 0)
                {
                    token = closedBracketStack.Pop();
                    addOffence(token);
                }
            }

            valInstance.orderCollection(); //orders offenced from first to last
            return valInstance;
        }

        /// <summary>
        /// Takes an equation in String format and validates it.
        /// Returns a ValidationInstance with a flag and any validation failures
        /// </summary>
        /// <param name="equation">Equation to validate</param>
        /// <returns>ValidationInstance with a flag and any validation failures</returns>
        public static ValidationInstance isValid(String equation)
        {
            return isValid(Tokeniser.tokenise(equation));
        }
        
        /// <summary>
        /// Takes a token and generates an error message with its details
        /// </summary>
        /// <param name="token">Offending token</param>
        /// <returns>Generated Error message</returns>
        private static string createMessage(Token token)
        {
            string value;
            string error = "not valid";

            if (token is ConstantToken)
            {
                ConstantToken ct = (ConstantToken)token;
                value = $"'{ct.constant}' ({ct.operandValue})";
            }
            else if(token is OperandToken)
            {
                value = $"'{token.value}'";
            }
            else if(token is OperatorToken)
            {
                OperatorToken ot = (OperatorToken)token;
                if(ot.operationType == OperationType.OpenBracket)
                {
                    error = "unclosed";
                }
                else if(ot.operationType == OperationType.ClosedBracket)
                {
                    error = "never opened";
                }
                value = token.value;
            }
            else
            {
                throw new Exception("Unsupported Token type");
            }

            return $"{value} at position {token.position} is {error}";
        }

        /// <summary>
        /// Adds a validationObject with the token to the list of offences.
        /// The ValidationObject message is generated from the token type.
        /// </summary>
        /// <param name="token">Offending token</param>
        private static void addOffence(Token token)
        {
            addOffence(createMessage(token), token);
        }

        /// <summary>
        /// Adds a ValidationObject without the token to the list of offences.
        /// </summary>
        /// <param name="message">Related message</param>
        private static void addOffence(String message)
        {
            valInstance.addOffence(new ValidationObject(message));
        }

        /// <summary>
        /// Adds a ValidationObject with the token to the list of offences.
        /// </summary>
        /// <param name="message">Related message</param>
        /// <param name="token">Offending token</param>
        private static void addOffence(String message, Token token)
        {
            valInstance.addOffence(new ValidationObject(message, token));
        }
    }
}
