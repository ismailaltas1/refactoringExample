using RefactoringExample.Helper;
using RefactoringExample.Statements;

namespace RefactoringExample.Render;

public static class PlainTextStatementRenderer
{
    public static string Render(StatementData data)
    {
        var result = $"Statement for {data.Customer}\n";
        result = data.Performances.Aggregate(result, (current, perf) => current + $"  {perf.PlayID}: {FormatHelper.Usd(perf.Amount)} ({perf.Audience} seats)\n");
        result += $"Amount owed is {FormatHelper.Usd(data.TotalAmount)}\n";
        result += $"You earned {data.TotalVolumeCredits} credits\n";
        return result;
    }
}