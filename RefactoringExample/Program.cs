// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using RefactoringExample;

Console.WriteLine("Hello, World!");

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


var statement = invoice.GenerateStatement();
System.Console.WriteLine(statement);