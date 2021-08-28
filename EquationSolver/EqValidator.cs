using EquationSolver.Operations;
using EquationSolver.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver
{
    public static class EqValidator
    {

        public static ValidationInstance isValid(TokenString equation)
        {
            int openBrackets = 0, closedBrackets = 0;
            Token token;
            OperatorToken operatorToken;
            OperandToken operandToken;

            ValidationInstance valInstance = new ValidationInstance();

            while(equation.hasNext()) //iterate over every token
            {
                token = equation.next();

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
                        //logic for checking it has operands either side
                        //if not then update the ValidationInstance
                    }
                }
            }

            if (openBrackets > closedBrackets)
            {
                valInstance.addOffence(new ValidationObject("Uncoupled open bracket."));
            }
            else if (closedBrackets > openBrackets)
            {
                valInstance.addOffence(new ValidationObject("Uncoupled Closed bracket."));
            }

            return valInstance;
        }

        public static ValidationInstance isValid(String equation)
        {
            return isValid(Tokeniser.tokenise(equation));
        }
    }

    //collection of issues, as well as the bool for is any issues exist.
    public class ValidationInstance
    {
        public bool valid = true; //did the entire equation validate?
        public List<ValidationObject> offences = new List<ValidationObject>();

        /// <summary>
        /// Adds an offence to the list and sets the valid flag to false.
        /// </summary>
        /// <param name="validationObject">The office to add to the list</param>
        public void addOffence(ValidationObject validationObject)
        {
            valid = false;
            offences.Add(validationObject);
        }
    }

    //stores what the issue was
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
