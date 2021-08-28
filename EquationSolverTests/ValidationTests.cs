using EquationSolver.Tokens;
using EquationSolver.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
[Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
public class ValidationTests
{

    [TestMethod]
    public void validEquation()
    {
        ValidationInstance valInstance = EqValidator.isValid("(5*4)+10");

        Assert.IsTrue(valInstance.valid);
    }

    [TestMethod]
    public void adjacentOperands()
    {
        TokenString ts = Tokeniser.tokenise("2+3");
        ts.removeAt(1); //tokeniser would interpet 2 3 as 23, so this workaround is needed - I don't think this is an issue, as you cannot have two numbers next to each other in an equation anyway

        ValidationInstance valInstance = EqValidator.isValid(ts);
        ValidationObject valObject = valInstance[0];

        Assert.IsTrue(valObject.token == ts[0]);
    }

    [TestMethod]
    public void invalidOperatorLeft()
    {
        //testing for operators with no operands to their right

        TokenString ts = Tokeniser.tokenise("+3*2");
        ValidationInstance valInstance = EqValidator.isValid(ts);

        Assert.IsTrue(valInstance[0].token == ts[0]);
    }

    [TestMethod]
    public void invalidOperatorLeftBracket()
    {
        //testing for operators with brackets to their left but no operands
        TokenString ts = Tokeniser.tokenise("()+3*2");
        ValidationInstance valInstance = EqValidator.isValid(ts);

        Assert.IsTrue(valInstance[0].token == ts[2]);
    }

    [TestMethod]
    public void invalidOperatorright()
    {
        //testing for operators with no operands to their right

        TokenString ts = Tokeniser.tokenise("3*2+");
        ValidationInstance valInstance = EqValidator.isValid(ts);

        Assert.IsTrue(valInstance[0].token == ts[3]);
    }

    [TestMethod]
    public void invalidOperatorrightBracket()
    {
        //testing for operators with brackets to their left but no operands
        TokenString ts = Tokeniser.tokenise("3*2+()");
        ValidationInstance valInstance = EqValidator.isValid(ts);

        Assert.IsTrue(valInstance[0].token == ts[3]);
    }
}