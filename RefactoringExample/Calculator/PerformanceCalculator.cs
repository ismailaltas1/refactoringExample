using RefactoringExample.Domain;
using RefactoringExample.Enums;

namespace RefactoringExample.Calculator;

public abstract class PerformanceCalculator(Performance performance)
{
    protected readonly Performance Performance = performance;

    public abstract decimal Amount { get; }
    public virtual int VolumeCredits => Math.Max(Performance.Audience - 30, 0);
}
