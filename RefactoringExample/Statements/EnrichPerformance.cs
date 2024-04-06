namespace RefactoringExample.Statements;

public class EnrichedPerformance
{
    public string PlayID { get; set; }
    public int Audience { get; set; }
    public decimal Amount { get; set; }
    public int VolumeCredits { get; set; }

    public EnrichedPerformance(string playId, int audience, decimal amount, int volumeCredits)
    {
        PlayID = playId;
        Audience = audience;
        Amount = amount;
        VolumeCredits = volumeCredits;
    }
}