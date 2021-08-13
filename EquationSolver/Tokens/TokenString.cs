using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver.Tokens
{
    //this class is a collection of tokens that can be iterated over
    public class TokenString
    {
        private List<Token> tokens = new List<Token>();

        public int index = 0; //this is the current token for iteration

        /// <summary>
        /// Add token to TokenString
        /// </summary>
        /// <param name="token"></param>
        public void add(Token token)
        {
            tokens.Add(token);
        }

        /// <summary>
        /// returns the token at supplied index
        /// </summary>
        /// <param name="index">idex of desired token</param>
        /// <returns>token at index</returns>
        public Token tokenAt(int index)
        {
            return tokens[index];
        }

        /// <summary>
        /// Returns [bool] if there is another token
        /// </summary>
        /// <returns>Next Token</returns>
        public bool hasNext()
        {
            if(index != tokens.Count-1) //if there are 5 tokens and the index is 4 (5th element) then there are no more tokens
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns [bool] if there is a previous token
        /// </summary>
        /// <returns>Previous Token</returns>
        public bool hasPrevious()
        {
            if(index > 0) //if index is 1 or more then there is at least one previous Token
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the next Token in the TokenString.
        /// Make sure to use HasNext before calling this.
        /// </summary>
        /// <returns>Next Token in the TokenString</returns>
        public Token next()
        {
            index++;
            return tokens[index];
        }

        /// <summary>
        /// Returns the previous Token in the TokenString.
        /// Make sure to use HasPrevious before calling this.
        /// </summary>
        /// <returns>Previous Token in the TokenString</returns>
        public Token previous()
        {
            index--;
            return tokens[index];
        }

        public List<Token> TokensBetween(int index)
        {
            return TokensBetween(index, this.index); //tokens between supplied index and current TokenString index
        }

        public List<Token> TokensBetween(int index1, int index2)
        {
            throw new NotImplementedException();
        }

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Token token in tokens)
            {
                sb.Append(token.value);
            }
            return sb.ToString();
        }
    }
}
