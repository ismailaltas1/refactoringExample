namespace RefactoringExample.Calculator;

public class TragedyPerformanceCalculator : IPerformanceCalculator
{
    public decimal CalculateAmount(int audience)
    {
        decimal result = 40000;
        if (audience > 30)
        {
            result += 1000 * (audience - 30);
        }
        return result;
    }
}

