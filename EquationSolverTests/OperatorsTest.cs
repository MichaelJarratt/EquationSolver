using EquationSolver.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EquationSolverTests
{
    namespace EquationSolverTests
    {
        [TestClass]
        public class OperatorsTest
        {
            [TestMethod]
            public void ValidOperators()
            {
                OperationType type;

                type = Operators.getOperation("+");
                Assert.IsTrue(type == OperationType.Addition, $"Operation should have been Addition, but it was {type}");

                type = Operators.getOperation("-");
                Assert.IsTrue(type == OperationType.Subtraction, $"Operation should have been Subtraction, but it was {type}");

                type = Operators.getOperation("*");
                Assert.IsTrue(type == OperationType.Multiplication, $"Operation should have been Multiplication, but it was {type}");

                type = Operators.getOperation("/");
                Assert.IsTrue(type == OperationType.Division, $"Operation should have been Division, but it was {type}");

                type = Operators.getOperation("^");
                Assert.IsTrue(type == OperationType.Exponent, $"Operation should have been Exponant, but it was {type}");
            }

            [TestMethod]
            public void InvalidOperator()
            {
                string errorMessage = "";
                try
                {
                    OperationType type = Operators.getOperation("p");
                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                }

                Assert.IsTrue(errorMessage == "Operator not recognised: p");
            }
        }
    }
}
