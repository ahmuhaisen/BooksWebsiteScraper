namespace FirstScraper;

public class ScraperUtils
{
    public static async Task<HtmlDocument> GetDocumentAsync(string url)
    {
        var web = new HtmlWeb();
        return await web.LoadFromWebAsync(url);
    }

    public static string ConvertToAbsoluteUri(string hrefValue)
    {
        var baseUri = new Uri(SD.BASE_URL);
        var temp = new Uri(baseUri, hrefValue);
        return $"{baseUri.AbsoluteUri}{temp.AbsolutePath}";
    }
}
