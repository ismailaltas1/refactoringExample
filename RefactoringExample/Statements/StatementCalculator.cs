using RefactoringExample.Calculator;
using RefactoringExample.Domain;
using RefactoringExample.Enums;

namespace RefactoringExample.Statements;

public class StatementCalculator
{
    public StatementData CreateStatementData(Invoice invoice)
    {
        var result = new StatementData
        {
            Customer = invoice.Customer,
            Performances = invoice.Performances.Select(performance => EnrichPerformance(performance, invoice.PlaysFor(performance).PerformanceType)).ToList()
        };
        result.TotalAmount = GetTotalAmount(result);
        result.TotalVolumeCredits = TotalVolumeCredits(result);
        return result;
    }
    
    private EnrichedPerformance EnrichPerformance(Performance aPerformance, PerformanceType performanceType)
    {
        var calculator = PerformanceCalculatorFactory.CreatePerformanceCalculator(aPerformance, performanceType);
        var result = new EnrichedPerformance(aPerformance.PlayID, aPerformance.Audience, calculator.Amount, calculator.VolumeCredits);
        return result;
    }
    
    private static decimal GetTotalAmount(StatementData data)
    {
        return data.Performances.Sum(perf => perf.Amount);
    }
    

    private static int TotalVolumeCredits(StatementData data)
    {
        return data.Performances.Sum(perf => perf.VolumeCredits);
    }
    
  
}