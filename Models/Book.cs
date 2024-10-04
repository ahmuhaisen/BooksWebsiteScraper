namespace FirstScraper;

public class Book
{
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int InStockQuantity { get; set; }

    public override string ToString()
    {
        return $"{Title}, {Price.ToString("c")}, [({InStockQuantity} item(s) available in stock)]";
    }
}
