namespace RefactoringExample;

public class PlainTextStatementRenderer : IStatementRenderer
{
    private readonly Invoice _invoice;

    public PlainTextStatementRenderer(Invoice invoice)
    {
        _invoice = invoice;
    }

    public string Render()
    {
        string result = $"Statement for {_invoice.Customer}\n";
        foreach (Performance perf in _invoice.Performances)
        {
            result += $"  {_invoice.PlayFor(perf).Name}: {_invoice.Usd(_invoice.AmountFor(perf))} ({perf.Audience} seats)\n";
        }

        result += $"Amount owed is {_invoice.Usd(_invoice.GetTotalAmount())}\n";
        result += $"You earned {_invoice.TotalVolumeCredits()} credits\n";
        return result;
    }
}