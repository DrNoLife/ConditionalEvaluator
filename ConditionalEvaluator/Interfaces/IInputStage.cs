namespace ConditionalEvaluator.Interfaces;

public interface IInputStage
{
    public IEvaluateStage WithValue(double value);
    public IEvaluateStage WithThreshold(double threshold);
}
