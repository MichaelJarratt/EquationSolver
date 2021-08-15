using EquationSolver.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver.Tokens
{
    public static class Tokeniser
    {
        private static Config config = Config.getInstance();

        public static TokenString tokenise(string line)
        {
            TokenString tokenString = new TokenString(); //collection of Tokens
            //crawl over line and build tokens to place in TokenString
            //use config.operators to identify operators, assume numbers are operands

            char symbol;
            bool negativeNoMemory = false; 
            int firstNo = -1; //index of a number is marked so that multiple numerical characters can be taken as a substring and converted to a token
            for (int i = 0; i < line.Length; i++)
            {
                symbol = line[i];
                if(isNumber(symbol)) //numbers
                {
                    if(firstNo == -1) //first number in this sequece ("25+35" firstNo will be both 2 or 3)
                    {
                        firstNo = i; //mark the index of the first number
                    }
                    if(i == line.Length-1) //if this is the last symbol in the list
                    {
                        string operand = line.Substring(firstNo, (i+1) - firstNo);
                        firstNo = -1;
                        if(negativeNoMemory) //the number is negative
                        {
                            operand = "-" + operand;
                            negativeNoMemory = false;
                        }
                        tokenString.add(new Token(TokenType.Operand, operand));
                    }
                    else if(!isNumber(line[i + 1])) //if the next symbol is not also a number
                    {
                        string operand = line.Substring(firstNo, (i+1) - firstNo);
                        firstNo = -1;
                        if (negativeNoMemory) //the number is negative
                        {
                            operand = "-" + operand;
                            negativeNoMemory = false;
                        }
                        tokenString.add(new Token(TokenType.Operand, operand));
                    }
                }
                else //none numbers
                {
                    if (config.operators.Contains(symbol.ToString())) //if it is a valid operator
                    {
                        //if the symbol is - and the previous character is not a number, or does not exist (meaning its a negative number)
                        if (symbol == '-' && (i == 0 || (i > 0 && !isNumber(line[i - 1])))) //unary operator
                        {
                            negativeNoMemory = true;
                        }
                        else //binary operator
                        {
                            if (symbol == '(' || symbol == ')') //if the symbol is a bracket
                            {
                                tokenString.add(new Token(TokenType.Bracket, symbol.ToString()));
                            }
                            else
                            {
                                tokenString.add(new Token(TokenType.Operator, symbol.ToString()));
                            }
                        }
                    }
                    else
                    {
                        throw new Exception($"Unrecognised Operator \"{symbol}\"");
                    }
                }
            }
            //char[] configs = new char[] { '+', '-', '/', '*' };
            //String[] substrings = line.Split(configs);

            return tokenString;
        }

        /// <summary>
        /// Determine is a syombol is a number
        /// </summary>
        /// <param name="symbol">Bool is number</param>
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
    }
}
