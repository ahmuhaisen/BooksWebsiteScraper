namespace FirstScraper;

public class CsvService
{
    public static async Task ExportBooksToCsvAsync(List<Book> books, string category)
    {
        var fileName = category + "__" + DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss");
        var filePath = $"data/books/{fileName}.csv";

        using (var streamWriter = new StreamWriter(filePath))
        {
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                await csvWriter.WriteRecordsAsync(books);
            }
        }
    }
}