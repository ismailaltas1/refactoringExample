using RefactoringExample.Domain;
using RefactoringExample.Enums;
using RefactoringExample.Render;
using RefactoringExample.Statements;


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

var statementData = new StatementCalculator().CreateStatementData(invoice);

var statement = RenderFactory.Render(statementData, RenderType.PlainText);
var htmlStatement = RenderFactory.Render(statementData, RenderType.Html);

Console.WriteLine(statement);
Console.Write(htmlStatement);