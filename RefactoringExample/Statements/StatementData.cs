namespace RefactoringExample.Statements;

public class StatementData
{
    public string Customer { get; set; }
    public List<EnrichedPerformance> Performances { get; set; }
    public decimal TotalAmount { get; set; }
    public int TotalVolumeCredits { get; set; }
    
}