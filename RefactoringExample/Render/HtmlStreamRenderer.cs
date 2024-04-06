using RefactoringExample.Helper;
using RefactoringExample.Statements;

namespace RefactoringExample.Render;
public static class HtmlStatementRenderer
{
    public static string Render(StatementData data)
    {
        string result = $"<h1>Statement for {data.Customer}</h1>\n";
        result += "<table>\n";
        result += "<tr><th>play</th><th>seats</th><th>cost</th></tr>";

        foreach (var perf in data.Performances)
        {
            result += $"<tr><td>{perf.PlayID}</td><td>{perf.Audience}</td>";
            result += $"<td>{FormatHelper.Usd(perf.Amount)}</td></tr>\n";
        }

        result += "</table>\n";
        result += $"<p>Amount owed is <em>{FormatHelper.Usd(data.TotalAmount)}</em></p>\n";
        result += $"<p>You earned <em>{data.TotalVolumeCredits}</em> credits</p>\n";
        return result;
    }
}