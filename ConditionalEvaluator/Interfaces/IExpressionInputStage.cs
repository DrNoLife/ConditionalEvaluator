namespace ConditionalEvaluator.Interfaces;

public interface IExpressionInputStage
{
    public IValueInputStage Expression(string expression);
}
