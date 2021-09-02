# EquationSolver
## Summary

This is a reusable component for solving equatios in C#.

Equations can be tokenised, validated (with actionable feedback if validation fails) and solved.

EquationSolver offers a very simple API, an equation can be validated and solved (with methods of getting feedback) in only 9 lines!

## Supports
The following features are supported:
- Equation validation with feedback
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
```c#
using EquationSolver;
```
### Solving Equations
EqSolve offers several paths to solve an equation.
#### No Validation
This method is liable to throw unfriendly exceptions.
```c#
decimal result = EqSolve.solveEquation("(5*6)^2", false);
```
#### Validation with Exceptions
This method returns a decimal, but if validation fails it will throw a **ValidationException** containing the [ValidationInstance.](#validation)
```c#
try
{
  decimal result = EqSolve.solveEquation(equation, true);
}
catch (ValidationException e)
{
  ValidationInstance valInstance = e.validationInstance; 
}
```
#### Validation with SolveResult Object
This method returns a **SolveResult** object which contains a flag, the result or the [ValidationInstance.](#validation)
```c#
SolveResult solveResult = EqSolve.solveEquation(equation);
if(solveResult.solved) //success
{
  decimal result = solveResult.result; //extract result
}
else
{
  validationInstance valInstance = solveResult.validationInstance;
}
```

### Validation
Validation is offered either as a part of equation solving or as an indepentant function. Validation checks that the equation is syntactically correct and returns a **ValidationInstance** object.
```c# 
ValidationInstance valInstance = EqValidator.isValid(equation);
```
#### ValidationInstance
The ValidationInstance is the result of validation, it contains a flag for if the overall equation is valid and an ordered list of **ValidationObjects**.
#### ValidationObject
A ValidationObject represents an individual validation failure, for example ```5+5+``` would result in a ValidationObject containing the token of the second '+' with the message:
```
\+ at position 4 is invalid
```
### Tokeniser
The tokeniser can also be used independantly of equation solving
```c#
TokenString ts = Tokeniser.tokenise("(5*6)^2");
```
The tokeniser will ignore whitespace

### User Defined Constants
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
```c#
decimal result = EquationSolver.EqSolve("UserConstantA * 2");
```

## Closing Remarks
If you want to try utilising this in your own application, check program.cs for some addition usage examples!
