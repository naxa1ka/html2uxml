namespace html2uxmlSharpDev.source.htmlDocument.Source;

public class EmptyAttributes : IAttributes
{
    public IEnumerable<IAttribute> Value => Enumerable.Empty<IAttribute>();

    public string AsString() => string.Empty;
}