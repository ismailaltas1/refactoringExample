using FluentAssertions;
using RefactoringExample.Domain;
using RefactoringExample.Enums;
using RefactoringExample.Render;
using RefactoringExample.Statements;

namespace RefactoringExample.UnitTests;

public class StatementRenderingUnitTests
{
    private Invoice invoice;
    private StatementData _statementData;
    [SetUp]
    public void Setup()
    {
        invoice = CreateInvoice();
        _statementData = new StatementCalculator().CreateStatementData(invoice);
    }
    [Test]
    public void GenerateStatement_ShouldReturnExpectedPlainTextStatement()
    {
        
        var actualResult =  RenderFactory.Render(_statementData, RenderType.PlainText);
        const string expectedStatement = "Statement for BigCo\n  hamlet: $450.00 (35 seats)\n  as-like: $580.00 (35 seats)\n  othello: $400.00 (20 seats)\n  as-like-2: $354.00 (18 seats)\nAmount owed is $1,784.00\nYou earned 20 credits\n";
        
        actualResult.Should().Be(expectedStatement);
    }


    [Test]
    public void GenerateHtmlStatement_ShouldReturnExpectedHtmlStatement()
    {
        var actualResult =  RenderFactory.Render(_statementData, RenderType.Html);
        
        const string expectedStatement = "<h1>Statement for BigCo</h1>\n<table>\n<tr><th>play</th><th>seats</th><th>cost</th></tr><tr><td>hamlet</td><td>35</td><td>$450.00</td></tr>\n<tr><td>as-like</td><td>35</td><td>$580.00</td></tr>\n<tr><td>othello</td><td>20</td><td>$400.00</td></tr>\n<tr><td>as-like-2</td><td>18</td><td>$354.00</td></tr>\n</table>\n<p>Amount owed is <em>$1,784.00</em></p>\n<p>You earned <em>20</em> credits</p>\n";

        actualResult.Should().Be(expectedStatement);
    }
    
    private Invoice CreateInvoice()
    {
        var plays = new List<Play>()
        {
            new() { Name = "hamlet", Type = "tragedy", PerformanceType = PerformanceType.Tragedy},
            new() { Name = "as-like", Type = "comedy", PerformanceType = PerformanceType.Comedy },
            new() { Name = "othello", Type = "tragedy", PerformanceType = PerformanceType.Tragedy },
            new() { Name = "as-like-2", Type = "comedy", PerformanceType = PerformanceType.Comedy }
 
        };


        var invoice = new Invoice
        (
            "BigCo",
            new List<Performance>
            {
                new() { PlayID = "hamlet", Audience = 35 },
                new()  { PlayID = "as-like", Audience = 35 },
                new() { PlayID = "othello", Audience = 20 },
                new() { PlayID = "as-like-2", Audience = 18 },
            },
            plays
        );
        return invoice;
    }



}