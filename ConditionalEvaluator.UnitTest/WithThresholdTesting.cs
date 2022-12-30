namespace ConditionalEvaluator.UnitTest;

[TestClass]
public class WithThresholdTesting 
{
    private string _expression1 = String.Empty;
    private string _expression2 = String.Empty;
    private string _expression3 = String.Empty;
    private string _expression4 = String.Empty;
    private string _expression5 = String.Empty;
    private string _expression6 = String.Empty;

    private double _value = Double.NaN;
    private double _threshold = Double.NaN;

    public WithThresholdTesting()
    {
        // Arrange.
        _expression1 = "value > threshold";
        _expression2 = "value < threshold";
        _expression3 = "value >= threshold";
        _expression4 = "value <= threshold";
        _expression5 = "value == threshold";
        _expression6 = "value != threshold";

        _value = 10;
        _threshold = 10;
    }

    [TestMethod]
    public void ValueGreaterThanThreshold_WhenThresholdIs10()
    {
        _threshold = 10;

        // Act.
        bool result = ConditionEvaluator.Expression(_expression1).WithValue(_value).WithThreshold(_threshold).Evaluate();

        // Assert.
        Assert.AreEqual(false, result, $"Expected false, but we got {result}. This is wrong as {_value} is not greater than {_threshold}.");
    }

    [TestMethod]
    public void ValueGreaterThanThreshold_WhenThresholdIs5()
    {
        _threshold = 5;

        // Act.
        bool result = ConditionEvaluator.Expression(_expression1).WithValue(_value).WithThreshold(_threshold).Evaluate();

        // Assert.
        Assert.AreEqual(true, result, $"Expected false, but we got {result}. This is wrong as {_value} is not greater than {_threshold}.");
    }

    [TestMethod]
    public void ValueLessThanThreshold_WhenThresholdIs10()
    {
        _threshold = 10;

        // Act.
        bool result = ConditionEvaluator.Expression(_expression2).WithValue(_value).WithThreshold(_threshold).Evaluate();

        // Assert.
        Assert.AreEqual(false, result, $"Expected false, but we got {result}. This is wrong as {_value} is not greater than {_threshold}.");
    }
}
