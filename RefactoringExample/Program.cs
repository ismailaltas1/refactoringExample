// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using RefactoringExample;
using RefactoringExample.Calculator;
using RefactoringExample.Domain;
using RefactoringExample.Enums;
using RefactoringExample.Render;
using RefactoringExample.Statements;

Console.WriteLine("Hello, World!");

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

var statementData = new StatementCalculator().CreateStatementData(invoice);

var statement = RenderFactory.Render(statementData, RenderType.PlainText);
var htmlStatement = RenderFactory.Render(statementData, RenderType.Html);
System.Console.WriteLine(statement);
Console.Write(htmlStatement);