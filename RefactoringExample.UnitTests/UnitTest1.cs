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
        var plays = new Dictionary<string, Play>
        {
            {"hamlet", new Play { Name = "Hamlet", Type = "tragedy" } },
            {"as-like", new Play { Name = "As You Like It", Type = "comedy" } },
            {"othello", new Play { Name = "Othello", Type = "tragedy" } },
            {"as-like-2", new Play { Name = "As You Like It-2", Type = "comedy" } },
        };

        var invoice = new Invoice
        {
            Customer = "BigCo",
            Performances = new List<Performance>
            {
                new Performance { PlayID = "hamlet", Audience = 35 },
                new Performance { PlayID = "as-like", Audience = 35 },
                new Performance { PlayID = "othello", Audience = 20 },
                new Performance { PlayID = "as-like-2", Audience = 18 },
            }
        };

        // Act
        var invoiceStatement = new InvoiceStatement();
        var exptectedResult = invoiceStatement.GenerateStatement(invoice, plays);
        
        string expectedStatement = "Statement for BigCo\n  Hamlet: $450.00 (35 seats)\n  As You Like It: $580.00 (35 seats)\n  Othello: $400.00 (20 seats)\n  As You Like It-2: $354.00 (18 seats)\nAmount owed is $1,784.00\nYou earned 20 credits\n";

        // Assert
        Assert.IsNotNull(exptectedResult);
        Assert.AreEqual(expectedStatement, exptectedResult);
        // Add more assertions as needed to validate the statement content
    }

   
        
    
}