namespace RefactoringExample;
public class HtmlStatementRenderer : IStatementRenderer
{
    private readonly Invoice _invoice;

    public HtmlStatementRenderer(Invoice invoice)
    {
        _invoice = invoice;
    }

    public string Render()
    {
        string result = $"<h1>Statement for {_invoice.Customer}</h1>\n";
        result += "<table>\n";
        result += "<tr><th>play</th><th>seats</th><th>cost</th></tr>";

        foreach (Performance perf in _invoice.Performances)
        {
            result += $"<tr><td>{_invoice.PlayFor(perf).Name}</td><td>{perf.Audience}</td>";
            result += $"<td>{_invoice.Usd(_invoice.AmountFor(perf))}</td></tr>\n";
        }

        result += "</table>\n";
        result += $"<p>Amount owed is <em>{_invoice.Usd(_invoice.GetTotalAmount())}</em></p>\n";
        result += $"<p>You earned <em>{_invoice.TotalVolumeCredits()}</em> credits</p>\n";
        return result;
    }
}