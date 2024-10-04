namespace FirstScraper;

public class HomeScraper
{
    public static async Task<List<HomeMenuLink>> GetHomeMenuLinks()
    {
        var navListXpath = "//*[@class=\"nav nav-list\"]/li/ul/li/a";
        var urlToScrap = $"{SD.BASE_URL}/books_1/index.html";

        var document = await ScraperUtils.GetDocumentAsync(urlToScrap);
        var nodes = document.DocumentNode.SelectNodes(navListXpath);

        return nodes.Select(a => new HomeMenuLink(
                ScraperUtils.ConvertToAbsoluteUri(a.Attributes["href"].Value),
                a.InnerText.Trim()
            ))
            .ToList();
    }
}
