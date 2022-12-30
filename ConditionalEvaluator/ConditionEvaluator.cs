using ConditionalEvaluator.Interfaces;
using System.Data;
using System.Linq.Expressions;

namespace ConditionalEvaluator;

public class ConditionEvaluator : IInputStage, IEvaluateStage
{
    private DataTable _table = new DataTable();
    private string _booleanExpresion = String.Empty;
    private double? _value = null;
    private double? _threshold = null;

    public ConditionEvaluator(string expression) 
    {
        _booleanExpresion = expression;
    }

    public static IInputStage Expression(string expression)
    {
        var evaluator = new ConditionEvaluator(expression);
        return evaluator;
    }


    public IEvaluateStage WithThreshold(double threshold)
    {
        _threshold = threshold;
        return this;
    }

    public IEvaluateStage WithValue(double value)
    {
        _value = value;
        return this;
    }

    public bool Evaluate()
    {
        _table = new();

        return _threshold is null ? EvaluateWithoutThreshold() : EvaluateWithThreshold();
    }

    /// <summary>
    /// User wants to evaluate an expression with a value and an expression.
    /// </summary>
    /// <returns></returns>
    private bool EvaluateWithThreshold()
    {
        // Create the table structure.
        _table.Columns.Add("value", typeof(double));
        _table.Columns.Add("threshold", typeof(double));
        _table.Columns.Add("result", typeof(bool), _booleanExpresion);

        // Create a new row in the table, and then add the values of the fields.
        DataRow row = _table.NewRow();
        row[0] = _value;
        row[1] = _threshold;
        _table.Rows.Add(row);

        return (bool)row["result"];
    }

    /// <summary>
    /// If the user hasn't supplied a threshold, but is trying to evaluate, then assume the expression is not using a threshold.
    /// </summary>
    /// <returns></returns>
    private bool EvaluateWithoutThreshold()
    {
        // Create the table structure.
        _table.Columns.Add("value", typeof(double));
        _table.Columns.Add("result", typeof(bool), _booleanExpresion);

        // Create a new row in the table, and then add the values of the fields.
        DataRow row = _table.NewRow();
        row[0] = _value;
        _table.Rows.Add(row);

        return (bool)row["result"];
    }
}

// ConditionalEvaluator.Expression("value > threshold").WithValue(5).WithThreshold(10).Evaluate();
// ConditionalEvaluator.Expression("value > 10).WithValue().Evaluate();
// ConditionalEvaluator.Expression("5 < threshold").WithThreshold(10);