namespace RefactoringExample;

using System;
using System.Collections.Generic;
using System.Globalization;

public class InvoiceStatement
{
    public string GenerateStatement(Invoice invoice, Dictionary<string, Play> plays)
    {
        decimal totalAmount = 0;
        int volumeCredits = 0;
        string result = $"Statement for {invoice.Customer}\n";
        CultureInfo cultureInfo = new CultureInfo("en-US");
        NumberFormatInfo numberFormat = cultureInfo.NumberFormat;
        numberFormat.CurrencySymbol = "USD";

        foreach (Performance perf in invoice.Performances)
        {
            Play play = plays[perf.PlayID];
            decimal thisAmount = 0;

            switch (play.Type)
            {
                case "tragedy":
                    thisAmount = 40000;
                    if (perf.Audience > 30)
                    {
                        thisAmount += 1000 * (perf.Audience - 30);
                    }
                    break;
                case "comedy":
                    thisAmount = 30000;
                    if (perf.Audience > 20)
                    {
                        thisAmount += 10000 + 500 * (perf.Audience - 20);
                    }
                    thisAmount += 300 * perf.Audience;
                    break;
                default:
                    throw new Exception($"unknown type: {play.Type}");
            }

            // add volume credits
            volumeCredits += Math.Max(perf.Audience - 30, 0);
            // add extra credit for every ten comedy attendees
            if ("comedy" == play.Type) volumeCredits += perf.Audience / 5;

            // print line for this order
            result += $"  {play.Name}: {thisAmount / 100:C} ({perf.Audience} seats)\n";
            totalAmount += thisAmount;
        }
        result += $"Amount owed is {totalAmount / 100:C}\n";
        result += $"You earned {volumeCredits} credits\n";
        return result;
    }
}



