using EquationSolver.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EquationSolver.Tokens
{
    public static class Tokeniser
    {
        private static Config config = Config.getInstance();

        public static TokenString tokenise(string line)
        {
            line = Regex.Replace(line, @"\s+", ""); //replace any whitespace with nothing

            TokenString tokenString = new TokenString(); //collection of Tokens
            //crawl over line and build tokens to place in TokenString
            //use config.operators to identify operators, assume numbers are operands

            char symbol;
            bool negativeNoMemory = false; 
            int firstNo = -1; //index of a number is marked so that multiple numerical characters can be taken as a substring and converted to a token
            int firstChar = -1;
            for (int i = 0; i < line.Length; i++)
            {
                symbol = line[i];
                bool lastSymbol = (i == line.Length - 1);

                if (isNumber(symbol)) //numbers
                {
                    if (firstNo == -1) //first number in this sequece ("25+35" firstNo will be both 2 or 3)
                    {
                        firstNo = i; //mark the index of the first number
                    }
                    //if it's the last symbol OR the next symbol is not a number AND not '.'
                    if(lastSymbol || (!lastSymbol && (!isNumber(line[i + 1]) && line[i + 1] != '.')))
                    {
                        string operand = line.Substring(firstNo, (i+1) - firstNo);
                        firstNo = -1;
                        if (negativeNoMemory) //the number is negative
                        {
                            operand = "-" + operand;
                            negativeNoMemory = false;
                        }
                        tokenString.add(new OperandToken(operand));
                    }
                }
                else //non-numbers
                {
                    if (isOperator(symbol)) //if it is a valid operator
                    {
                        //if the symbol is - and the previous character is an operator, not ')', or does not exist (meaning its a negative number)
                        if (symbol == '-' && (i == 0 || (i > 0 && isOperator(line[i - 1]) && line[i - 1] != ')'))) //unary operator
                        {
                            negativeNoMemory = true;
                        }
                        else //binary operator/brackets
                        {
                            tokenString.add(new OperatorToken(symbol.ToString()));
                        }
                    }
                    else if(symbol != '.') //if it's anything other than .
                    {
                        if (firstChar == -1) //first character in this sequece ("Const+Ant" firstChar will be both C or A)
                        {
                            firstChar = i; //mark the index of the first character
                        }
                        //if it's the last symbol OR the next symbol is a number OR operator
                        if (lastSymbol || !lastSymbol && (isNumber(line[i + 1]) || isOperator(line[i + 1])))
                        {
                            string constant = line.Substring(firstChar, (i + 1) - firstChar);
                            firstChar = -1;

                            decimal operand;
                            if(config.constants.TryGetValue(constant, out operand))
                            {
                                tokenString.add(new ConstantToken(operand, constant));
                            }
                            else
                            {
                                throw new Exception($"Unrecognised constant \\{constant}\\");
                            }
                        }
                        //throw new Exception($"Unrecognised Operator \"{symbol}\"");
                    }
                }
            }
            //char[] configs = new char[] { '+', '-', '/', '*' };
            //String[] substrings = line.Split(configs);

            return tokenString;
        }

        /// <summary>
        /// Determine is a symbol is a number
        /// </summary>
        /// <param name="symbol">Character to check</param>
        /// <returns>Bool is number</returns>
        private static bool isNumber(Char symbol)
        {
            if(Char.GetNumericValue(symbol) != -1) //non-numbers return -1
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Determine is a symbol is an operator
        /// </summary>
        /// <param name="symbol">Character to check</param>
        /// <returns>Bool is operator</returns>
        private static bool isOperator(Char symbol)
        {
            return config.operators.Contains(symbol.ToString());
        }
    }
}
