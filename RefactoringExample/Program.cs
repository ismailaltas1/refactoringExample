// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using RefactoringExample;

Console.WriteLine("Hello, World!");

var playsJson = @"{
          ""hamlet"": {""name"": ""Hamlet"", ""type"": ""tragedy""},
          ""as-like"": {""name"": ""As You Like It"", ""type"": ""comedy""},
          ""othello"": {""name"": ""Othello"", ""type"": ""tragedy""}
        }";
var plays = JsonConvert.DeserializeObject<Dictionary<string, Play>>(playsJson);

// Create invoice
var invoiceJson = @"[
          {
            ""customer"": ""BigCo"",
            ""performances"": [
              {
                ""playID"": ""hamlet"",
                ""audience"": 55
              },
              {
                ""playID"": ""as-like"",
                ""audience"": 35
              },
              {
                ""playID"": ""othello"",
                ""audience"": 40
              }
            ]
          }
        ]";
var invoices = JsonConvert.DeserializeObject<List<Invoice>>(invoiceJson);

// Generate and print statement
foreach (var invoice in invoices)
{
  var invoiceStatement = new InvoiceStatement();
    var statement = invoiceStatement.GenerateStatement(invoice, plays);
    System.Console.WriteLine(statement);
}