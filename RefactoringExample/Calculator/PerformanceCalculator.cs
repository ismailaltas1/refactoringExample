using RefactoringExample.Domain;

namespace RefactoringExample.Calculator;

public abstract class PerformanceCalculator
{
    protected readonly Performance _performance;
    protected readonly Play _play;

    protected PerformanceCalculator(Performance performance, Play play)
    {
        _performance = performance;
        _play = play;
    }

    public abstract decimal Amount { get; }
    public virtual int VolumeCredits => Math.Max(_performance.Audience - 30, 0);
}
