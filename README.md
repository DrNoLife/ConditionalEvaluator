# ConditionalEvaluator
A basic conditional evaluator.

## Usage

Simply include a Using statement, and then do the following:

```csharp
bool result = ConditionEvaluator.Evaluate().Expression("value > 10").WithValue(18);
```