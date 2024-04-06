using RefactoringExample.Domain;

namespace RefactoringExample.Calculator;

public class TragedyCalculator : PerformanceCalculator
{
    public TragedyCalculator(Performance performance, Play play) : base(performance, play)
    {
    }

    public override decimal Amount
    {
        get
        {
            decimal result = 40000;
            if (_performance.Audience > 30)
            {
                result += 1000 * (_performance.Audience - 30);
            }
            return result;
        }
    }
}
