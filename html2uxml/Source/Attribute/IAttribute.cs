namespace html2uxmlSharpDev.source.htmlDocument.Source;

public interface IAttribute
{
    string Name { get; }
    string Value { get; }
    string AsString();
}