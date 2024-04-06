using RefactoringExample.Domain;

namespace RefactoringExample.Calculator;


public static class PerformanceCalculatorFactory
{
    public static PerformanceCalculator CreatePerformanceCalculator(Performance aPerformance, Play aPlay)
    {
        switch (aPlay.Type)
        {
            case "tragedy":
                return new TragedyCalculator(aPerformance, aPlay);
            case "comedy":
                return new ComedyCalculator(aPerformance, aPlay);
            default:
                throw new ArgumentException($"Unknown type: {aPlay.Type}", nameof(aPlay));
        }
    }
}