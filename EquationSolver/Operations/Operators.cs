﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver.Operations
{
    public static class Operators
    {
        private static Config config = Config.getInstance();

        /// <summary>
        /// Takes an operator character and returns the associated operation enum.
        /// </summary>
        /// <param name="op">Operator to check</param>
        /// <returns>Enumeration representing the operation</returns>
        public static OperationType getOperation(string op)
        {
            int operatorIndex = config.operators.IndexOf(op);
            if(operatorIndex != -1) //if it exists in the list
            {
                OperationType operation;
                string operationString = config.operations[operatorIndex]; // operators[0] = "+", operations[0] = "addition"
                if (Enum.TryParse<OperationType>(operationString, out operation)) //check if the operation is valid
                {
                    return operation;
                }
                else
                {
                    throw new Exception($"Operation not recognised: {op}");
                }
                
            }
            else
            {
                throw new Exception($"Operator not recognised: {op}");
            }
        }
        /// <summary>
        /// Takes an operator character and returns the associated operation enum.
        /// </summary>
        /// <param name="op">Operator to check</param>
        /// <returns>Enumeration representing the operation</returns>
        public static OperationType getOperation(char op)
        {
            return getOperation(op.ToString());
        }
    }
}
