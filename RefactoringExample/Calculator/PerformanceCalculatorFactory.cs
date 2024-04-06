using RefactoringExample.Domain;
using RefactoringExample.Enums;

namespace RefactoringExample.Calculator;


public static class PerformanceCalculatorFactory
{
    public static PerformanceCalculator CreatePerformanceCalculator(Performance aPerformance, PerformanceType aPerformanceType)
    {
        return aPerformanceType switch
        {
            PerformanceType.Tragedy => new TragedyPerformanceCalculator(aPerformance),
            PerformanceType.Comedy => new ComedyPerformanceCalculator(aPerformance),
            _ => throw new ArgumentException($"Unknown type: {aPerformanceType}")
        };
    }
}