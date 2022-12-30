using ConditionalEvaluator;

namespace ConditionalEvaluator.UnitTest;

[TestClass]
public class WithoutThresholdTesting
{
	private string _expression1 = String.Empty;
	private string _expression2 = String.Empty;
	private string _expression3 = String.Empty;
	private string _expression4 = String.Empty;
	private string _expression5 = String.Empty;
	private string _expression6 = String.Empty;

	private double _value = Double.NaN;

	public WithoutThresholdTesting()
	{
		// Arrange.
		_expression1 = "value > 10";
		_expression2 = "value < 10";
		_expression3 = "value >= 10";
		_expression4 = "value <= 10";
		_expression5 = "value == 10";
		_expression6 = "value <> 10";

		_value = 10;
	}

	[TestMethod]
	public void ValueGreaterThan10()
	{
        // Act.
        bool result = ConditionEvaluator.Expression(_expression1).WithValue(_value).Evaluate();

        // Assert.
        Assert.AreEqual(false, result, $"Expected false, but we got {result}. This is wrong as 10 is not greater than 10.");
	}

    [TestMethod]
    public void ValueLessThan10()
    {
        // Act.
        bool result = ConditionEvaluator.Expression(_expression2).WithValue(_value).Evaluate();

        // Assert.
        Assert.AreEqual(false, result, $"Expected false, but we got {result}. This is wrong as 10 is not less than 10.");
    }

    [TestMethod]
    public void ValueGreaterOrEqualThan10()
    {
        // Act.
        bool result = ConditionEvaluator.Expression(_expression3).WithValue(_value).Evaluate();

        // Assert.
        Assert.AreEqual(true, result, $"Expected true, but we got {result}. This is wrong as 10 is greater or equal to 10.");
    }

    [TestMethod]
    public void ValueLessOrEqualThan10()
    {
        // Act.
        bool result = ConditionEvaluator.Expression(_expression4).WithValue(_value).Evaluate();

        // Assert.
        Assert.AreEqual(true, result, $"Expected true, but we got {result}. This is wrong as 10 is less or equal to 10.");
    }

    [TestMethod]
    public void ValueEqual10()
    {
        // Act.
        bool result = ConditionEvaluator.Expression(_expression4).WithValue(_value).Evaluate();

        // Assert.
        Assert.AreEqual(true, result, $"Expected true, but we got {result}. This is wrong as 10 is equal to 10.");
    }

    //[TestMethod]
    //public void ValueNotEqual10()
    //{
    //    // Act.
    //    bool result = ConditionEvaluator.Expression(_expression4).WithValue(_value).Evaluate();

    //    // Assert.
    //    Assert.AreEqual(false, result, $"Expected false, but we got {result}. This is wrong as value is equal to 10, and we want true if that is not the case.");
    //}
}
