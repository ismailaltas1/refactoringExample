using RefactoringExample.Domain;

namespace RefactoringExample.Calculator;

public class ComedyCalculator(Performance performance, Play play) : PerformanceCalculator(performance, play)
{
    public override decimal Amount
    {
        get
        {
            decimal result = 30000;
            if (Performance.Audience > 20)
            {
                result += 10000 + 500 * (Performance.Audience - 20);
            }
            result += 300 * Performance.Audience;
            return result;
        }
    }

    public override int VolumeCredits => base.VolumeCredits + (int)Math.Floor((decimal)Performance.Audience / 5);
}
