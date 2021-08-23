# EquationSolver
## Summary

This is a reusable component for solving equatios in C#.

The equation is tokenised and the tokens are then parsed and solved.

## Supports
The following features are supported:
- Addition
- Subtraction
- Multiplication
- Division
- Exponent
- Brackets
- Binary and Unary "-" operators
- JSON config file to add new operators or change operator symbols (if you wanted to do that for some reason)

## Using
Add everything under the EquationSolver namespace to your project.
>using EquationSolver;
### Solving Qquations
EqSolve takes a string and returns a double with the result
> double result = EquationSolver.EqSolve("(5*6)^2");
### Tokeniser
The tokeniser can also be used independantly of equation solving
> TokenString ts = Tokeniser.tokenise("(5*6)^2");

The tokeniser will ignore whitespace
