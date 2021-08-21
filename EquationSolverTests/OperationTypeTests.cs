using EquationSolver.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EquationSolverTests
{
    namespace EquationSolverTests
    {
        [TestClass]
        public class OperationTypeTests
        {
            [TestMethod]
            public void OperatorPrecedence()
            { 
                Assert.IsTrue(OperationType.Addition > OperationType.Subtraction);
            }
        }
    }
}
