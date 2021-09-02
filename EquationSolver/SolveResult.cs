using EquationSolver.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver
{
    /// <summary>
    /// Acts as the result of equation solving. contains a flag for the success of the operation, as well as 
    /// (when applicable) the result/ValidationInstance
    /// </summary>
    public class SolveResult
    {
        public bool solved;
        public ValidationInstance validationInstance;
        public decimal result;

        /// <summary>
        /// Creates an instance of SolveResult which represents a failure to solve the equation.
        /// </summary>
        /// <param name="validationInstance">The invalid validation instance</param>
        /// <returns>SolveResult object representing failure</returns>
        public static SolveResult failed(ValidationInstance validationInstance)
        {
            SolveResult sr = new SolveResult();
            sr.solved = false;
            sr.validationInstance = validationInstance;
            return sr;
        }

        /// <summary>
        /// Creates an instance of SolveResult which represents successful solving of the equation.
        /// </summary>
        /// <param name="result">The calculated result</param>
        /// <returns>SolveResult object representing success</returns>
        public static SolveResult succeeded(decimal result)
        {
            SolveResult sr = new SolveResult();
            sr.solved = true;
            sr.result = result;
            return sr;
        }
    }
}
