// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using RefactoringExample;
using RefactoringExample.Calculator;

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


var statement = invoice.HtmlStatement();
var htmlStatement = invoice.TextStatement();
System.Console.WriteLine(statement);
Console.Write(htmlStatement);