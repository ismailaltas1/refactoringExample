using System.Globalization;

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


    public decimal AmountFor( Performance perf)
    {
        
        decimal result = 0;
        switch (PlayFor(perf).Type)
        {
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
            default:
                throw new Exception($"unknown type: {PlayFor(perf).Type}");
        }

        return result;
    }

    public Play PlayFor(Performance performance)
    {
        return Plays.FirstOrDefault(x => x.Name == performance.PlayID) ?? new Play();
    }
}
