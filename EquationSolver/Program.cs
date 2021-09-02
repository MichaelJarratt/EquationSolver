using System;
using EquationSolver.Tokens;
using EquationSolver.Validation;

namespace EquationSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            usageExample();
        }

        static void usageExample()
        {
            //Here are some examples of how the equation solving API can be utilised
            string equation = "(6*14+(5.5^)/2";
            decimal result;

            ValidationInstance validationInstance; //check class summary. This is the result of the valdation.

            //method 1
            //Solve the equation with no validation, this is liable to throw unfriendly exceptions during solving
            try
            {
                result = EqSolve.solveEquation(equation, false);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Method 1 threw an exception: {e}");
            }

            //method 2
            //Solve the equation with validation, this returns a decimal and will throw a friendly excpetion when validation fails
            try
            {
                result = EqSolve.solveEquation(equation, true);
            }
            catch (ValidationException e)
            {
                validationInstance = e.validationInstance; //you can now take a look at all the offences that caused the validation to fail
            }

            //method 3
            //solve the equation with validation, this returns a SolveResult object which contains a flag + the result/ValidationInstance depending on if it succeeded or not
            SolveResult solveResult = EqSolve.solveEquation(equation);
            if(solveResult.solved) //success
            {
                result = solveResult.result; //extract result
            }
            else
            {
                validationInstance = solveResult.validationInstance; //you can now look at all the offences that caused the validation to fail
            }

            //you can also validate the equation without solving it

            //method 1
            //just pass the string equation to the validator
            validationInstance = EqValidator.isValid(equation);

            //method 2
            //tokenise the equation first, this way the tokenised equation can be passed to the calculation without having to re-tokenise it
            TokenString tsEquation = Tokeniser.tokenise(equation);
            validationInstance = EqValidator.isValid(tsEquation);
            if (validationInstance.valid)
            {
                result = EqSolve.solveEquation(tsEquation, false); //opt out of validation since it has been done externally
            }

            
            //Lastly don't forget the ability to use constants! (check config.json)
            result = EqSolve.solveEquation("test_constant_A-test_constant_B", false);
        }
    }
}
