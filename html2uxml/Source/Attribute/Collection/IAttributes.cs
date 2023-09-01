namespace html2uxmlSharpDev.source.htmlDocument.Source;

public interface IAttributes
{
    IEnumerable<IAttribute> Value { get; }
    string AsString();
}