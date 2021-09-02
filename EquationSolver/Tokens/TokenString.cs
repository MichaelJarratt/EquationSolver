using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver.Tokens
{
    /// <summary>
    /// This class is a collection of tokens that represent an equation. Methods are offered for traversing and manipulating
    /// its content.
    /// </summary>
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
            if(index < tokens.Count) //if there are 5 tokens and the index is 4 (5th element) then there are no more tokens
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
            if(index > 1) //if index is 2 or more then there is at least one previous Token (after calling first next, returned token is at 0, but index is post-incremented to 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the current token in the TokenString.
        /// </summary>
        /// <returns>Current token in the TokenString</returns>
        public Token current()
        {
            return tokens[index];
        }

        /// <summary>
        /// Returns the next token in TokenString but does not increment the index.
        /// </summary>
        /// <returns>Next token in TokenString</returns>
        public Token peakNext()
        {
            return tokens[index]; //current index because next post-increments index
        }

        /// <summary>
        /// Returns the previous token in TokenString but does not decrement the index.
        /// </summary>
        /// <returns>Previous token in TokenString</returns>
        public Token peakPrevious()
        {
            return tokens[index - 2]; //minus 2 because next post-increments index
        }

        /// <summary>
        /// Returns the next Token in the TokenString and increments the index.
        /// Make sure to use HasNext before calling this.
        /// </summary>
        /// <returns>Next Token in the TokenString</returns>
        public Token next()
        {
            return tokens[index++]; //returns index and then post-increments it
        }

        /// <summary>
        /// Returns the previous Token in the TokenString and decrements the index.
        /// Make sure to use HasPrevious before calling this.
        /// </summary>
        /// <returns>Previous Token in the TokenString</returns>
        public Token previous()
        {
            return tokens[--index-1];
        }

        /// <summary>
        /// Gets tokens at /index/
        /// </summary>
        /// <param name="index">Index to get token from</param>
        /// <returns>Token at /index/</returns>
        public Token this[int index]
        {
            get => tokens[index];
        }

        /// <summary>
        /// Removes token at given index
        /// </summary>
        /// <param name="index">Index to remove token from</param>
        public void removeAt(int index)
        {
            tokens.RemoveAt(index);
        }

        /// <summary>
        /// Sets the index of the tokenString to the final token.
        /// Best used when intending to traverse backwards
        /// </summary>
        public void setToEnd()
        {
            index = tokens.Count+1;
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
