# EquationSolver
## Summary

This is a reusable component for solving equatios in C#.

The equation is tokenised and the tokens are then parsed and solved.

## Supports
The following features are supported:
- User defined constants
- Addition
- Subtraction
- Multiplication
- Division
- Exponent
- Brackets
- Binary and Unary "-" operators
- Decimal inputs
- JSON config file to add new operators or change operator symbols (if you wanted to do that for some reason)

## Using
Add everything under the EquationSolver namespace to your project.
>using EquationSolver;
### Solving Equations
EqSolve takes a string and returns a double with the result
> Decimal result = EquationSolver.EqSolve("(5*6)^2");
### Tokeniser
The tokeniser can also be used independantly of equation solving
> TokenString ts = Tokeniser.tokenise("(5*6)^2");

The tokeniser will ignore whitespace

### User Defined COnstants
EquationSolver offers the ability to define and utilise constants in equations.
#### Defining Constants
Constants can be defined in `config.js`

Constants are formatted as key-value pairs.

```
  "constants": 
  [
    [ "UserConstantA", 50 ],
    [ "user_constant_B", 25 ]
  ]
  ```
**Rules:** A constant can be any sequence of characters that does not include [0-9], '.' or an operator.

#### Using Constants
Using a constant is as simple as writing it in the equation. Mind that is it case-sensitive!
>Decimal result = EquationSolver.EqSolve("UserConstantA * 2");
