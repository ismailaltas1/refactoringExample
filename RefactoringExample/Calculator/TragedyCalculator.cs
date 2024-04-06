using RefactoringExample.Domain;

namespace RefactoringExample.Calculator;

public class TragedyCalculator(Performance performance, Play play) : PerformanceCalculator(performance, play)
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
