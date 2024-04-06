using RefactoringExample.Calculator;

namespace RefactoringExample.UnitTests;

public class Tests
{
    private Invoice invoice;
    [SetUp]
    public void Setup()
    {
        invoice = CreateInvoice();
    }
    [Test]
    public void TestGenerateStatement()
    {
        var actualResult = invoice.TextStatement();
        
        string expectedStatement = "Statement for BigCo\n  hamlet: $450.00 (35 seats)\n  as-like: $580.00 (35 seats)\n  othello: $400.00 (20 seats)\n  as-like-2: $354.00 (18 seats)\nAmount owed is $1,784.00\nYou earned 20 credits\n";

        // Assert
        Assert.IsNotNull(actualResult);
        Assert.AreEqual(expectedStatement, actualResult);
        // Add more assertions as needed to validate the statement content
    }


    [Test]
    public void TestGenerateHtmlStatement()
    {
        var actualResult = invoice.HtmlStatement();
        // Assert
        string expectedHtmlStatement = "<h1>Statement for BigCo</h1>\n<table>\n<tr><th>play</th><th>seats</th><th>cost</th></tr><tr><td>hamlet</td><td>35</td><td>$450.00</td></tr>\n<tr><td>as-like</td><td>35</td><td>$580.00</td></tr>\n<tr><td>othello</td><td>20</td><td>$400.00</td></tr>\n<tr><td>as-like-2</td><td>18</td><td>$354.00</td></tr>\n</table>\n<p>Amount owed is <em>$1,784.00</em></p>\n<p>You earned <em>20</em> credits</p>\n";

        Assert.AreEqual(expectedHtmlStatement, actualResult);
    }
    
    private Invoice CreateInvoice()
    {
        // Arrange
        var plays = new List<Play>()
        {
            new Play { Name = "hamlet", Type = "tragedy", PerformanceType = PerformanceType.Tragedy},
            new Play { Name = "as-like", Type = "comedy", PerformanceType = PerformanceType.Comedy },
            new Play { Name = "othello", Type = "tragedy", PerformanceType = PerformanceType.Tragedy },
            new Play { Name = "as-like-2", Type = "comedy", PerformanceType = PerformanceType.Comedy }
 
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
        return invoice;
    }



}