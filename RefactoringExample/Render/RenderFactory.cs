using RefactoringExample.Enums;
using RefactoringExample.Statements;

namespace RefactoringExample.Render;

public static class RenderFactory
{
    public static string Render(StatementData data, RenderType renderType)
    {
        switch (renderType)
        {
            case RenderType.PlainText:
                return PlainTextStatementRenderer.Render(data);
                break;
            case RenderType.Html:
                return  HtmlStatementRenderer.Render(data);
                break;
            default:
                return new string("render type not found.");
            
            
        }
    }
}
