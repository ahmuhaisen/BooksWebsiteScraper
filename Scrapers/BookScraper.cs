namespace FirstScraper;

public class BookScraper
{
    public static List<string> GetBookLinks(HtmlDocument document, string url)
    {
        HtmlNodeCollection linkNodes = document.DocumentNode.SelectNodes("//h3/a");

        var baseUri = new Uri(url);

        var absoluteBookLinks = linkNodes
                          .Select(n => new Uri(baseUri, n.Attributes["href"].Value).AbsoluteUri)
                          .ToList();

        return absoluteBookLinks;
    }

    public static async Task<Book> GetBookFromLinkAsync(string bookDetailsPageUrl)
    {
        var priceXpath = "//*[@class=\"col-sm-6 product_main\"]/*[@class=\"price_color\"]";
        var stockXpath = "//*[@class=\"col-sm-6 product_main\"]/*[@class=\"instock availability\"]";

        var document = await ScraperUtils.GetDocumentAsync(bookDetailsPageUrl);

        var title = document.DocumentNode.SelectSingleNode("//h1").InnerText;

        var rowPrice = document.DocumentNode.SelectSingleNode(priceXpath).InnerText;
        var price = Extractors.ExtractDecimal(rowPrice);

        var rowStock = document.DocumentNode.SelectSingleNode(stockXpath).InnerText;
        var quantityInStock = Extractors.ExtractInt(rowStock);

        return new Book
        {
            Title = title,
            Price = price,
            InStockQuantity = quantityInStock
        };
    }

    public static List<Book> GetBooksData(List<string> links)
    {
        return links.Select(l => GetBookFromLinkAsync(l).GetAwaiter().GetResult()).ToList();
    }

}
