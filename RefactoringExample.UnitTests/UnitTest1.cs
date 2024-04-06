namespace RefactoringExample.UnitTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }
    [Test]
    public void TestGenerateStatement()
    {
        // Arrange
        var plays = new List<Play>()
        {
            new Play { Name = "hamlet", Type = "tragedy" },
            new Play { Name = "as-like", Type = "comedy" },
            new Play { Name = "othello", Type = "tragedy" },
            new Play { Name = "as-like-2", Type = "comedy" }
 
        };
        var invoice = new Invoice
        (
            "BigCo",
            new List<Performance>
            {
                new Performance { PlayID = "hamlet", Audience = 35 },
                new Performance { PlayID = "as-like", Audience = 35 },
                new Performance { PlayID = "othello", Audience = 20 },
                new Performance { PlayID = "as-like-2", Audience = 18 },
            },
            plays
        );

 
        var actualResult = invoice.GenerateStatement();
        
        string expectedStatement = "Statement for BigCo\n  hamlet: \u20ba450,00 (35 seats)\n  as-like: \u20ba580,00 (35 seats)\n  othello: \u20ba400,00 (20 seats)\n  as-like-2: \u20ba354,00 (18 seats)\nAmount owed is \u20ba1.784,00\nYou earned 20 credits\n";

        // Assert
        Assert.IsNotNull(actualResult);
        Assert.AreEqual(expectedStatement, actualResult);
        // Add more assertions as needed to validate the statement content
    }

   
        
    
}