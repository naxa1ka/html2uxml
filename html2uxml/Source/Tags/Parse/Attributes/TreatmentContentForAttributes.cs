using htmlDocument.Source;

namespace html2uxmlSharpDev.source.InternalTextCursor;

internal class TreatmentContentForAttributes
{
    private readonly string _content;

    public TreatmentContentForAttributes(string content) => _content = content;

    public string Value()
    {
        var trimmed = _content.TrimStart().TrimEnd();
        if (trimmed == string.Empty)
            return trimmed;
        if (IsAttributesFromSelfClosingTag(trimmed))
            return ContentWithoutClosingTagSymbol(trimmed);

        return trimmed;
    }
    
    private bool IsAttributesFromSelfClosingTag(string content)
    {
        var lastSymbolInString = content[content.Length - 1];
        return new CloseTagSymbol().Equals(lastSymbolInString);
    }

    private string ContentWithoutClosingTagSymbol(string content)
    {
        return content.Remove(content.Length - 1);
    }
}