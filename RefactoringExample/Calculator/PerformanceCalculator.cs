using RefactoringExample.Domain;

namespace RefactoringExample.Calculator;

public abstract class PerformanceCalculator(Performance performance, Play play)
{
    protected readonly Performance Performance = performance;
    protected readonly Play Play = play;

    public abstract decimal Amount { get; }
    public virtual int VolumeCredits => Math.Max(Performance.Audience - 30, 0);
}
