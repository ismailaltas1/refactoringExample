using RefactoringExample.Helper;
using RefactoringExample.Statements;

namespace RefactoringExample.Render;

public static class PlainTextStatementRenderer
{
    public static string Render(StatementData data)
    {
        string result = $"Statement for {data.Customer}\n";
        foreach (var perf in data.Performances)
        {
            result += $"  {perf.PlayID}: {FormatHelper.Usd(perf.Amount)} ({perf.Audience} seats)\n";
        }

        result += $"Amount owed is {FormatHelper.Usd(data.TotalAmount)}\n";
        result += $"You earned {data.TotalVolumeCredits} credits\n";
        return result;
    }
}