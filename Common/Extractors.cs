namespace FirstScraper;

public class Extractors
{
    public static decimal ExtractDecimal(string row_string)
    {
        var regex = new Regex(@"[\d\.,]", RegexOptions.Compiled);
        var match = regex.Match(row_string);

        if (!match.Success)
            return 0m;

        return decimal.Parse(match.Value);
    }

    public static int ExtractInt(string row_string)
    {
        var regex = new Regex(@"[\d]", RegexOptions.Compiled);
        var match = regex.Match(row_string);

        if (!match.Success)
            return 0;

        return int.Parse(match.Value);
    }


}
