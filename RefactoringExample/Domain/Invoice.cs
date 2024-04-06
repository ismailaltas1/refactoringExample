

namespace RefactoringExample.Domain;


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
    
    public Play PlaysFor(Performance performance)
    {
        return Plays.FirstOrDefault(x => x.Name == performance.PlayID) ?? new Play();
    }
}
