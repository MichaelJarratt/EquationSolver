using EquationSolver.Operations;
using EquationSolver.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EquationSolverTests
{
    namespace EquationSolverTests
    {
        [TestClass]
        public class TokeniserTest
        {
            TokenString ts;
            Token token;

            [TestMethod]
            public void whitespace()
            {
                token = Tokeniser.tokenise("5   + 3")[1];

                Assert.IsTrue(((OperatorToken)token).operationType == OperationType.Addition);
            }

            [TestMethod]
            [ExpectedException(typeof(Exception), "\"t\" is not a valid token and should have thrown an exception")]
            public void invalidInput()
            {
                ts = Tokeniser.tokenise("t");
            }

            [TestMethod]
            public void additionToken()
            {
                token = Tokeniser.tokenise("+").next();

                Assert.IsTrue(((OperatorToken)token).operationType == OperationType.Addition);
            }

            [TestMethod]
            public void subtractionToken()
            {
                token = Tokeniser.tokenise("2-2")[1]; //cannot just have "-" because if it is the first character it is assumed to make the following operand negative 

                Assert.IsTrue(((OperatorToken)token).operationType == OperationType.Subtraction);
            }

            [TestMethod]
            public void multiplicationToken()
            {
                token = Tokeniser.tokenise("*").next();

                Assert.IsTrue(((OperatorToken)token).operationType == OperationType.Multiplication);
            }

            [TestMethod]
            public void divisionToken()
            {
                token = Tokeniser.tokenise("/").next();

                Assert.IsTrue(((OperatorToken)token).operationType == OperationType.Division);
            }

            [TestMethod]
            public void Exponent()
            {
                token = Tokeniser.tokenise("^").next();

                Assert.IsTrue(((OperatorToken)token).operationType == OperationType.Exponent);
            }

            [TestMethod]
            public void operand()
            {
                token = Tokeniser.tokenise("54321").next();

                Assert.IsTrue(((OperandToken)token).operandValue == 54321);
            }

            [TestMethod]
            public void nevativeOperand()
            {
                token = Tokeniser.tokenise("-54321").next();

                Assert.IsTrue(((OperandToken)token).operandValue == -54321);
            }

            [TestMethod]
            public void tokenPosition()
            {
                //checking position of addition operator
                token = Tokeniser.tokenise("(2+3)*5")[2];

                Assert.IsTrue(token.position == 3);
            }

            [TestMethod]
            public void multiCharTokenPosition()
            {
                //testing position of 345 starts at 4
                token = Tokeniser.tokenise("(2+345)*5")[3];

                Assert.IsTrue(token.position == 4);
            }
    }
    }
}