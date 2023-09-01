namespace html2uxmlSharpDev.source.htmlDocument.Source;

public class SelfClosingTags
{
    private readonly List<string> _tags = new()
    {
        "link",
        "img",
        "input",
        "br"
    };

    public bool IsTagSelfClosing(string content) => _tags.Any(content.Equals);
}