namespace FirstScraper.Models;

public class HomeMenuLink
{
    public HomeMenuLink(string url, string text)
    {
        Url = url;
        Text = text;
    }

    public string Url { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{Text}\n{Url}";
    }
}
