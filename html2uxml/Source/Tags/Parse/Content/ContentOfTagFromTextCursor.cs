using htmlDocument.Source;

namespace html2uxmlSharpDev.source.InternalTextCursor;

internal class ContentOfTagFromTextCursor
{
    private readonly ITextCursor _textCursor;

    public ContentOfTagFromTextCursor(ITextCursor textCursor)
    {
        _textCursor = textCursor;
    }

    public string Value()
    {
        if (new OpenTagBracketSymbol().Equals(_textCursor.Next()))
            return string.Empty;

        return new ContentOfTextCursor(
            new TextCursorWithPeekNextCondition(
                _textCursor,
                new NotEqualsSymbolIterateCondition(
                    new OpenTagBracketSymbol()
                )
            )
        ).ContentNext();
    }
}