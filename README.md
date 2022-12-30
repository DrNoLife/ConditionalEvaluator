# ConditionalEvaluator
A basic conditional evaluator.

## Usage

Simply include a Using statement, and then do the following:

```csharp
bool result = ConditionEvaluator.Expression("value > 10").WithValue(18).Evaluate();

// result == true
```

Furthermore, you can also use ```threshold``` to be more dynamic:

```csharp
bool result = ConditionEvaluator.Expression("value > threshold").WithValue(10).WithThreshold(5).Evaluate();
```

## Notes
If you downloaded a previous version of this library, well then this is a breaking change, as the syntax has changed for how to make use of the package.