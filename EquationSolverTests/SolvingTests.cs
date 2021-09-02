using EquationSolver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EquationSolverTests
{
    namespace EquationSolverTests
    {
        [TestClass]
        public class SolvingTests
        {
            Decimal result;

            [TestMethod]
            public void Addition()
            {
                result = EqSolve.solveEquation("2 + 4", false);
                Assert.IsTrue(result == 6m);
            }

            [TestMethod]
            public void subtraction()
            {
                result = EqSolve.solveEquation("20 - 10", false);
                Assert.IsTrue(result == 10);
            }

            [TestMethod]
            public void multiplication()
            {
                result = EqSolve.solveEquation("15 * 4", false);
                Assert.IsTrue(result == 60);
            }

            [TestMethod]
            public void division()
            {
                result = EqSolve.solveEquation("500 / 100", false);
                Assert.IsTrue(result == 5);
            }

            [TestMethod]
            public void exponent()
            {
                result = EqSolve.solveEquation("5^3", false);
                Assert.IsTrue(result == 125);
            }

            [TestMethod]
            public void brackets()
            {
                result = EqSolve.solveEquation("(5+3)", false);
                Assert.IsTrue(result == 8);
            }

            [TestMethod]
            public void bracketsAndOperators()
            {
                result = EqSolve.solveEquation("(5+3)^2", false);
                Assert.IsTrue(result == 64);
            }

            [TestMethod]
            public void precedence()
            {
                result = EqSolve.solveEquation("60-20+2*100/5^2", false);
                Assert.IsTrue(result == 32);
            }

            [TestMethod]
            public void decimals()
            {
                result = EqSolve.solveEquation("5.5+4.5", false);
                Assert.IsTrue(result == 10);
            }

            [TestMethod]
            public void constants()
            {
                result = EqSolve.solveEquation("test_constant_A / test_constant_B", false);
                Assert.IsTrue(result == 2);
            }
    }
    }
}
    