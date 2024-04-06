using RefactoringExample.Enums;
using RefactoringExample.Statements;
namespace RefactoringExample.Render;

public static class RenderFactory
{
    public static string Render(StatementData data, RenderType renderType)
    {
        return renderType switch
        {
            RenderType.PlainText => PlainTextStatementRenderer.Render(data),
            RenderType.Html => HtmlStatementRenderer.Render(data),
            _ => new string("render type not found.")
        };
    }
}
