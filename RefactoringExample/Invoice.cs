using System.Globalization;
using RefactoringExample.Calculator;

namespace RefactoringExample;


public class Invoice
{
    public string Customer { get; set; }
    public List<Performance> Performances { get; set; }
    
    public List<Play> Plays { get; set; }

    public Invoice(string customer, List<Performance> performances,List<Play> plays)
    {
        Customer = customer;
        Performances = performances;
        Plays = plays;
    }




    public string TextStatement()
    {
        return new PlainTextStatementRenderer(this).Render();
    }

    public string HtmlStatement()
    {
        return new HtmlStatementRenderer(this).Render();
    }

    

    public decimal GetTotalAmount()
    {
        decimal totalAmount = 0;
        foreach (Performance perf in Performances)
        {
            totalAmount += AmountFor(perf);
        }

        return totalAmount;
    }

    public int TotalVolumeCredits()
    {
        int volumeCredits = 0;
        foreach (Performance perf in Performances)
        {
            volumeCredits += VolumeCreditsFor( perf);
            
        }

        return volumeCredits;
    }

    public string Usd(decimal aNumber)
    {
        CultureInfo cultureInfo = new CultureInfo("en-US");
        NumberFormatInfo numberFormat = cultureInfo.NumberFormat;
        numberFormat.CurrencySymbol = "$";
        numberFormat.CurrencyDecimalDigits = 2;

        return (aNumber / 100M).ToString("C", numberFormat);
    }

    private int VolumeCreditsFor( Performance perf)
    {
        int result = 0;
        result += Math.Max(perf.Audience - 30, 0);
        if ("comedy" == PlayFor(perf).Type) result += perf.Audience / 5;
        return result;
    }


    public decimal AmountFor(Performance perf)
    {
        IPerformanceCalculator calculator = PlayFor(perf).PerformanceType switch
        {
            PerformanceType.Tragedy => new TragedyPerformanceCalculator(),
            PerformanceType.Comedy => new ComedyPerformanceCalculator(),
            _ => throw new Exception($"unknown type: {PlayFor(perf).Type}")
        };
        return calculator.CalculateAmount(perf.Audience);
    }
    public Play PlayFor(Performance performance)
    {
        return Plays.FirstOrDefault(x => x.Name == performance.PlayID) ?? new Play();
    }
}
