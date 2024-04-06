using System.Globalization;
namespace RefactoringExample.Helper;

public static class FormatHelper
{
    public static string Usd(decimal aNumber)
    {
        CultureInfo cultureInfo = new CultureInfo("en-US");
        NumberFormatInfo numberFormat = cultureInfo.NumberFormat;
        numberFormat.CurrencySymbol = "$";
        numberFormat.CurrencyDecimalDigits = 2;
        return (aNumber / 100M).ToString("C", numberFormat);
    }

    
}