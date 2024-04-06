namespace RefactoringExample.Calculator;

public class ComedyPerformanceCalculator : IPerformanceCalculator
{
    public decimal CalculateAmount(int audience)
    {
        decimal result = 30000;
        if (audience > 20)
        {
            result += 10000 + 500 * (audience - 20);
        }
        result += 300 * audience;
        return result;
    }
}

/*
           case "tragedy":
        result = 40000;
        if (perf.Audience > 30)
        {
            result += 1000 * (perf.Audience - 30);
        }
        break;
    case "comedy":
        result = 30000;
        if (perf.Audience > 20)
        {
            result += 10000 + 500 * (perf.Audience - 20);
        }
        result += 300 * perf.Audience;
        break;
*/