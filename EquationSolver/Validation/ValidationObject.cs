using EquationSolver.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver.Validation
{
    //This class stores a Token that caused a validation failure and its related message
    public class ValidationObject
    {
        public Token token; //offending token
        public string message;

        public ValidationObject(String message)
        {
            this.message = message;
        }

        public ValidationObject(String message, Token token)
        {
            this.message = message;
            this.token = token;
        }
    }
}
