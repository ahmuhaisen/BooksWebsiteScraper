var items = await HomeScraper.GetHomeMenuLinks();

foreach (var i in items)
{
    Console.Clear();
    Console.WriteLine(i);
    Console.WriteLine($"================{i.Text}===============");
    var document = await ScraperUtils.GetDocumentAsync(i.Url);
    var links = BookScraper.GetBookLinks(document, i.Url);
    var books = BookScraper.GetBooksData(links);

    if (books is not null && books.Any())
        await CsvService.ExportBooksToCsvAsync(books, i.Text);

    foreach (var book in books!)
    {
        Console.WriteLine(book);
        Console.WriteLine("--------------------------------");
    }

    Thread.Sleep(2000);
}