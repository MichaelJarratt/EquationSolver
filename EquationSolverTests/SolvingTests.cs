using EquationSolver;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EquationSolverTests
{
    namespace EquationSolverTests
    {
        [TestClass]
        public class SolvingTests
        {
            double result;

            [TestMethod]
            public void Addition()
            {
                result = EqSolve.solveEquation("2 + 4");
                Assert.IsTrue(result == 6);
            }

            [TestMethod]
            public void subtraction()
            {
                result = EqSolve.solveEquation("20 - 10");
                Assert.IsTrue(result == 10);
            }

            [TestMethod]
            public void multiplication()
            {
                result = EqSolve.solveEquation("15 * 4");
                Assert.IsTrue(result == 60);
            }

            [TestMethod]
            public void division()
            {
                result = EqSolve.solveEquation("500 / 100");
                Assert.IsTrue(result == 5);
            }

            [TestMethod]
            public void exponent()
            {
                result = EqSolve.solveEquation("5^3");
                Assert.IsTrue(result == 125);
            }

            [TestMethod]
            public void brackets()
            {
                result = EqSolve.solveEquation("(5+3)");
                Assert.IsTrue(result == 8);
            }

            [TestMethod]
            public void bracketsAndOperators()
            {
                result = EqSolve.solveEquation("(5+3)^2");
                Assert.IsTrue(result == 64);
            }

            [TestMethod]
            public void precedence()
            {
                result = EqSolve.solveEquation("60-20+2*100/5^2");
                Assert.IsTrue(result == 32);
            }
    }
    }
}
    