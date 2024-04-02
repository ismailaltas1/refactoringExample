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

    public string GetPlayType(Performance performance)
    {

        var play = Plays.FirstOrDefault(x => x.Name == performance.PlayID);
        return play == null ? "" : play.Type;
    }
    public string GetPlayName(Performance performance)
    {

        var play = Plays.FirstOrDefault(x => x.Name == performance.PlayID);
        return play == null ? "" : play.Name;
    }


    public string GenerateStatement()
    {
        decimal totalAmount = 0;
        int volumeCredits = 0;
        string result = $"Statement for {Customer}\n";
        CultureInfo cultureInfo = new CultureInfo("en-US");
        NumberFormatInfo numberFormat = cultureInfo.NumberFormat;
        numberFormat.CurrencySymbol = "USD";

        foreach (Performance perf in Performances)
        {
           
            decimal thisAmount = 0;

            thisAmount = getAmount(perf);

            // add volume credits
            volumeCredits += Math.Max(perf.Audience - 30, 0);
            // add extra credit for every ten comedy attendees
            if ("comedy" == GetPlayType(perf)) volumeCredits += perf.Audience / 5;

            // print line for this order
            result += $"  {GetPlayName(perf)}: {thisAmount / 100:C} ({perf.Audience} seats)\n";
            totalAmount += thisAmount;
        }
        result += $"Amount owed is {totalAmount / 100:C}\n";
        result += $"You earned {volumeCredits} credits\n";
        return result;
    }

    private decimal getAmount( Performance perf)
    {
        
        decimal result = 0;
        switch (GetPlayType(perf))
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
                throw new Exception($"unknown type: {GetPlayType(perf)}");
        }

        return result;
    }
}
