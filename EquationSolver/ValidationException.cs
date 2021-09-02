using EquationSolver.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver
{
    class ValidationException: Exception
    {
        public ValidationInstance validationInstance;

        public ValidationException(string message, ValidationInstance validationInstance): base(message)
        {
            this.validationInstance = validationInstance;
        }
    }
}
