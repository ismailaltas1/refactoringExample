using RefactoringExample.Domain;
using RefactoringExample.Enums;

namespace RefactoringExample.Calculator;

public class TragedyPerformanceCalculator(Performance performance) : PerformanceCalculator(performance)
{
    public override decimal Amount
    {
        get
        {
            decimal result = 40000;
            if (Performance.Audience > 30)
            {
                result += 1000 * (Performance.Audience - 30);
            }
            return result;
        }
    }
}
