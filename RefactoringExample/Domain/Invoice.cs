

namespace RefactoringExample.Domain;


public class Invoice(string customer, List<Performance> performances, List<Play> plays)
{
    public string Customer { get; set; } = customer;
    public List<Performance> Performances { get; set; } = performances;

    private List<Play> Plays { get; set; } = plays;

    public Play PlaysFor(Performance performance)
    {
        return Plays.FirstOrDefault(x => x.Name == performance.PlayID) ?? new Play();
    }
}
