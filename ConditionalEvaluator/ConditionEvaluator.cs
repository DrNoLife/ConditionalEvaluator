using ConditionalEvaluator.Interfaces;
using System.Data;

namespace ConditionalEvaluator;

public class ConditionEvaluator : IExpressionInputStage, IValueInputStage
{
    private DataTable _table = new DataTable();
    private string _booleanExpresion = String.Empty;
    private double _value = Double.NaN;

    public ConditionEvaluator() { }

    /// <summary>
    /// Starts the evaluation process.
    /// </summary>
    public static IExpressionInputStage Evaluate()
    {
        return new ConditionEvaluator();
    }

    /// <summary>
    /// Specify the expression that should be evaluated.
    /// </summary>
    /// <param name="expression">e.g. value > 10</param>
    public IValueInputStage Expression(string expression)
    {
        _booleanExpresion = expression;
        _table.Columns.Add("value", typeof(double));
        _table.Columns.Add("result", typeof(bool), _booleanExpresion);
        return this;
    }

    /// <summary>
    /// Specify the value that should be used in the expression.
    /// </summary>
    /// <param name="value">e.g. 8</param>
    /// <returns>true or false, depending on the expressions evaluation.</returns>
    public bool WithValue(double value)
    {
        _value = value;

        DataRow row = _table.NewRow();
        row["value"] = _value;
        _table.Rows.Add(row);

        return (bool)row["result"];
    }
}